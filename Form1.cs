using MediaToolkit;
using MediaToolkit.Model;
using Ookii.Dialogs.WinForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;
using YouTubeSearch;

namespace YoutubeDownloader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Log(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("[LOG] ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(msg);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            if (File.Exists(Application.StartupPath + @"\path.txt"))
            {
                var t = File.ReadAllText(Application.StartupPath + @"\path.txt");
                if (Directory.Exists(FolderPath.Text))
                    FolderPath.Text = t;
            }
        }


        private void browseFolder_Click(object sender, EventArgs e)
        {
            VistaFolderBrowserDialog dlg = new VistaFolderBrowserDialog();
            dlg.ShowNewFolderButton = true;

            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FolderPath.Text = dlg.SelectedPath;
                File.WriteAllText(Application.StartupPath + @"\path.txt", FolderPath.Text);
            }
        }
        static Thread t;
        private async void DownloadVideo_Click(object sender, EventArgs e)
        {
            if(!Directory.Exists(FolderPath.Text))
            {
                MessageBox.Show("Save folder does not exist or empty!");
                return;
            }
            DownloadVideo.Enabled = false;
            RemoveMediaToListview.Enabled = false;
            AddMediaToListview.Enabled = false;
            listpath = new List<string>();
            t = new Thread(downloadEverythingInList);
            t.Start();
        }
        private static int itemsDownloaded = 0;
        public async void downloadEverythingInList()
        {
            Log("Started downloading...");
            itemsDownloaded = 0;
            MediaProgressBar.Value = 0;
            foreach (ListViewItem items in MediaListView.Items)
            {
                DownloadProgressBar.Value = 0;
                string nameorurl = items.SubItems[0].Text;
                //string type = items.SubItems[1].Text;
                //bool ismp3 = type == "Audio";
                bool result = Uri.TryCreate(nameorurl, UriKind.Absolute, out Uri _);
                if (result)
                {
                    await DownloadVideoWithLink(nameorurl, FolderPath.Text, mp3radioBtn.Checked); //Video url
                }
                else
                {
                    string link = await getVid(nameorurl); //search vid
                    if (link == null || link.Equals("Error!")) continue;
                    try
                    {
                        await DownloadVideoWithLink(link, FolderPath.Text, mp3radioBtn.Checked);
                    }
                    catch
                    {
                        Log("Skipped downloading " + link + "!");
                        continue;
                    }
                }
            }
            foreach (string s in listpath)
            {
                if (!File.Exists(s)) continue;
                Log("Converting " + Path.GetFileName(s) + " to mp3...");
                var inputFile = new MediaFile { Filename = s };
                var outputFile = new MediaFile { Filename = Path.GetDirectoryName(s) + @"\" +  Path.GetFileNameWithoutExtension(s) + ".mp3" };

                using (var engine = new Engine())
                {
                    engine.GetMetadata(inputFile);

                    engine.Convert(inputFile, outputFile);
                }
                Log("Converted " + Path.GetFileName(s) + " to mp3!");
                Log("deleting " + Path.GetFileName(s) + "...");
                try
                {
                    File.Delete(s);
                    Log("deleted " + Path.GetFileName(s) + "!");
                }
                catch
                {
                    Log("Error deleting " + s + "!");
                }
            }
            Log("Finished converting to mp3!");
        }
        //Algorithm to check if title closely matches the vid result
        public static int ComputeSimilarity(string s, string t)
        {
            if (string.IsNullOrEmpty(s))
            {
                if (string.IsNullOrEmpty(t))
                    return 0;
                return t.Length;
            }

            if (string.IsNullOrEmpty(t))
            {
                return s.Length;
            }

            int n = s.Length;
            int m = t.Length;
            int[,] d = new int[n + 1, m + 1];

            // initialize the top and right of the table to 0, 1, 2, ...
            for (int i = 0; i <= n; d[i, 0] = i++) ;
            for (int j = 1; j <= m; d[0, j] = j++) ;

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;
                    int min1 = d[i - 1, j] + 1;
                    int min2 = d[i, j - 1] + 1;
                    int min3 = d[i - 1, j - 1] + cost;
                    d[i, j] = Math.Min(Math.Min(min1, min2), min3);
                }
            }
            return d[n, m];
        }
        private static async Task<string> getVid(string VidName)
        {
            int attemptcountmax = 10; //sometimes search function is buggy.
            int attemptcount = 0;
            here:
            try
            {

                VideoSearch vs = new VideoSearch();
                var items = await vs.GetVideos(VidName, 1);
                if (items.Count == 0) goto here;
                var validVid = GetValidVideo(items, VidName);
                return validVid.getUrl();

            }
            catch
            {
                if (attemptcount != attemptcountmax)
                {
                    attemptcount++;
                    goto here;
                }
            }
            return null;
        }
        private static VideoSearchComponents GetValidVideo(List<VideoSearchComponents> videos, string VidName)
        {
            TimeSpan tstofind = TimeSpan.Parse("06:00"); //ignore 1 hour videos
            SortedDictionary<Tuple<int, long>, VideoSearchComponents> scores = new SortedDictionary<Tuple<int, long>, VideoSearchComponents>();
            foreach(var video in videos)
            {
                try
                {
                    TimeSpan ts = TimeSpan.Parse(video.getDuration());
                    int similarityScore = ComputeSimilarity(VidName.ToLower(), video.getTitle().ToLower());
                    long views = long.Parse(video.getViewCount().Replace(".", "").Replace(",", ""));
                    if (ts.TotalSeconds <= tstofind.TotalSeconds && similarityScore <= 20/* && views >= 10000*/) scores.Add(Tuple.Create(similarityScore, views), video);
                }
                catch
                {
                    continue;
                }
            }
            return scores.Aggregate((agg, next) =>next.Key.Item1 <= agg.Key.Item1 && next.Key.Item2 >= agg.Key.Item2 ? next : agg).Value;
            //Get the video with highest views and best similarity score
            //Lowest similarity score => better or closest
        }
        public static string grabstrbetween(string text, string left, string right)
        {
            int beginIndex = text.IndexOf(left);
            if (beginIndex == -1)
                return string.Empty;
            beginIndex += left.Length;
            int endIndex = text.IndexOf(right, beginIndex);
            if (endIndex == -1)
                return string.Empty;
            return text.Substring(beginIndex, endIndex - beginIndex).Trim();
        }
        private static List<string> listpath = new List<string>();
        private async Task DownloadVideoWithLink(string url, string FolderDest, bool ismp3)
        {
            var youtube = new YoutubeClient();
            var video = await youtube.Videos.GetAsync(url);
            var streamManifest = await youtube.Videos.Streams.GetManifestAsync(video.Id);
            IStreamInfo streamInfo;
            if (ismp3) streamInfo = (IAudioStreamInfo)streamManifest.GetAudioOnlyStreams().Where(s => s.Container == YoutubeExplode.Videos.Streams.Container.Mp4).GetWithHighestBitrate();
            else streamInfo = (IVideoStreamInfo)streamManifest.GetVideoOnlyStreams().Where(s => s.Container == YoutubeExplode.Videos.Streams.Container.Mp4).GetWithHighestVideoQuality();
            if (streamInfo != null)
            {
                string illegal = string.Join("_", video.Title.Split(Path.GetInvalidFileNameChars()));
                listpath.Add(FolderDest + @"\" + illegal + Path.GetExtension($"video.{streamInfo.Container}"));
                // Get the actual stream
                var stream = await youtube.Videos.Streams.GetAsync(streamInfo);
                Log("Downloading " + video.Title.Replace("/", "").Replace(@"\", "") + "..." + "[" + itemsDownloaded.ToString() + "/" + MediaListView.Items.Count.ToString() + "]");
                // Download the stream to file
                var prog = new Progress<double>();
                prog.ProgressChanged += VidDLProg;
                await youtube.Videos.Streams.DownloadAsync(streamInfo, FolderDest + @"\" + illegal + Path.GetExtension($"video.{streamInfo.Container}"), prog);

                itemsDownloaded++;
                Log("Finished downloading video! " + "[" + itemsDownloaded.ToString() + "/" + MediaListView.Items.Count.ToString() + "]");
                MediaProgressBar.Value = (itemsDownloaded / MediaListView.Items.Count) * 100;
                DownloadedMediaProgressCount.Text = MediaProgressBar.Value.ToString() + "%";
                if (MediaProgressBar.Value == 100)
                {
                    DownloadVideo.Enabled = true;
                    RemoveMediaToListview.Enabled = true;
                    AddMediaToListview.Enabled = true;
                    Log("Finished all downloading videos! " + "[" + itemsDownloaded.ToString() + "/" + MediaListView.Items.Count.ToString() + "]");
                }
            }

        }

        private void VidDLProg(object sender, double e)
        {
            try
            {
                double o = Math.Round(e, 2, MidpointRounding.AwayFromZero) * 100;
                DownloadProgressBar.Value = Convert.ToInt32(o);
                DownloadProgressCount.Text = DownloadProgressBar.Value.ToString() + "%";
            }
            catch
            {
                Log("Some error occured at progress bar!");
            }
        }

        private async void AddMediaToListview_Click(object sender, EventArgs e)
        {
            string str = YoutubeLinkOrVidName.Text;
            
            ListViewItem item = new ListViewItem(new[] { str, mp3radioBtn.Checked ? "Audio" : "Video" });
            MediaListView.Items.Add(item);

            YoutubeLinkOrVidName.Text = String.Empty;
        }

        private void RemoveMediaToListview_Click(object sender, EventArgs e)
        {
            if (MediaListView.Items.Count > 0 && MediaListView.SelectedItems.Count == 1 && MediaListView.SelectedItems[0] != null)
                MediaListView.Items.Remove(MediaListView.SelectedItems[0]);
        }
    }
}
