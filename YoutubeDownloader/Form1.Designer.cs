namespace YoutubeDownloader
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.browseFolder = new System.Windows.Forms.Button();
            this.FolderPath = new System.Windows.Forms.TextBox();
            this.YoutubeLinkOrVidName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DownloadVideo = new System.Windows.Forms.Button();
            this.vidradioBtn = new System.Windows.Forms.RadioButton();
            this.mp3radioBtn = new System.Windows.Forms.RadioButton();
            this.MediaListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RemoveMediaToListview = new System.Windows.Forms.Button();
            this.AddMediaToListview = new System.Windows.Forms.Button();
            this.DownloadProgressBar = new System.Windows.Forms.ProgressBar();
            this.MediaProgressBar = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.DownloadProgressCount = new System.Windows.Forms.Label();
            this.DownloadedMediaProgressCount = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // browseFolder
            // 
            this.browseFolder.Location = new System.Drawing.Point(12, 33);
            this.browseFolder.Name = "browseFolder";
            this.browseFolder.Size = new System.Drawing.Size(29, 20);
            this.browseFolder.TabIndex = 0;
            this.browseFolder.Text = "...";
            this.browseFolder.UseVisualStyleBackColor = true;
            this.browseFolder.Click += new System.EventHandler(this.browseFolder_Click);
            // 
            // FolderPath
            // 
            this.FolderPath.Location = new System.Drawing.Point(47, 33);
            this.FolderPath.Name = "FolderPath";
            this.FolderPath.ReadOnly = true;
            this.FolderPath.Size = new System.Drawing.Size(584, 20);
            this.FolderPath.TabIndex = 1;
            // 
            // YoutubeLinkOrVidName
            // 
            this.YoutubeLinkOrVidName.Location = new System.Drawing.Point(6, 37);
            this.YoutubeLinkOrVidName.Name = "YoutubeLinkOrVidName";
            this.YoutubeLinkOrVidName.Size = new System.Drawing.Size(607, 20);
            this.YoutubeLinkOrVidName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Folder Path: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Youtube Link/Title: ";
            // 
            // DownloadVideo
            // 
            this.DownloadVideo.Location = new System.Drawing.Point(531, 462);
            this.DownloadVideo.Name = "DownloadVideo";
            this.DownloadVideo.Size = new System.Drawing.Size(94, 23);
            this.DownloadVideo.TabIndex = 6;
            this.DownloadVideo.Text = "Start Download";
            this.DownloadVideo.UseVisualStyleBackColor = true;
            this.DownloadVideo.Click += new System.EventHandler(this.DownloadVideo_Click);
            // 
            // vidradioBtn
            // 
            this.vidradioBtn.AutoSize = true;
            this.vidradioBtn.Location = new System.Drawing.Point(58, 63);
            this.vidradioBtn.Name = "vidradioBtn";
            this.vidradioBtn.Size = new System.Drawing.Size(52, 17);
            this.vidradioBtn.TabIndex = 7;
            this.vidradioBtn.Text = "Video";
            this.vidradioBtn.UseVisualStyleBackColor = true;
            // 
            // mp3radioBtn
            // 
            this.mp3radioBtn.AutoSize = true;
            this.mp3radioBtn.Checked = true;
            this.mp3radioBtn.Location = new System.Drawing.Point(5, 63);
            this.mp3radioBtn.Name = "mp3radioBtn";
            this.mp3radioBtn.Size = new System.Drawing.Size(47, 17);
            this.mp3radioBtn.TabIndex = 8;
            this.mp3radioBtn.TabStop = true;
            this.mp3radioBtn.Text = "MP3";
            this.mp3radioBtn.UseVisualStyleBackColor = true;
            // 
            // MediaListView
            // 
            this.MediaListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.MediaListView.FullRowSelect = true;
            this.MediaListView.HideSelection = false;
            this.MediaListView.LabelEdit = true;
            this.MediaListView.Location = new System.Drawing.Point(12, 59);
            this.MediaListView.MultiSelect = false;
            this.MediaListView.Name = "MediaListView";
            this.MediaListView.Size = new System.Drawing.Size(619, 197);
            this.MediaListView.TabIndex = 9;
            this.MediaListView.UseCompatibleStateImageBehavior = false;
            this.MediaListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Youtube Link";
            this.columnHeader1.Width = 500;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Stream type";
            this.columnHeader2.Width = 115;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RemoveMediaToListview);
            this.groupBox1.Controls.Add(this.AddMediaToListview);
            this.groupBox1.Controls.Add(this.YoutubeLinkOrVidName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.mp3radioBtn);
            this.groupBox1.Controls.Add(this.vidradioBtn);
            this.groupBox1.Location = new System.Drawing.Point(12, 262);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(619, 94);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add media";
            // 
            // RemoveMediaToListview
            // 
            this.RemoveMediaToListview.Location = new System.Drawing.Point(419, 61);
            this.RemoveMediaToListview.Name = "RemoveMediaToListview";
            this.RemoveMediaToListview.Size = new System.Drawing.Size(94, 23);
            this.RemoveMediaToListview.TabIndex = 12;
            this.RemoveMediaToListview.Text = "Remove";
            this.RemoveMediaToListview.UseVisualStyleBackColor = true;
            this.RemoveMediaToListview.Click += new System.EventHandler(this.RemoveMediaToListview_Click);
            // 
            // AddMediaToListview
            // 
            this.AddMediaToListview.Location = new System.Drawing.Point(519, 61);
            this.AddMediaToListview.Name = "AddMediaToListview";
            this.AddMediaToListview.Size = new System.Drawing.Size(94, 23);
            this.AddMediaToListview.TabIndex = 11;
            this.AddMediaToListview.Text = "Add";
            this.AddMediaToListview.UseVisualStyleBackColor = true;
            this.AddMediaToListview.Click += new System.EventHandler(this.AddMediaToListview_Click);
            // 
            // DownloadProgressBar
            // 
            this.DownloadProgressBar.BackColor = System.Drawing.Color.Black;
            this.DownloadProgressBar.ForeColor = System.Drawing.Color.Cyan;
            this.DownloadProgressBar.Location = new System.Drawing.Point(12, 386);
            this.DownloadProgressBar.Name = "DownloadProgressBar";
            this.DownloadProgressBar.Size = new System.Drawing.Size(613, 10);
            this.DownloadProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.DownloadProgressBar.TabIndex = 11;
            // 
            // MediaProgressBar
            // 
            this.MediaProgressBar.BackColor = System.Drawing.Color.Black;
            this.MediaProgressBar.ForeColor = System.Drawing.Color.Cyan;
            this.MediaProgressBar.Location = new System.Drawing.Point(12, 435);
            this.MediaProgressBar.Name = "MediaProgressBar";
            this.MediaProgressBar.Size = new System.Drawing.Size(613, 10);
            this.MediaProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.MediaProgressBar.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 367);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Download Progress:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 416);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "Downloaded Media:";
            // 
            // DownloadProgressCount
            // 
            this.DownloadProgressCount.AutoSize = true;
            this.DownloadProgressCount.Font = new System.Drawing.Font("Century Gothic", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DownloadProgressCount.Location = new System.Drawing.Point(18, 399);
            this.DownloadProgressCount.Name = "DownloadProgressCount";
            this.DownloadProgressCount.Size = new System.Drawing.Size(20, 13);
            this.DownloadProgressCount.TabIndex = 14;
            this.DownloadProgressCount.Text = "0%";
            // 
            // DownloadedMediaProgressCount
            // 
            this.DownloadedMediaProgressCount.AutoSize = true;
            this.DownloadedMediaProgressCount.Font = new System.Drawing.Font("Century Gothic", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DownloadedMediaProgressCount.Location = new System.Drawing.Point(18, 448);
            this.DownloadedMediaProgressCount.Name = "DownloadedMediaProgressCount";
            this.DownloadedMediaProgressCount.Size = new System.Drawing.Size(20, 13);
            this.DownloadedMediaProgressCount.TabIndex = 15;
            this.DownloadedMediaProgressCount.Text = "0%";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 497);
            this.Controls.Add(this.DownloadedMediaProgressCount);
            this.Controls.Add(this.DownloadProgressCount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.MediaProgressBar);
            this.Controls.Add(this.DownloadProgressBar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.MediaListView);
            this.Controls.Add(this.DownloadVideo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FolderPath);
            this.Controls.Add(this.browseFolder);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Simple Youtube Downloader";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button browseFolder;
        private System.Windows.Forms.TextBox FolderPath;
        private System.Windows.Forms.TextBox YoutubeLinkOrVidName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button DownloadVideo;
        private System.Windows.Forms.RadioButton vidradioBtn;
        private System.Windows.Forms.RadioButton mp3radioBtn;
        private System.Windows.Forms.ListView MediaListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button AddMediaToListview;
        private System.Windows.Forms.ProgressBar DownloadProgressBar;
        private System.Windows.Forms.Button RemoveMediaToListview;
        private System.Windows.Forms.ProgressBar MediaProgressBar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label DownloadProgressCount;
        private System.Windows.Forms.Label DownloadedMediaProgressCount;
    }
}

