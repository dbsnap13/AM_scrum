namespace TextPoint
{
    partial class FRMMain
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.audioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timestampToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.repeatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTimeStamp = new System.Windows.Forms.Button();
            this.lblCurrent = new System.Windows.Forms.Label();
            this.btnRepeat = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.trackBar_PlayBackRate = new System.Windows.Forms.TrackBar();
            this.trackBar_PlayBackPosition = new System.Windows.Forms.TrackBar();
            this.label_PlayBackRate = new System.Windows.Forms.Label();
            this.label_PlayBackPosition = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.checkBox_AutoPlayBackRate = new System.Windows.Forms.CheckBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip_btnPlayPause = new System.Windows.Forms.ToolTip(this.components);
            this.btnPause = new System.Windows.Forms.Button();
            this.toolTip_btnStop = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip_btnRepeat = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip_btnTimeStamp = new System.Windows.Forms.ToolTip(this.components);
            this.txtBoxUserSec = new System.Windows.Forms.TextBox();
            this.checkBox_AutoPlayNext = new System.Windows.Forms.CheckBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.toolTip_PositionTrackBar = new System.Windows.Forms.ToolTip(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.btnCreateLabel = new System.Windows.Forms.Button();
            this.lstBoxLabel = new System.Windows.Forms.ListBox();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.enhanchedTextBox1 = new TextPoint.EnhanchedTextBox();
            this.btnUpdatelstBoxLabel = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_PlayBackRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_PlayBackPosition)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.editToolStripMenuItem,
            this.audioToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1175, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "File";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(100, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fontToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // fontToolStripMenuItem
            // 
            this.fontToolStripMenuItem.Name = "fontToolStripMenuItem";
            this.fontToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.fontToolStripMenuItem.Text = "Font";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.cutToolStripMenuItem.Text = "Cut         (Ctrl + X)";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.copyToolStripMenuItem.Text = "Copy      (Ctrl + C)";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.pasteToolStripMenuItem.Text = "Paste      (Ctrl + V)";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // audioToolStripMenuItem
            // 
            this.audioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playToolStripMenuItem,
            this.pauseToolStripMenuItem,
            this.timestampToolStripMenuItem,
            this.repeatToolStripMenuItem,
            this.stopToolStripMenuItem});
            this.audioToolStripMenuItem.Name = "audioToolStripMenuItem";
            this.audioToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.audioToolStripMenuItem.Text = "Audio";
            // 
            // playToolStripMenuItem
            // 
            this.playToolStripMenuItem.Name = "playToolStripMenuItem";
            this.playToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.playToolStripMenuItem.Text = "Play                (F2)";
            this.playToolStripMenuItem.Click += new System.EventHandler(this.playToolStripMenuItem_Click);
            // 
            // pauseToolStripMenuItem
            // 
            this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
            this.pauseToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.pauseToolStripMenuItem.Text = "Pause             (F2)";
            this.pauseToolStripMenuItem.Click += new System.EventHandler(this.pauseToolStripMenuItem_Click);
            // 
            // timestampToolStripMenuItem
            // 
            this.timestampToolStripMenuItem.Name = "timestampToolStripMenuItem";
            this.timestampToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.timestampToolStripMenuItem.Text = "Timestamp   (F3)";
            this.timestampToolStripMenuItem.Click += new System.EventHandler(this.timestampToolStripMenuItem_Click);
            // 
            // repeatToolStripMenuItem
            // 
            this.repeatToolStripMenuItem.Name = "repeatToolStripMenuItem";
            this.repeatToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.repeatToolStripMenuItem.Text = "Repeat           (F4)";
            this.repeatToolStripMenuItem.Click += new System.EventHandler(this.repeatToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.stopToolStripMenuItem.Text = "Stop               (F5)";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // btnTimeStamp
            // 
            this.btnTimeStamp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnTimeStamp.Location = new System.Drawing.Point(246, 372);
            this.btnTimeStamp.Name = "btnTimeStamp";
            this.btnTimeStamp.Size = new System.Drawing.Size(68, 23);
            this.btnTimeStamp.TabIndex = 2;
            this.btnTimeStamp.Text = "Timestamp";
            this.toolTip_btnTimeStamp.SetToolTip(this.btnTimeStamp, "Timestamp (F3)");
            this.btnTimeStamp.UseVisualStyleBackColor = true;
            this.btnTimeStamp.Click += new System.EventHandler(this.btnTimeStamp_Click);
            // 
            // lblCurrent
            // 
            this.lblCurrent.AutoSize = true;
            this.lblCurrent.Location = new System.Drawing.Point(354, 356);
            this.lblCurrent.Name = "lblCurrent";
            this.lblCurrent.Size = new System.Drawing.Size(0, 13);
            this.lblCurrent.TabIndex = 3;
            // 
            // btnRepeat
            // 
            this.btnRepeat.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRepeat.Location = new System.Drawing.Point(363, 373);
            this.btnRepeat.Name = "btnRepeat";
            this.btnRepeat.Size = new System.Drawing.Size(68, 23);
            this.btnRepeat.TabIndex = 6;
            this.btnRepeat.Text = "Repeat";
            this.toolTip_btnRepeat.SetToolTip(this.btnRepeat, "Repeat (F4)");
            this.btnRepeat.UseVisualStyleBackColor = true;
            this.btnRepeat.Click += new System.EventHandler(this.btnRepeat_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPlay.Location = new System.Drawing.Point(12, 372);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(72, 23);
            this.btnPlay.TabIndex = 8;
            this.btnPlay.Text = "Play";
            this.toolTip_btnPlayPause.SetToolTip(this.btnPlay, "Play (F2)");
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlayPause_Click);
            // 
            // btnStop
            // 
            this.btnStop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnStop.Location = new System.Drawing.Point(168, 372);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(72, 23);
            this.btnStop.TabIndex = 9;
            this.btnStop.Text = "Stop";
            this.toolTip_btnStop.SetToolTip(this.btnStop, "Stop (F5)");
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // trackBar_PlayBackRate
            // 
            this.trackBar_PlayBackRate.LargeChange = 1;
            this.trackBar_PlayBackRate.Location = new System.Drawing.Point(12, 431);
            this.trackBar_PlayBackRate.Maximum = 4;
            this.trackBar_PlayBackRate.Minimum = -3;
            this.trackBar_PlayBackRate.Name = "trackBar_PlayBackRate";
            this.trackBar_PlayBackRate.Size = new System.Drawing.Size(428, 45);
            this.trackBar_PlayBackRate.TabIndex = 10;
            this.trackBar_PlayBackRate.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBar_PlayBackRate.Scroll += new System.EventHandler(this.trackBar_PlayBackRate_Scroll);
            // 
            // trackBar_PlayBackPosition
            // 
            this.trackBar_PlayBackPosition.BackColor = System.Drawing.SystemColors.Control;
            this.trackBar_PlayBackPosition.Location = new System.Drawing.Point(12, 513);
            this.trackBar_PlayBackPosition.Maximum = 100;
            this.trackBar_PlayBackPosition.Name = "trackBar_PlayBackPosition";
            this.trackBar_PlayBackPosition.Size = new System.Drawing.Size(428, 45);
            this.trackBar_PlayBackPosition.TabIndex = 11;
            this.trackBar_PlayBackPosition.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_PlayBackPosition.Scroll += new System.EventHandler(this.trackBar_PlayBackPosition_Scroll);
            // 
            // label_PlayBackRate
            // 
            this.label_PlayBackRate.AutoSize = true;
            this.label_PlayBackRate.Location = new System.Drawing.Point(21, 415);
            this.label_PlayBackRate.Name = "label_PlayBackRate";
            this.label_PlayBackRate.Size = new System.Drawing.Size(121, 13);
            this.label_PlayBackRate.TabIndex = 12;
            this.label_PlayBackRate.Text = "Playback rate: 1x speed";
            // 
            // label_PlayBackPosition
            // 
            this.label_PlayBackPosition.AutoSize = true;
            this.label_PlayBackPosition.Location = new System.Drawing.Point(21, 473);
            this.label_PlayBackPosition.Name = "label_PlayBackPosition";
            this.label_PlayBackPosition.Size = new System.Drawing.Size(123, 13);
            this.label_PlayBackPosition.TabIndex = 13;
            this.label_PlayBackPosition.Text = "Playback position: 00:00";
            // 
            // checkBox_AutoPlayBackRate
            // 
            this.checkBox_AutoPlayBackRate.AutoSize = true;
            this.checkBox_AutoPlayBackRate.Location = new System.Drawing.Point(556, 379);
            this.checkBox_AutoPlayBackRate.Name = "checkBox_AutoPlayBackRate";
            this.checkBox_AutoPlayBackRate.Size = new System.Drawing.Size(115, 17);
            this.checkBox_AutoPlayBackRate.TabIndex = 14;
            this.checkBox_AutoPlayBackRate.Text = "Auto playback rate";
            this.checkBox_AutoPlayBackRate.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(444, 383);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "label1";
            // 
            // toolTip_btnPlayPause
            // 
            this.toolTip_btnPlayPause.IsBalloon = true;
            // 
            // btnPause
            // 
            this.btnPause.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPause.Location = new System.Drawing.Point(90, 372);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(72, 23);
            this.btnPause.TabIndex = 18;
            this.btnPause.Text = "Pause";
            this.toolTip_btnPlayPause.SetToolTip(this.btnPause, "Play (F2)");
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btn_Pause_Click);
            // 
            // toolTip_btnStop
            // 
            this.toolTip_btnStop.IsBalloon = true;
            // 
            // toolTip_btnRepeat
            // 
            this.toolTip_btnRepeat.IsBalloon = true;
            // 
            // toolTip_btnTimeStamp
            // 
            this.toolTip_btnTimeStamp.IsBalloon = true;
            // 
            // txtBoxUserSec
            // 
            this.txtBoxUserSec.Location = new System.Drawing.Point(320, 375);
            this.txtBoxUserSec.Name = "txtBoxUserSec";
            this.txtBoxUserSec.Size = new System.Drawing.Size(37, 20);
            this.txtBoxUserSec.TabIndex = 17;
            this.txtBoxUserSec.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxUserSec_KeyPress);
            // 
            // checkBox_AutoPlayNext
            // 
            this.checkBox_AutoPlayNext.AutoSize = true;
            this.checkBox_AutoPlayNext.Location = new System.Drawing.Point(679, 379);
            this.checkBox_AutoPlayNext.Name = "checkBox_AutoPlayNext";
            this.checkBox_AutoPlayNext.Size = new System.Drawing.Size(93, 17);
            this.checkBox_AutoPlayNext.TabIndex = 19;
            this.checkBox_AutoPlayNext.Text = "Auto play next";
            this.checkBox_AutoPlayNext.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(447, 431);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(325, 121);
            this.listBox1.TabIndex = 20;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // toolTip_PositionTrackBar
            // 
            this.toolTip_PositionTrackBar.IsBalloon = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(587, 415);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Playlist";
            // 
            // btnCreateLabel
            // 
            this.btnCreateLabel.Location = new System.Drawing.Point(778, 431);
            this.btnCreateLabel.Name = "btnCreateLabel";
            this.btnCreateLabel.Size = new System.Drawing.Size(75, 23);
            this.btnCreateLabel.TabIndex = 23;
            this.btnCreateLabel.Text = "Add Label";
            this.btnCreateLabel.UseVisualStyleBackColor = true;
            this.btnCreateLabel.Click += new System.EventHandler(this.btnCreateLabel_Click);
            // 
            // lstBoxLabel
            // 
            this.lstBoxLabel.FormattingEnabled = true;
            this.lstBoxLabel.Location = new System.Drawing.Point(859, 431);
            this.lstBoxLabel.Name = "lstBoxLabel";
            this.lstBoxLabel.Size = new System.Drawing.Size(287, 121);
            this.lstBoxLabel.TabIndex = 24;
            this.lstBoxLabel.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstBoxLabel_MouseDoubleClick);
            // 
            // elementHost1
            // 
            this.elementHost1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.elementHost1.Location = new System.Drawing.Point(12, 27);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(1151, 307);
            this.elementHost1.TabIndex = 16;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.enhanchedTextBox1;
            // 
            // btnUpdatelstBoxLabel
            // 
            this.btnUpdatelstBoxLabel.Location = new System.Drawing.Point(778, 460);
            this.btnUpdatelstBoxLabel.Name = "btnUpdatelstBoxLabel";
            this.btnUpdatelstBoxLabel.Size = new System.Drawing.Size(75, 23);
            this.btnUpdatelstBoxLabel.TabIndex = 25;
            this.btnUpdatelstBoxLabel.Text = "Update List";
            this.btnUpdatelstBoxLabel.UseVisualStyleBackColor = true;
            this.btnUpdatelstBoxLabel.Click += new System.EventHandler(this.btnUpdatelstBoxLabel_Click);
            // 
            // FRMMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1175, 561);
            this.Controls.Add(this.btnUpdatelstBoxLabel);
            this.Controls.Add(this.lstBoxLabel);
            this.Controls.Add(this.btnCreateLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.checkBox_AutoPlayNext);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.txtBoxUserSec);
            this.Controls.Add(this.elementHost1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox_AutoPlayBackRate);
            this.Controls.Add(this.label_PlayBackPosition);
            this.Controls.Add(this.label_PlayBackRate);
            this.Controls.Add(this.trackBar_PlayBackPosition);
            this.Controls.Add(this.trackBar_PlayBackRate);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.btnRepeat);
            this.Controls.Add(this.lblCurrent);
            this.Controls.Add(this.btnTimeStamp);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FRMMain";
            this.Text = "TextPoint";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FRMMain_FormClosing);
            this.Load += new System.EventHandler(this.FRMMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_PlayBackRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_PlayBackPosition)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.Button btnTimeStamp;
        private System.Windows.Forms.Label lblCurrent;
        private System.Windows.Forms.Button btnRepeat;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TrackBar trackBar_PlayBackRate;
        private System.Windows.Forms.TrackBar trackBar_PlayBackPosition;
        private System.Windows.Forms.Label label_PlayBackRate;
        private System.Windows.Forms.Label label_PlayBackPosition;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox checkBox_AutoPlayBackRate;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private EnhanchedTextBox enhanchedTextBox1;
        private System.Windows.Forms.ToolStripMenuItem fontToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem audioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pauseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem timestampToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem repeatToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip_btnPlayPause;
        private System.Windows.Forms.ToolTip toolTip_btnStop;
        private System.Windows.Forms.ToolTip toolTip_btnRepeat;
        private System.Windows.Forms.ToolTip toolTip_btnTimeStamp;
        private System.Windows.Forms.TextBox txtBoxUserSec;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.CheckBox checkBox_AutoPlayNext;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ToolTip toolTip_PositionTrackBar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCreateLabel;
        private System.Windows.Forms.ListBox lstBoxLabel;
        private System.Windows.Forms.Button btnUpdatelstBoxLabel;
    }
}

