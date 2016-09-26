using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio;
using NAudio.Wave;

namespace TextPoint
{
    public class WavAudio : Audio<WaveFileReader>
    {
        /// <summary>
        /// Initializes a wave file and sets CheckOutput to true
        /// </summary>
        public void CreateWav(string fileName)
        {
            wave = new WaveFileReader(fileName);
            output = new DirectSoundOut();
            output.Init(new WaveChannel32(wave));
            CheckOutput = true;
        }

        /// <summary>
        /// Used for initializing the song the first time
        /// </summary>
        public int PlayWav()
        {
            output.Play();
            return wave.CurrentTime.Duration().Minutes;
        }

        /// <summary>
        /// Used for switching between play/pause
        /// </summary>
        public int PlayOrPauseWav()
        {
            PlayOrPauseAudio();
            return wave.CurrentTime.Duration().Minutes;
        }

        public void DisposeWav()
        {
            DisposeAudio();
            wave.Dispose();
        }

        public TimeSpan CurrentWavTime()
        {
            return wave.CurrentTime;
        }
    }
}
