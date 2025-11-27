using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LysSensorLib
{
    public class Alarm
    {
        public string Day { get; set; }
        public TimeOnly Time { get; set; }

        public Alarm(string day, TimeOnly time)
        {
            Day = day;
            Time = time;
        }
    }
}
