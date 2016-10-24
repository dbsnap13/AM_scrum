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
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using WMPLib;

namespace TextPoint
{
    public partial class FRMMain : Form
    {
        DateTime? date = null;
        int words = 0;
        int wordcount = 0;
        string lastword = string.Empty;
        ClickableObject co = new ClickableObject();
        AudioPlayer _player = new AudioPlayer();


        #region Initialize
        public FRMMain()
        {
            InitializeComponent();
            label_PlayBackPosition.Text = string.Empty;
            checkBox_AutoPlayNext.CheckedChanged += CheckBox_AutoPlayNext_CheckedChanged;
            listBox1.MouseDoubleClick += ListBox1_MouseDoubleClick;

            DisableControls();

        }

        private void DisableControls()
        {
            btnPlay.Enabled = false;
            playToolStripMenuItem.Enabled = false;
            btnPause.Enabled = false;
            pauseToolStripMenuItem.Enabled = false;
            btnStop.Enabled = false;
            stopToolStripMenuItem.Enabled = false;
            btnRepeat.Enabled = false;
            repeatToolStripMenuItem.Enabled = false;
            btnTimeStamp.Enabled = false;
            btnCreateLabel.Enabled = false;
            btnUpdatelstBoxLabel.Enabled = false;
        }

        private void EnableControls()
        {
            btnPlay.Enabled = true;
            playToolStripMenuItem.Enabled = true;
            btnPause.Enabled = true;
            pauseToolStripMenuItem.Enabled = true;
            btnStop.Enabled = true;
            stopToolStripMenuItem.Enabled = true;
            btnRepeat.Enabled = true;
            repeatToolStripMenuItem.Enabled = true;
            btnTimeStamp.Enabled = true;
            btnCreateLabel.Enabled = true;
            btnUpdatelstBoxLabel.Enabled = true;
        }

        private void ListBox1_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _player.PlaySelected(listBox1.SelectedItem.ToString());
            DisplayPosition();
            btnPlay.PerformClick();
        }

        private void CheckBox_AutoPlayNext_CheckedChanged(object sender, EventArgs e)
        {
            _player.AutoPlayNext = checkBox_AutoPlayNext.Checked;
        }

        private void FRMMain_Load(object sender, EventArgs e)
        {
            enhanchedTextBox1.PreviewKeyDown += EnhanchedTextBox1_PreviewKeyDown;
        }

        #endregion

        #region ToolStripMenu
        private void playToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnPlay.PerformClick();
        }

        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnPause.PerformClick();
        }

        private void repeatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnRepeat.PerformClick();
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnStop.PerformClick();
        }

        private void timestampToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnTimeStamp.PerformClick();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        #region Cut, copy & paste Edit Menu
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (enhanchedTextBox1.txtBox.Selection.Text != string.Empty)
                enhanchedTextBox1.txtBox.Copy();

        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            enhanchedTextBox1.txtBox.Paste();
            enhanchedTextBox1.txtBox.CaretPosition = enhanchedTextBox1.txtBox.Selection.End;
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (enhanchedTextBox1.txtBox.Selection.Text != string.Empty)
                enhanchedTextBox1.txtBox.Cut();

        }

        #endregion

        /// <summary>
        /// CAN ONLY OPEN RTF AND MAYBE SOME SOUND FILES I DONT KNOW BECUASE SCHOOL COMP NO HAVE WMP
        /// </summary>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "All files (*.*)|*.*";
            ofd.CheckFileExists = true;
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (ofd.FileName.Contains("rtf"))
                {
                    TextRange range;
                    FileStream fStream;
                    range = new TextRange(enhanchedTextBox1.txtBox.Document.ContentStart, enhanchedTextBox1.txtBox.Document.ContentEnd);
                    fStream = new FileStream(ofd.FileName, FileMode.Open);
                    range.Load(fStream, DataFormats.Rtf);
                    fStream.Close();
                }
                else if (ofd.FileName.Contains("wav") || ofd.FileName.Contains("mp3"))
                {
                    _player = new AudioPlayer(ofd.FileNames.ToList());
                }

                AddToListBox();

                listBox1.SelectedIndex = 0;
                DisplayPosition();
                enhanchedTextBox1.txtBox.Focus();
                EnableControls();
            }
        }

        public void AddToListBox()
        {
            for (int i = 0; i < _player.CurrentPlayList.count; i++)
            {
                listBox1.Items.Add(_player.CurrentPlayList.Item[i].name.ToString());
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Rich Text Files|*.rtf";
            sfd.CheckPathExists = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                TextRange range;
                FileStream fStream;
                range = new TextRange(enhanchedTextBox1.txtBox.Document.ContentStart, enhanchedTextBox1.txtBox.Document.ContentEnd);
                fStream = new FileStream(sfd.FileName, FileMode.Create);
                range.Save(fStream, DataFormats.Rtf);
                fStream.Close();
            }
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
                TimeSpan time = TimeSpan.FromSeconds(_player.CurrentPosition);
                string formattedTimeStamp = string.Empty;
                if (_player.Duration / 60 >= 60)
                {
                    lblCurrent.Text = time.ToString(@"hh\:mm\:ss");
                    formattedTimeStamp = "(" + time.ToString(@"hh\:mm\:ss") + ") ";
                }
                else
                {
                    lblCurrent.Text = time.ToString(@"mm\:ss");
                    formattedTimeStamp = "(" + time.ToString(@"mm\:ss") + ") ";
                }

                if(checkBox_WithName.Checked && !string.IsNullOrEmpty(comboBox_ListOfNames.Text))
                {
                    formattedTimeStamp += " " + comboBox_ListOfNames.SelectedItem.ToString() + ": ";
                }
                
                enhanchedTextBox1.txtBox.CaretPosition.InsertTextInRun(formattedTimeStamp);
                enhanchedTextBox1.txtBox.CaretPosition = enhanchedTextBox1.txtBox.Selection.End;
                enhanchedTextBox1.txtBox.Focus();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void btnRepeat_Click(object sender, EventArgs e)
        {
            try
            {
                if (Int32.Parse(txtBoxUserSec.Text) > 0)
                {
                    _player.EnableOrDisableTimer(Int32.Parse(txtBoxUserSec.Text));
                }
                else
                {
                    MessageBox.Show("Enter a valid number", "You must enter a digit larger than 0.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                enhanchedTextBox1.txtBox.Focus();
            }
            catch(FormatException)
            {
                MessageBox.Show("You must enter seconds to repeat","No user input");
            }

        }

        private void btnPlayPause_Click(object sender, EventArgs e)
        {
            _player.Play();
            timer1.Interval = 500;
            timer1.Tick += Timer1_Tick;
            timer1.Start();
            enhanchedTextBox1.txtBox.Focus();
        }

        private void btn_Pause_Click(object sender, EventArgs e)
        {
            _player.Pause();
            timer1.Interval = 500;
            timer1.Tick += Timer1_Tick;
            timer1.Start();
            enhanchedTextBox1.txtBox.Focus();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            trackBar_PlayBackPosition.Value = (int)_player.CurrentPosition;
            DisplayPosition();
            trackBar_PlayBackPosition.Maximum = (int)_player.Duration; //not efficient, but for now it works..
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _player.Stop();
            timer1.Stop();
            trackBar_PlayBackPosition.Value = 0;
            DisplayPosition();
            enhanchedTextBox1.txtBox.Focus();
        }
        #endregion

        /// <summary>
        /// Kills the audio thread on formclosing.
        /// </summary>
        private void FRMMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_player.SetOutput)
            {
                _player.Dispose();
            }          
        }

        private void EnhanchedTextBox1_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            Keys keyChar = (Keys)KeyInterop.VirtualKeyFromKey(e.Key);
            if (_player.SetOutput)
            {
                switch (keyChar)
                {
                    case Keys.F2:
                        btnPlay.PerformClick();
                        break;
                    case Keys.F3:
                        btnTimeStamp.PerformClick();
                        break;
                    case Keys.F4:
                        btnStop.PerformClick();
                        break;

                    case Keys.F5:
                        btnStop.PerformClick();
                        break;

                    case Keys.F6:
                        ToggleList();
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
        /// Toggled by F6
        /// </summary>
        private void ToggleList()
        {
            if (comboBox_ListOfNames.Items.Count  > comboBox_ListOfNames.SelectedIndex + 1)
            {
                comboBox_ListOfNames.SelectedIndex = comboBox_ListOfNames.SelectedIndex + 1;
            }
            else
                comboBox_ListOfNames.SelectedIndex = 0;
        }

        /// <summary>
        /// Used when on auto speed. NEED TO improve code..
        /// </summary>
        private void CheckRateOK()
        {
            if (wordcount >= 10)
            {
                _player.SetRate(SpeedRate.ConvertRate(1));
                Thread.Sleep(100);
                label_PlayBackRate.Text = SpeedRate.DisplayRate(_player.Rate.ToString());
                trackBar_PlayBackRate.Value = 1;
            }
            else if (wordcount <= 5)
            {
                _player.SetRate(SpeedRate.ConvertRate(-1));
                Thread.Sleep(100);
                label_PlayBackRate.Text = SpeedRate.DisplayRate(_player.Rate.ToString());
                trackBar_PlayBackRate.Value = -1;
            }
        }

        /// <summary>
        /// REMOVE THIS????
        /// </summary>
        private void FRMMain_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (_player.SetOutput)
            {
                switch (e.KeyCode)
                {
                    case Keys.F2:
                        btnPlay.PerformClick();
                        break;
                    case Keys.F3:
                        btnTimeStamp.PerformClick();
                        break;
                    case Keys.F4:
                        btnRepeat.PerformClick();
                        break;
                    case Keys.F5:
                        btnStop.PerformClick();
                        break;
                    default:
                        break;
                }
            }
        }

        private void trackBar_PlayBackRate_Scroll(object sender, EventArgs e)
        {
            if (_player.SetOutput)
            {
                _player.SetRate(SpeedRate.ConvertRate(trackBar_PlayBackRate.Value));
                Thread.Sleep(100);
                label_PlayBackRate.Text = SpeedRate.DisplayRate(_player.Rate.ToString());
            }
            else
            {
                label_PlayBackRate.Text = SpeedRate.DisplayRate(SpeedRate.ConvertRate(trackBar_PlayBackRate.Value).ToString());
            }

            enhanchedTextBox1.txtBox.Focus();
        }

        /// <summary>
        /// Scroll event for playback position
        /// </summary>
        private void trackBar_PlayBackPosition_Scroll(object sender, EventArgs e)
        {
            _player.SetCurrentPosition(trackBar_PlayBackPosition.Value);            
        }

        /// <summary>
        /// Displays the position on label
        /// </summary>
        private void DisplayPosition()
        {
            label_PlayBackPosition.Text = "Playback position: " + _player.CurrentPositionToString + "\nFile: " + _player.CurrentAudioFile + "\nLenght: " + GetLength();
            toolTip_PositionTrackBar.SetToolTip(trackBar_PlayBackPosition, _player.CurrentPositionToString);
        }

        private string GetLength()
        {
            TimeSpan t = TimeSpan.FromSeconds(_player.CurrentAudioFileLenght);
            string formattedTime = string.Empty;
            if (_player.CurrentAudioFileLenght / 60 >= 60)
            {
                formattedTime = "(" + t.ToString(@"hh\:mm\:ss") + ") ";
                return formattedTime;
            }
            else
            {
                formattedTime = "(" + t.ToString(@"mm\:ss") + ") ";
                return formattedTime;
            }
        }

        /// <summary>
        /// Timer event used for auto speed adjustment
        /// </summary>
        private void Timer2_Tick(object sender, EventArgs e)
        {
            wordcount = words;
            timer2.Stop();
            CheckRateOK();
            label1.Text = "Word count: " + wordcount.ToString() + "per 10 sec";
            wordcount = 0;
            words = 0;
        }

        /// <summary>
        /// Only digits allowed in the textbox.
        /// </summary>
        private void txtBoxUserSec_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > 0))
            {
                e.Handled = true;
            }
            enhanchedTextBox1.txtBox.Focus();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnStop.PerformClick();
            _player.PlaySelected(listBox1.SelectedItem.ToString());
            DisplayPosition();
        }

        /// <summary>
        /// Creates a label and adds it to the listbox. Also makes sure the label is not empty or already existing.
        /// </summary>
        private void btnCreateLabel_Click(object sender, EventArgs e)
        {
            var textPoint = enhanchedTextBox1.txtBox.Selection.End;
            string text = enhanchedTextBox1.txtBox.Selection.Text;
            text = text.Trim();
            if(!(lstBoxLabel.Items.Contains(text)) && text != string.Empty)
            {
                co.AddToDic(text, textPoint);
                lstBoxLabel.Items.Add(text);
            }
        }

        /// <summary>
        /// On MouseDoubleClick sets the CaretPosition to the correlating TextPointer for the item in the listbox.
        /// </summary>
        private void lstBoxLabel_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            string txtPtr = (string)lstBoxLabel.SelectedItem;
            enhanchedTextBox1.txtBox.Focus();
            if (!(txtPtr == null))
            {
                enhanchedTextBox1.txtBox.CaretPosition = co.GetPtr(txtPtr);
            }
        }

        /// <summary>
        /// Updates the listbox and removes the correlating value from both the dictionary and the listbox.
        /// </summary>
        private void btnUpdatelstBoxLabel_Click(object sender, EventArgs e)
        {
            TextRange range = new TextRange(enhanchedTextBox1.txtBox.Document.ContentStart, enhanchedTextBox1.txtBox.Document.ContentEnd);
            for (int i = 0; i < lstBoxLabel.Items.Count; i++)
            {
                string textPointer = (string)lstBoxLabel.Items[i];
                if (!range.Text.Contains(textPointer))
                {
                    co.RemoveFromDic(textPointer);
                    lstBoxLabel.Items.RemoveAt(i);
                }
            }
        }

        private void addNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Please enter a name", "Add new name", "");
            if(!string.IsNullOrEmpty(input))
            {
                if (!string.IsNullOrEmpty(input) && !ContainsName(input))
                {
                    comboBox_ListOfNames.Items.Add(input);
                    comboBox_ListOfNames.SelectedIndex = 0;
                }
                else
                if (MessageBox.Show("Name entered is not valid or already in list, would you like to try again?", "Name not valid", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    addNameToolStripMenuItem.PerformClick();
                }
            }
        }

        /// <summary>
        /// Checks if predefined list contains the name
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private bool ContainsName(string input)
        {
            for(int i = 0; i<comboBox_ListOfNames.Items.Count; i++)
            {
                if(input == comboBox_ListOfNames.Items[i].ToString())
                {
                    return true;
                }
            }
            return false;
        }

        private void removeNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Please enter a name to remove", "Remove name", "");
            if(!string.IsNullOrEmpty(input))
            {
                if(ContainsName(input))
                {
                    RemoveName(input);
                }
            }
        }

        /// <summary>
        /// Removes the name from the predefined list
        /// </summary>
        /// <param name="input"></param>
        private void RemoveName(string input)
        {
            for (int i = 0; i < comboBox_ListOfNames.Items.Count; i++)
            {
                if (input == comboBox_ListOfNames.Items[i].ToString())
                {
                    comboBox_ListOfNames.Items.Remove(input);
                    if (comboBox_ListOfNames.Items.Count == 0)
                    {
                        comboBox_ListOfNames.Text = "";
                    }
                    else
                        comboBox_ListOfNames.SelectedIndex = 0;
                }
            }
        }


        /// <summary>
        /// clears all names from the predefined list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            comboBox_ListOfNames.Items.Clear();
            comboBox_ListOfNames.Text = "";
        }
    }
}