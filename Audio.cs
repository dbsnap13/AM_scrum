using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio;
using NAudio.Wave;

namespace TextPoint
{
    public abstract class Audio<T>
    {
        public WaveFileReader wave { get; set; }
        public Mp3FileReader mp3 { get; set; }
        public DirectSoundOut output { get; set; }

        /// <summary>
        /// Possibly exchange both Wave/MP3 FileReaders with an AudioFileReader!!!
        /// </summary>

        #region Timer related objects
        TimeSpan loop = new TimeSpan(0, 0, 3);
        private System.Timers.Timer timer = new System.Timers.Timer();
        private bool repeat = false;
        #endregion

        #region Properties
        public bool AudioTypeWav
        {
            get; set;
        }

        public bool AudioTypeMp3
        {
            get; set;
        }

        public bool CheckOutput
        {
            get; set;
        }
        #endregion

        /// <summary>
        /// Sets the playbackstate to either play or pause.
        /// </summary>
        public void PlayOrPauseAudio()
        {
            if (output.PlaybackState == PlaybackState.Playing) output.Pause();
            else if (output.PlaybackState == PlaybackState.Paused)
            {
                output.Play();
            }
        }

        /// <summary>
        /// Disposes the audio, i.e. kills the thread.
        /// </summary>
        public void DisposeAudio()
        {
            if (CheckOutput)
            {
                if (output.PlaybackState == PlaybackState.Playing) output.Stop();
                output.Dispose();
            }
        }

        /// <summary>
        /// Activates a new AudioTimer or disables the current one.
        /// </summary>
        public void ActivateAudioTimer()
        {
            EnableOrDisableTimer();
        }

        #region Timer Event and Function
        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (AudioTypeWav)
                wave.CurrentTime = wave.CurrentTime.Subtract(loop);
            else if (AudioTypeMp3)
                mp3.CurrentTime = mp3.CurrentTime.Subtract(loop);
        }

        private void EnableOrDisableTimer()
        {
            if (!repeat)
            {
                repeat = true;
                timer.Elapsed += timer_Elapsed;
                timer.Interval = 3000;
                timer.Enabled = true;
            }
            else
            {
                repeat = false;
                timer.Enabled = false;
            }
        }
        #endregion
    }
}
