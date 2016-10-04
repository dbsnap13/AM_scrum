using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace TextPoint
{
    public partial class FRMMain : Form, ITextPoint
    {
        //variabes for auto speed adjustment
        DateTime? date = null;
        int words = 0;
        int wordcount = 0;
        string lastword = string.Empty;

        AudioPlayer _player = new AudioPlayer("");


        #region Initialize
        public FRMMain()
        {
            InitializeComponent();
        }

        private void FRMMain_Load(object sender, EventArgs e)
        {
            initiateExtensions();
            enhanchedTextBox1.PreviewKeyDown += enhanchedTextBox1_PreviewKeyDown;
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
                    enhanchedTextBox1.txtBox.Text = File.ReadAllText(ofd.FileName);
                }
                else if (ofd.FileName.Contains("wav")||ofd.FileName.Contains("mp3"))
                {
                    _player = new AudioPlayer(ofd.FileName);
                    _player.SetOutput = true;
                }
            }
        }

        private void UpdateTrackBarLength(int lenght)
        {
            trackBar_PlayBackPosition.Maximum = lenght;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text files (*.txt)|*.txt| Rich Text Files|*.rtf | Microsoft Document|*.doc";
            sfd.CheckPathExists = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(sfd.FileName, enhanchedTextBox1.txtBox.Text);
            }
        }
        #endregion

        #region SetExtensibility
        public void SetBackgroundColor(Color col)
        {
            //enhTxtBox.BackColor = col;
        }

        public void SetForegroundColor(Color col)
        {
            //enhTxtBox.ForeColor = col;
        }

        public void SetFont(Font font)
        {
            //enhTxtBox.Font = font;
        }

        public string GetText()
        {
            return enhanchedTextBox1.txtBox.Text;
        }

        public void SetText(string text)
        {
            enhanchedTextBox1.txtBox.Text = text;
        }
        #endregion

        #region Buttons
        /// <summary>
        /// Sets and inserts the timestamp into the text.
        /// </summary>
        private void btnTimeStamp_Click(object sender, EventArgs e)
        {
            if (_player.SetOutput)
            {

                TimeSpan time = TimeSpan.FromSeconds(_player.CurrentTimeMinutes());
                string str = time.ToString(@"hh\:mm\:ss");

                //string timeStamp = _player.CurrentTime();
                lblCurrent.Text = str;
                string formattedTimeStamp = " [" + str + "] ";

                var selectionIndex = enhanchedTextBox1.txtBox.SelectionStart;
                enhanchedTextBox1.txtBox.Focus();
                enhanchedTextBox1.txtBox.Text = enhanchedTextBox1.txtBox.Text.Insert(selectionIndex, formattedTimeStamp);
                enhanchedTextBox1.txtBox.SelectionStart = enhanchedTextBox1.txtBox.Text.Length - 1;
            }
        }

        /// <summary>
        /// Activates the audiotimer, currently set to 3 secs. 'wav' is in this case arbitrary, might as well be 'mp3'.
        /// </summary>
        private void btnRepeat_Click(object sender, EventArgs e)
        {
            _player.EnableOrDisableTimer();
        }

        private void btnPlayPause_Click(object sender, EventArgs e)
        {
            _player.PlayPause();
            timer1.Interval = 500;
            timer1.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _player.Stop();
            timer1.Stop();
            label_PlayBackPosition.Text = "Playback position: 00:00";
            trackBar_PlayBackPosition.Value = 0;
        }
        #endregion

        /// <summary>
        /// Kills the audio thread on formclosing.
        /// </summary>
        private void FRMMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            _player.Dispose();
        }


        void enhanchedTextBox1_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            Keys keyChar = (Keys)KeyInterop.VirtualKeyFromKey(e.Key);
            if (_player.SetOutput)
            {
                switch (keyChar)
                {
                    case Keys.F2:
                        _player.PlayPause();
                        lblCurrent.Text = _player.GetDuration();
                        break;
                    case Keys.F3:
                        btnTimeStamp_Click(sender, e);
                        break;
                    case Keys.F4:
                        btnRepeat_Click(sender, e);
                        break;

                    case Keys.Space:
                        if (!string.IsNullOrEmpty(lastword))
                        {
                            lastword = string.Empty;
                            words++;

                            if (date == null)
                            {
                                date = DateTime.Now;
                                timer2.Interval = 10000;
                                timer2.Tick += Timer2_Tick;
                                timer2.Enabled = true;
                            }
                        }
                        break;
                    default:
                        lastword += keyChar.ToString();
                        break;
                }
            }
        }

        /// <summary>
        /// Used when on auto speed. NEED TO improve code..
        /// </summary>
        private void CheckRateOK()
        {
            if(wordcount >= 10)
            {
                _player.SetRate(1.25);
                Thread.Sleep(100);
                label_PlayBackRate.Text =  "Playback rate: " + _player.GetCurrentRate() + "x speed";
                trackBar_PlayBackRate.Value = 1;


            }
            else if(wordcount <= 5)
            {
                _player.SetRate(0.75);
                Thread.Sleep(100);
                label_PlayBackRate.Text = "Playback rate: " + _player.GetCurrentRate() + "x speed";
                trackBar_PlayBackRate.Value = -1;
            }
        }

        /// <summary>
        /// Checks whether the audio type is Mp3 or Wave, then executes relevant commands on keydowns.
        /// </summary>
        private void FRMMain_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (_player.SetOutput)
            {
                switch (e.KeyCode)
                {
                    case Keys.F2:
                        _player.PlayPause();
                        lblCurrent.Text = _player.GetDuration();
                        break;
                    case Keys.F3:
                        btnTimeStamp_Click(sender, e);
                        break;
                    case Keys.F4:
                        btnRepeat_Click(sender, e);
                        break;
                    default:
                        break;
                }
            }
        }

        private void trackBar_PlayBackRate_Scroll(object sender, EventArgs e)
        {
            _player.SetRate(ConvertRate(trackBar_PlayBackRate.Value));
            Thread.Sleep(100); //update label properly
            label_PlayBackRate.Text = "Playback rate: " + _player.GetCurrentRate() + "x speed";
        }

        private double ConvertRate(int value)
        {
            switch(value)
            {
                case -3:
                    return 0.25;
                case -2:
                    return 0.50;
                case -1:
                    return 0.75;
                case 0:
                    return 1;
                case 1:
                    return 1.25;
                case 2:
                    return 1.50;
                case 3:
                    return 1.75;
                case 4:
                    return 2;
                default:
                    return 1;
            }
        }

        private void trackBar_PlayBackPosition_Scroll(object sender, EventArgs e)
        {
            _player.SetCurrentPosition(trackBar_PlayBackPosition.Value);
        }

        /// <summary>
        /// Timer event for the position of trackbar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            trackBar_PlayBackPosition.Value = _player.GetCurrentPosition();
            DisplayPosition();
            trackBar_PlayBackPosition.Maximum = (int)_player.GetDurationDouble(); //not efficient, but for now it works..
        }

        /// <summary>
        /// Displays the position on label
        /// </summary>
        private void DisplayPosition()
        {
            label_PlayBackPosition.Text = "Playback position: " + _player.CurrentTime();
        }

        /// <summary>
        /// Timer event used for auto speed adjustment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer2_Tick(object sender, EventArgs e)
        {
            wordcount = words;
            //timer2.Stop();
            CheckRateOK();
            label1.Text = "Word count: " + wordcount.ToString() + "per 10 sec";
            wordcount = 0;
            words = 0;
        }
    }
}

