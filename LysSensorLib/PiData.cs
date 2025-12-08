using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LysSensorLib
{
    public class PiData
    {
        public int Id { get; set; }
        public int LightValue { get; set; }

        public PiData(int lightValue)
        {
            LightValue = lightValue;
        }
    }
}
