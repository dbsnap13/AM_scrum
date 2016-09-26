using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio;
using NAudio.Wave;

namespace TextPoint
{
    public class AudioTimer
    {
        private System.Timers.Timer timer = new System.Timers.Timer();
        private bool repeat = false;
        private TimeSpan loop = new TimeSpan(0, 0, 3);
        public TimeSpan CurrentTime
        {
            get;
            set;
        }

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            TimeSpan loop2 = new TimeSpan(0, 0, 3);
            CurrentTime = CurrentTime.Subtract(loop2);
        }

        public TimeSpan EnableOrDisableTimer(TimeSpan _currentTime)
        {
            if (!repeat)
            {
                CurrentTime = _currentTime;
                repeat = true;
                timer.Elapsed += timer_Elapsed;
                timer.Interval = 3000;
                timer.Enabled = true;
                _currentTime = CurrentTime;
                return _currentTime;
            }
            else
            {
                repeat = false;
                timer.Enabled = false;
                return _currentTime;
            }
        }
    }
}
