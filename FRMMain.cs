using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio;
using NAudio.Wave;

namespace TextPoint
{
    public partial class FRMMain : Form, ITextPoint
    {
        WavAudio wav = new WavAudio();
        Mp3Audio mp3 = new Mp3Audio();

        #region Initialize
        public FRMMain()
        {
            InitializeComponent();
        }

        private void FRMMain_Load(object sender, EventArgs e)
        {
            initiateExtensions();
        }

        private void initiateExtensions()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var dlls = Directory.GetFiles(path, "*.dll");
            foreach (var dll in dlls)
            {
                Assembly assm = Assembly.LoadFile(dll);
                foreach (var type in assm.GetTypes())
                {
                    if ((typeof(IExtension).IsAssignableFrom(type)) && !type.IsInterface)
                    {
                        var extensionInstance = (IExtension)Activator.CreateInstance(type);
                        extensionInstance.Initialize(this);
                        string title = extensionInstance.GetTitle();
                        ToolStripItem tsi = new ToolStripMenuItem(title);
                        tsi.Click += (o, e) => { extensionInstance.Execute(); };
                        toolsToolStripMenuItem.DropDownItems.Add(tsi);
                    }
                }
            }
        }

        void tsi_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region ToolStripMenu
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        #region Cut, copy & paste Edit Menu
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (enhanchedTextBox1.txtBox.SelectedText != string.Empty)
                Clipboard.SetData(DataFormats.Text, enhanchedTextBox1.txtBox.SelectedText);
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int position = enhanchedTextBox1.txtBox.SelectionStart;
            enhanchedTextBox1.txtBox.Text = enhanchedTextBox1.txtBox.Text.Insert(position, Clipboard.GetText());
            enhanchedTextBox1.txtBox.SelectionStart = enhanchedTextBox1.txtBox.Text.Length -1;
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (enhanchedTextBox1.txtBox.SelectedText != string.Empty)
                Clipboard.SetData(DataFormats.Text, enhanchedTextBox1.txtBox.SelectedText);
            enhanchedTextBox1.txtBox.SelectedText = string.Empty;
        }
        #endregion

        /// <summary>
        /// Allows a user to open a file of the type Wave, Text or Mp3.
        /// </summary>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Wave File (*.wav)|*.wav| Text files (*.txt)|*.txt| Mp3 File (*.mp3)|*.mp3";
            ofd.CheckFileExists = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (ofd.FileName.Contains("txt"))
                {
                    enhTxtBox.Text = File.ReadAllText(ofd.FileName);
                }
                else if (ofd.FileName.Contains("wav"))
                {
                    wav.CreateWav(ofd.FileName);
                    wav.PlayWav();
                    wav.AudioTypeWav = true;
                }
                else if (ofd.FileName.Contains("mp3"))
                {
                    mp3.CreateMp3(ofd.FileName);
                    mp3.PlayMp3();
                    mp3.AudioTypeMp3 = true;
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text files (*.txt)|*.txt";
            sfd.CheckPathExists = true;
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                File.WriteAllText(sfd.FileName, enhTxtBox.Text);
            }
        }
        #endregion

        #region SetExtensibility
        public void SetBackgroundColor(Color col)
        {
            enhTxtBox.BackColor = col;
        }

        public void SetForegroundColor(Color col)
        {
            enhTxtBox.ForeColor = col;
        }

        public void SetFont(Font font)
        {
            enhTxtBox.Font = font;
        }

        public string GetText()
        {
            return enhTxtBox.Text;
        }

        public void SetText(string text)
        {
            enhTxtBox.Text = text;
        }
        #endregion

        #region Buttons
        /// <summary>
        /// Sets and inserts the timestamp into the text.
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            if (wav.AudioTypeWav && wav.CheckOutput)
            {
                string timeStamp = wav.CurrentWavTime().ToString("mm\\:ss");
                lblCurrent.Text = timeStamp;
                string formattedTimeStamp = " {" + timeStamp + "} ";

                var selectionIndex = enhanchedTextBox1.txtBox.SelectionStart;
                enhanchedTextBox1.txtBox.Focus();
                enhanchedTextBox1.txtBox.Text = enhanchedTextBox1.txtBox.Text.Insert(selectionIndex, formattedTimeStamp);
                enhanchedTextBox1.txtBox.SelectionStart = enhanchedTextBox1.txtBox.Text.Length - 1;
            }
            else if(mp3.AudioTypeMp3 && mp3.CheckOutput)
            {
                string timeStamp = mp3.CurrentMp3Time().ToString("mm\\:ss");
                lblCurrent.Text = timeStamp;
                string formattedTimeStamp = " {" + timeStamp + "} ";

                var selectionIndex = enhanchedTextBox1.txtBox.SelectionStart;
                enhanchedTextBox1.txtBox.Focus();
                enhanchedTextBox1.txtBox.Text = enhanchedTextBox1.txtBox.Text.Insert(selectionIndex, formattedTimeStamp);
                enhanchedTextBox1.txtBox.SelectionStart = enhanchedTextBox1.txtBox.Text.Length - 1;
            }
        }

        /// <summary>
        /// Activates the audiotimer, currently set to 3 secs. 'wav' is in this case arbitrary, might as well be 'mp3'.
        /// </summary>
        private void button3_Click(object sender, EventArgs e)
        {
            if (wav.AudioTypeWav && wav.CheckOutput)
                wav.ActivateAudioTimer();
            else mp3.ActivateAudioTimer();
        }
        #endregion

        /// <summary>
        /// Kills the audio thread on formclosing.
        /// </summary>
        private void FRMMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (wav.AudioTypeWav && wav.CheckOutput)
                wav.DisposeWav();
            else if(mp3.AudioTypeMp3 && mp3.CheckOutput)
                mp3.DisposeMp3();
            else { }
        }

        /// <summary>
        /// Checks whether the audio type is Mp3 or Wave, then executes relevant commands on keydowns.
        /// </summary>
        private void FRMMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (wav.AudioTypeWav && wav.CheckOutput)
            {
                switch (e.KeyCode)
                {
                    case Keys.F2:
                        int dur = wav.PlayOrPauseWav();
                        lblCurrent.Text = ((dur % 60)).ToString("00.00");
                        break;
                    case Keys.F3:
                        button1_Click(sender, e);
                        break;
                    case Keys.F4:
                        button3_Click(sender, e);
                        break;
                    default:
                        break;
                }
            }
            else if (mp3.AudioTypeMp3 && mp3.CheckOutput)
            {
                switch (e.KeyCode)
                {
                    case Keys.F2:
                        int dur = mp3.PlayOrPauseMp3();
                        lblCurrent.Text = ((dur % 60)).ToString("00.00");
                        break;
                    case Keys.F3:
                        button1_Click(sender, e);
                        break;
                    case Keys.F4:
                        button3_Click(sender, e);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}

