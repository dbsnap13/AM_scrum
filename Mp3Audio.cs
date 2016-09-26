using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio;
using NAudio.Wave;

namespace TextPoint
{
    public class Mp3Audio : Audio<Mp3FileReader>
    {
        /// <summary>
        /// Initializes a mp3 file and sets CheckOutput to true
        /// </summary>
        public void CreateMp3(string fileName)
        {
            mp3 = new Mp3FileReader(fileName);
            output = new DirectSoundOut();
            output.Init(new WaveChannel32(mp3));
            CheckOutput = true;
        }

        public int PlayMp3()
        {
            output.Play();
            return mp3.CurrentTime.Duration().Minutes;
        }

        public int PlayOrPauseMp3()
        {
            PlayOrPauseAudio();
            return mp3.CurrentTime.Duration().Minutes;
        }

        public void DisposeMp3()
        {
            DisposeAudio();
            mp3.Dispose();
        }

        public TimeSpan CurrentMp3Time()
        {
            return mp3.CurrentTime;
        }
    }
}
