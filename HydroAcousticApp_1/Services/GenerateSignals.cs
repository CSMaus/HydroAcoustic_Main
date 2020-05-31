using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydroAcousticApp_1.Services
{
    class GenerateSignals
    {
        public double Amplitude { get; set; } = 5;
        public double Frequency { get; set; } = 2;
        public double Phase { get; set; } = Math.PI / 4;

        public double SineGenerate(double time)
        {
            return Amplitude*Math.Sin(0.5*time*Frequency/Math.PI + Phase);
        }
    }
}
