using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using HydroAcousticApp_1.Models;
using HydroAcousticApp_1.Services;

namespace HydroAcousticApp_1.ViewModels
{
    public class WaterParamsViewModel : Screen
    {
        private float _depth = 5000;
        private int _meters;
        public double Salt 
        {
            get { return IoC.Get<ChenMillero>().Salt; }
            set 
            {
                IoC.Get<ChenMillero>().Salt = value;
                NotifyOfPropertyChange();
            }
        }
        public double Temp
        {
            get { return IoC.Get<ChenMillero>().Temp; }
            set
            {
                IoC.Get<ChenMillero>().Temp = value;
                NotifyOfPropertyChange();
            }
        }
        public float Depth
        {
            get { return _depth; }
            set
            {
                _depth = value;
                NotifyOfPropertyChange();
            }
        }

        public WaterParamsViewModel()
        {
            DisplayName = "Water params";
        }
        //bool b = Double.TryParse(Salt, s);
    }
}
