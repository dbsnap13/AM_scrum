using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WMPLib;

namespace TextPoint
{
    public class AudioPlayer : IDisposable
    {
        WindowsMediaPlayer Playah = new WindowsMediaPlayer();
        private System.Windows.Forms.Timer tim = new System.Windows.Forms.Timer();
        public bool SetOutput { get; set; }
        public bool Repeat { get; set; }

        public AudioPlayer(string fileName)
        {

            Playah.settings.autoStart = false; //disable the autostart upon load, gets enabled trough PlayPause() below.
            if (fileName == "")
                SetOutput = false;
            else
            {
                Playah.URL = fileName;
                
            }
                
        }

        /// <summary>
        /// Returns the currentposition of the audiofile.
        /// </summary>
        public string CurrentTime()
        {
            return Playah.controls.currentPositionString;
        }

        /// <summary>
        /// Returns the duration of the audiofile.
        /// </summary>
        public string GetDuration()
        {
            return Playah.currentMedia.durationString;
        }

        /// <summary>
        /// Checks playstate to see whether the file is already playing or not.
        /// </summary>
        public void PlayPause()
        {
            if (Playah.playState == WMPPlayState.wmppsPaused)
            {
                Playah.controls.play();
            }
            else if (Playah.playState == WMPPlayState.wmppsPlaying)
            {
                Playah.controls.pause();
            }
            else if (!string.IsNullOrEmpty(Playah.URL) && Playah.settings.autoStart == false)
                Playah.controls.play();
        }

        public void Stop()
        {
            Playah.controls.stop();
        }

        /// <summary>
        /// Hopefully disposes of the player when called upon.
        /// </summary>
        public void Dispose()
        {
            Playah.close();
        }

        #region Timer
        public void EnableOrDisableTimer()
        {
            if (!Repeat)
            {
                Repeat = true;
                tim.Enabled = true;
                tim.Interval = 3000;
                tim.Tick += Tim_Tick;
                tim.Start();
            }
            else
            {
                Repeat = false;
                tim.Enabled = false;
                tim.Stop();
                tim.Dispose();
            }
        }

        private void Tim_Tick(object sender, EventArgs e)
        {
            if (SetOutput)
                Playah.controls.currentPosition = Playah.controls.currentPosition - 3;
        }

        internal void SetRate(double value)
        {
            Playah.settings.rate = value;
        }

        internal string GetCurrentRate()
        {
            return Playah.settings.rate.ToString();
        }

        internal int GetCurrentPosition()
        {
            return (int)Playah.controls.currentPosition;
        }

        /// <summary>
        /// Method used by the trackbar scroll to move position
        /// </summary>
        /// <param name="value"></param>
        internal void SetCurrentPosition(double value)
        {
            Playah.controls.currentPosition = value;
        }

        /// <summary>
        /// Gets the duration of the audio file, used to by the trackbar to resize.
        /// </summary>
        /// <returns></returns>
        internal double GetDurationDouble()
        {
            return Playah.currentMedia.duration;
        }

        internal double CurrentTimeMinutes()
        {
            return Playah.controls.currentPosition;
        }

        #endregion
    }
}
