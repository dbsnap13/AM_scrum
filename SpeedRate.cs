using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextPoint
{
    public static class SpeedRate
    {
        public static double ConvertRate(int value)
        {
            switch (value)
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
        public static string DisplayRate(string text)
        {
            return String.Format("Playback rate: {0}x speed", text);
        }
    }
}
