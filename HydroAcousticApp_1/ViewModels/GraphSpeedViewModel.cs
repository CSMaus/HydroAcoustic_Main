using System.Windows;
using Caliburn.Micro;
using HydroAcousticApp_1.Services;
using LiveCharts;
using LiveCharts.Defaults;

namespace HydroAcousticApp_1.ViewModels
{
    class GraphSpeedViewModel : Screen 
    {
        public GraphSpeedViewModel()
        {
            DisplayName = "Speed";
            Points = new ChartValues<ObservablePoint>();
        }

        public ChartValues<ObservablePoint> Points { get; }

        public void Calculate()
        {
            Points.Clear();
            var depthMax = IoC.Get<WaterParamsViewModel>().Depth;
            var solver = IoC.Get<ChenMillero>();
            for (var x = 1; x < depthMax; x += 100)
                Points.Add(new ObservablePoint(solver.CalcSpeed(x), x));
        }

    }
}
