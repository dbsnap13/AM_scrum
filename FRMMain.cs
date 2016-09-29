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
using System.Windows.Input;

namespace TextPoint
{
    public partial class FRMMain : Form, ITextPoint
    {
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
                string timeStamp = _player.CurrentTime();
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
        private void btnRepeat_Click(object sender, EventArgs e)
        {
            _player.EnableOrDisableTimer();
        }

        private void btnPlayPause_Click(object sender, EventArgs e)
        {
            _player.PlayPause();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _player.Stop();
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
                    default:
                        break;
                }
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
    }
}

