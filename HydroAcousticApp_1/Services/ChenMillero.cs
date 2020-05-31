using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydroAcousticApp_1.Services
{
    class ChenMillero
    {
        private double t;
        private double salt;
        double a0, a1, a2, a3, b0, b1, c0, c1, c2, c3;
        public double Temp
        {
            get => t; 
            set
            {
                t = value;
                InitValues();
            }
        }
        public double Salt
        {
            get => salt; 
            set
            {
                salt = value;
                InitValues();
            }
        }
        public ChenMillero()
        {
            t = 20;
            salt = 10;
            InitValues();
        }

        private void InitValues()
        {
            a0 = 1.389 - 1.262 * 0.01 * t + 7.164 * Math.Pow(10, -5) * Math.Pow(t, 2) + 2.006 * Math.Pow(10, -6) * Math.Pow(t, 3) - 3.21 * Math.Pow(10, -8) * Math.Pow(t, 4);
            a1 = 9.4742 * Math.Pow(10, -5) - 1.258 * Math.Pow(10, -5) * t - 6.4885 * Math.Pow(10, -8) * Math.Pow(t, 2) + 1.0507 * Math.Pow(10, -8) * Math.Pow(t, 3) - 2.0122 * Math.Pow(10, -10) * Math.Pow(t, 4);
            a2 = -3.9064 * Math.Pow(10, -7) + 9.1041 * Math.Pow(10, -9) * t - 1.6002 * Math.Pow(10, -10) * Math.Pow(t, 2) + 7.988 * Math.Pow(10, -12) * Math.Pow(t, 3);
            a3 = 1.1 * Math.Pow(10, -10) + 6.649 * Math.Pow(10, -12) * t - 3.389 * Math.Pow(10, -13) * Math.Pow(t, 2);

            b0 = -1.922 * Math.Pow(10, -2) - 4.42 * Math.Pow(10, -5) * t;
            b1 = 7.3637 * Math.Pow(10, -5) + 1.7945 * Math.Pow(10, -7) * t;

            c0 = 1402.388 + 5.03711 * t - 5.80852 * Math.Pow(10, -2) * Math.Pow(t, 2) + 3.342 * Math.Pow(10, -4) * Math.Pow(t, 3) - 1.478 * Math.Pow(10, -6) * Math.Pow(t, 4) + 3.1464 * Math.Pow(10, -9) * Math.Pow(t, 5);
            c1 = 0.153563 + 6.8982 * Math.Pow(10, -4) * t - 8.1788 * Math.Pow(10, -6) * Math.Pow(t, 2) + 1.3621 * Math.Pow(10, -7) * Math.Pow(t, 3) + 6.1185 * Math.Pow(10, -10) * Math.Pow(t, 4);
            c2 = 3.126 * Math.Pow(10, -5) - 1.7107 * Math.Pow(10, -6) * t + 2.5974 * Math.Pow(10, -8) * Math.Pow(t, 2) - 2.5335 * Math.Pow(10, -10) * Math.Pow(t, 3) + 1.0405 * Math.Pow(10, -12) * Math.Pow(t, 4);
            c3 = -9.7729 * Math.Pow(10, -9) + 3.8504 * Math.Pow(10, -10) * t - 2.3643 * Math.Pow(10, -12) * Math.Pow(t, 2);
        }

        //public double p;
        //public double t;
        //public double salt;
        //public double soSpeed;

        public double CalcSpeed(double p)
        {
            double a = a0 + p * a1 + Math.Pow(p, 2) * a2 + Math.Pow(p, 3) * a3,
                b = b0 + b1 * p,
                c = c0 + p * c1 + Math.Pow(p, 2) * c2 + Math.Pow(p, 3) * c3,
                d = 1.727 * Math.Pow(10, -3) - 7.8936 * Math.Pow(10, -6) * p;

            return c + a * salt + b * Math.Pow(salt, 1.5) + d * Math.Pow(salt, 2);
        }
    }
}
