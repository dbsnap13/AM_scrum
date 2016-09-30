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
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTimeStamp = new System.Windows.Forms.Button();
            this.lblCurrent = new System.Windows.Forms.Label();
            this.btnRepeat = new System.Windows.Forms.Button();
            this.btnPlayPause = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.trackBar_PlayBackRate = new System.Windows.Forms.TrackBar();
            this.trackBar_PlayBackPosition = new System.Windows.Forms.TrackBar();
            this.label_PlayBackRate = new System.Windows.Forms.Label();
            this.label_PlayBackPosition = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.checkBox_AutoPlayBackRate = new System.Windows.Forms.CheckBox();
            this.enhTxtBox = new System.Windows.Forms.Integration.ElementHost();
            this.enhanchedTextBox1 = new TextPoint.EnhanchedTextBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
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
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(955, 24);
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
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.cutToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // btnTimeStamp
            // 
            this.btnTimeStamp.Location = new System.Drawing.Point(13, 377);
            this.btnTimeStamp.Name = "btnTimeStamp";
            this.btnTimeStamp.Size = new System.Drawing.Size(75, 23);
            this.btnTimeStamp.TabIndex = 2;
            this.btnTimeStamp.Text = "Timestamp";
            this.btnTimeStamp.UseVisualStyleBackColor = true;
            this.btnTimeStamp.Click += new System.EventHandler(this.btnTimeStamp_Click);
            // 
            // lblCurrent
            // 
            this.lblCurrent.AutoSize = true;
            this.lblCurrent.Location = new System.Drawing.Point(442, 377);
            this.lblCurrent.Name = "lblCurrent";
            this.lblCurrent.Size = new System.Drawing.Size(0, 13);
            this.lblCurrent.TabIndex = 3;
            // 
            // btnRepeat
            // 
            this.btnRepeat.Location = new System.Drawing.Point(94, 377);
            this.btnRepeat.Name = "btnRepeat";
            this.btnRepeat.Size = new System.Drawing.Size(75, 23);
            this.btnRepeat.TabIndex = 6;
            this.btnRepeat.Text = "Repeat";
            this.btnRepeat.UseVisualStyleBackColor = true;
            this.btnRepeat.Click += new System.EventHandler(this.btnRepeat_Click);
            // 
            // btnPlayPause
            // 
            this.btnPlayPause.Location = new System.Drawing.Point(175, 377);
            this.btnPlayPause.Name = "btnPlayPause";
            this.btnPlayPause.Size = new System.Drawing.Size(75, 23);
            this.btnPlayPause.TabIndex = 8;
            this.btnPlayPause.Text = "Play/Pause";
            this.btnPlayPause.UseVisualStyleBackColor = true;
            this.btnPlayPause.Click += new System.EventHandler(this.btnPlayPause_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(256, 377);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 9;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // trackBar_PlayBackRate
            // 
            this.trackBar_PlayBackRate.LargeChange = 1;
            this.trackBar_PlayBackRate.Location = new System.Drawing.Point(515, 50);
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
            this.trackBar_PlayBackPosition.Location = new System.Drawing.Point(515, 110);
            this.trackBar_PlayBackPosition.Maximum = 100;
            this.trackBar_PlayBackPosition.Name = "trackBar_PlayBackPosition";
            this.trackBar_PlayBackPosition.Size = new System.Drawing.Size(428, 45);
            this.trackBar_PlayBackPosition.TabIndex = 11;
            this.trackBar_PlayBackPosition.Scroll += new System.EventHandler(this.trackBar_PlayBackPosition_Scroll);
            // 
            // label_PlayBackRate
            // 
            this.label_PlayBackRate.AutoSize = true;
            this.label_PlayBackRate.Location = new System.Drawing.Point(692, 34);
            this.label_PlayBackRate.Name = "label_PlayBackRate";
            this.label_PlayBackRate.Size = new System.Drawing.Size(72, 13);
            this.label_PlayBackRate.TabIndex = 12;
            this.label_PlayBackRate.Text = "Playback rate";
            // 
            // label_PlayBackPosition
            // 
            this.label_PlayBackPosition.AutoSize = true;
            this.label_PlayBackPosition.Location = new System.Drawing.Point(684, 94);
            this.label_PlayBackPosition.Name = "label_PlayBackPosition";
            this.label_PlayBackPosition.Size = new System.Drawing.Size(90, 13);
            this.label_PlayBackPosition.TabIndex = 13;
            this.label_PlayBackPosition.Text = "Playback position";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // checkBox_AutoPlayBackRate
            // 
            this.checkBox_AutoPlayBackRate.AutoSize = true;
            this.checkBox_AutoPlayBackRate.Location = new System.Drawing.Point(545, 34);
            this.checkBox_AutoPlayBackRate.Name = "checkBox_AutoPlayBackRate";
            this.checkBox_AutoPlayBackRate.Size = new System.Drawing.Size(115, 17);
            this.checkBox_AutoPlayBackRate.TabIndex = 14;
            this.checkBox_AutoPlayBackRate.Text = "Auto playback rate";
            this.checkBox_AutoPlayBackRate.UseVisualStyleBackColor = true;
            // 
            // enhTxtBox
            // 
            this.enhTxtBox.Location = new System.Drawing.Point(13, 28);
            this.enhTxtBox.Name = "enhTxtBox";
            this.enhTxtBox.Size = new System.Drawing.Size(496, 334);
            this.enhTxtBox.TabIndex = 7;
            this.enhTxtBox.Text = "elementHost1";
            this.enhTxtBox.Child = this.enhanchedTextBox1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(582, 255);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "label1";
            // 
            // FRMMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 421);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox_AutoPlayBackRate);
            this.Controls.Add(this.label_PlayBackPosition);
            this.Controls.Add(this.label_PlayBackRate);
            this.Controls.Add(this.trackBar_PlayBackPosition);
            this.Controls.Add(this.trackBar_PlayBackRate);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnPlayPause);
            this.Controls.Add(this.enhTxtBox);
            this.Controls.Add(this.btnRepeat);
            this.Controls.Add(this.lblCurrent);
            this.Controls.Add(this.btnTimeStamp);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FRMMain";
            this.Text = "TextPoint";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FRMMain_FormClosing);
            this.Load += new System.EventHandler(this.FRMMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FRMMain_KeyDown);
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
        private System.Windows.Forms.Integration.ElementHost enhTxtBox;
        private System.Windows.Forms.Button btnPlayPause;
        private System.Windows.Forms.Button btnStop;
        private EnhanchedTextBox enhanchedTextBox1;
        private System.Windows.Forms.TrackBar trackBar_PlayBackRate;
        private System.Windows.Forms.TrackBar trackBar_PlayBackPosition;
        private System.Windows.Forms.Label label_PlayBackRate;
        private System.Windows.Forms.Label label_PlayBackPosition;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox checkBox_AutoPlayBackRate;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label1;
    }
}

