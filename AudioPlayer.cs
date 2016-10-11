using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace TextPoint
{
    public class AudioPlayer : IDisposable
    {
        #region Reference variables
        WindowsMediaPlayer Playah;
        private System.Windows.Forms.Timer tim;
        #endregion

        #region Properties
        public bool SetOutput { get; private set; }
        private bool Repeat { get; set; }
        public bool AutoPlayNext { get; set; }
        public double Rate
        {
            get
            {
                return Playah.settings.rate;
            }
            private set
            {
                try
                {
                    if (value <= 2.00 && value >= 0.25)
                    {
                        Playah.settings.rate = value;
                    }
                    else
                        throw new ArgumentOutOfRangeException("Only values between 0.25 and 2.00 are allowed");
                }
                catch(ArgumentOutOfRangeException e)
                {
                    MessageBox.Show(e.Message);
                }

            }
        }
        public double CurrentPosition
        {
            get
            {
                return Playah.controls.currentPosition;
            }
            set
            {
                try
                {
                    if (value <= Playah.currentMedia.duration)
                    {
                        Playah.controls.currentPosition = value;
                    }
                    else
                        throw new ArgumentOutOfRangeException("The value of the position cannot be greater than the duration");
                }
                catch(ArgumentOutOfRangeException e)
                {
                    MessageBox.Show(e.Message);
                }

            }
        }
        private double Duration
        {
            get
            {
                return Playah.currentMedia.duration;
            }
        }
        private string CurrentPositionToString
        {
            get
            {
                return Playah.controls.currentPositionString;
            }
        }
        private string DurationToString
        {
            get
            { return Playah.currentMedia.durationString;
            }
        }
        public IWMPPlaylist CurrentPlayList
        {
            get { return Playah.currentPlaylist; }
            private set { Playah.currentPlaylist = value; }
        }
        public WMPPlayState PlayState
        {
            get
            {
                return Playah.playState;
            }
        }

        #endregion

        #region Constructors
        //Default consructor
        public AudioPlayer()
        {
            SetOutput = false;
        }
        /// <summary>
        /// Constructor takes filename
        /// </summary>
        public AudioPlayer(List<string> fileName)
        {
            SetAudioSettings();
            ConnectPlayList(GeneratePlayList(fileName));
        }
        #endregion

        #region Initialize Audio Player
        /// <summary>
        /// Sets the generated playlist to be the current playlist of the WMP.
        /// </summary>
        /// <param name="playlist"></param>
        private void ConnectPlayList(IWMPPlaylist playlist)
        {
            CurrentPlayList = playlist;
        }

        /// <summary>
        /// Sets default audio player settings.
        /// </summary>
        private void SetAudioSettings()
        {
            Playah = new WindowsMediaPlayer();
            Playah.PlayStateChange += Playah_PlayStateChange;
            Playah.settings.autoStart = false;
            SetOutput = true;
        }

        /// <summary>
        /// Generates a playlist.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private IWMPPlaylist GeneratePlayList(List<string> fileName)
        {
            var playlist = Playah.playlistCollection.newPlaylist("Playlist");
            foreach (string str in fileName)
            {
                var audio = Playah.newMedia(str);
                playlist.appendItem(audio);
            }
            return playlist;
        }
        #endregion

        #region Playstate
        /// <summary>
        /// Checks if user has set auto play next checkbox
        /// </summary>
        /// <param name="NewState"></param>
        private void Playah_PlayStateChange(int NewState)
        {
            if (!AutoPlayNext && NewState == (int)WMPPlayState.wmppsMediaEnded)
            {
                Playah.close();
            }
        }

        #endregion

        #region Play/Pause/Stop
        /// <summary>
        /// Play
        /// </summary>
        public void Play()
        {
            if (PlayState == WMPPlayState.wmppsReady || PlayState == WMPPlayState.wmppsStopped || PlayState == WMPPlayState.wmppsPaused)
            {
                Playah.controls.play();
            }
        }

        /// <summary>
        /// Pause
        /// </summary>
        public void Pause()
        {
            if(PlayState == WMPPlayState.wmppsPlaying)
            {
                Playah.controls.pause();
            }
        }

        /// <summary>
        /// Stop
        /// </summary>
        public void Stop()
        {
            Playah.controls.stop();
        }
        #endregion

        #region Timer
        /// <summary>
        /// delay represents user input in seconds. A new timer is created on each enable which is BAD. However, otherwise it bugs out.
        /// </summary>
        public void EnableOrDisableTimer(int delay)
        {
            if (!Repeat)
            {
                CurrentPosition = CurrentPosition - delay;
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
                CurrentPosition = CurrentPosition - delay;
        }
        #endregion

        #region Time/Duration/Position/Rate
        /// <summary>
        /// Sets a new playback rate
        /// </summary>
        internal void SetRate(double value)
        {
            Rate = value;
        }

        /// <summary>
        /// Gets current playback speed
        /// </summary>
        internal string GetCurrentRate()
        {
            return Rate.ToString();
        }

        /// <summary>
        /// Gets the current position/timestamp of the audio
        /// </summary>
        internal double GetCurrentPosition()
        {
            return CurrentPosition;
        }

        /// <summary>
        /// Method used by the trackbar scroll to move position
        /// </summary>
        internal void SetCurrentPosition(double value)
        {
            CurrentPosition = value;
        }

        /// <summary>
        /// Gets the duration of the audio file, used to by the trackbar to resize.
        /// </summary>
        internal double GetDurationDouble()
        {
            return Duration;
        }

        /// <summary>
        /// Returns the currentposition of the audiofile.
        /// </summary>
        public string CurrentTime()
        {
            return CurrentPositionToString;
        }

        /// <summary>
        /// Returns the duration of the audiofile as string.
        /// </summary>
        public string GetDuration()
        {
            return DurationToString;
        }
        #endregion

        #region Disposing
        /// <summary>
        /// Hopefully disposes of the player when called upon.
        /// </summary>
        public void Dispose()
        {
            Playah.close();
        }
        #endregion


        public void PlaySelected(string name)
        {
            for(int i = 0; i<CurrentPlayList.count; i++)
            {
                if(CurrentPlayList.Item[i].name == name)
                {
                    var audiofile = CurrentPlayList.Item[i];
                    Playah.controls.playItem(audiofile);
                }
            }
        }
    }
}
