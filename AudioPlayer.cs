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
        WindowsMediaPlayer Playah;
        private System.Windows.Forms.Timer tim;
        public bool SetOutput { get; set; }
        private bool Repeat { get; set; }

        /// <summary>
        /// Constructor takes filename
        /// </summary>
        public AudioPlayer(string fileName)
        {
            if (fileName == "")
                SetOutput = false;
            else
            {
                Playah = new WindowsMediaPlayer();
                Playah.settings.autoStart = false; //disable the autostart upon load, gets enabled trough PlayPause() below.
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
        /// Returns the duration of the audiofile as string.
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

        /// <summary>
        /// Stop
        /// </summary>
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
        /// <summary>
        /// delay represents user input in seconds. A new timer is created on each enable which is BAD. However, otherwise it bugs out.
        /// </summary>
        public void EnableOrDisableTimer(int delay)
        {
            if (!Repeat)
            {
                Playah.controls.currentPosition = Playah.controls.currentPosition - delay;
                tim = new System.Windows.Forms.Timer();
                tim.Tick += (object sender, EventArgs e) => Tim_Tick(sender, e, delay);
                tim.Interval = delay * (1000);               
                tim.Start();
                Repeat = true;
            }
            else
            {
                Repeat = false;
                tim.Stop();
                tim.Dispose();
            }
        }

        private void Tim_Tick(object sender, EventArgs e, int delay)
        {
            if (SetOutput)
                Playah.controls.currentPosition = Playah.controls.currentPosition - delay;
        }
        #endregion

        /// <summary>
        /// Sets a new playback rate
        /// </summary>
        internal void SetRate(double value)
        {
            Playah.settings.rate = value;
        }

        /// <summary>
        /// Gets current playback speed
        /// </summary>
        internal string GetCurrentRate()
        {
            return Playah.settings.rate.ToString();
        }

        /// <summary>
        /// Gets the current position/timestamp of the audio
        /// </summary>
        internal double GetCurrentPosition()
        {
            return Playah.controls.currentPosition;
        }

        /// <summary>
        /// Method used by the trackbar scroll to move position
        /// </summary>
        internal void SetCurrentPosition(double value)
        {
            Playah.controls.currentPosition = value;
        }

        /// <summary>
        /// Gets the duration of the audio file, used to by the trackbar to resize.
        /// </summary>
        internal double GetDurationDouble()
        {
            return Playah.currentMedia.duration;
        }
    }
}
