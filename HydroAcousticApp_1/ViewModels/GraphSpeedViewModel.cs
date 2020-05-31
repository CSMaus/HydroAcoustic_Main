using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using HydroAcousticApp_1.Services;
using OxyPlot;

namespace HydroAcousticApp_1.ViewModels
{
    class GraphSpeedViewModel : Screen 
    {
        public GraphSpeedViewModel()
        {
            DisplayName = "Speed";
            Points = new BindableCollection<DataPoint>();
        }

        public IObservableCollection<DataPoint> Points { get; }

        public void Calculate()
        {
            Points.Clear();
            var depthMax = IoC.Get<WaterParamsViewModel>().Depth;
            var solver = IoC.Get<ChenMillero>();
            for(var x = 1; x < depthMax; x+=100)
                Points.Add(new DataPoint(solver.CalcSpeed(x), x));
        }

    }
}
