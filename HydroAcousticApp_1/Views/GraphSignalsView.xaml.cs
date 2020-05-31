using Caliburn.Micro;
using HydroAcousticApp_1.Converters;
using HydroAcousticApp_1.ViewModels;
using HydroAcousticApp_1.ViewModels.Signals;
using OxyPlot.Wpf;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace HydroAcousticApp_1.Views
{
    /// <summary>
    /// Логика взаимодействия для GraphSignalsView.xaml
    /// </summary>
    public partial class GraphSignalsView : UserControl
    {
        SignalViewModelToLineSeries _converter;
        public GraphSignalsView()
        {
            InitializeComponent();
            _converter = (SignalViewModelToLineSeries)FindResource("SignalViewModelToLineSeries");
            var vm = IoC.Get<SignalParamsViewModel>();
            vm.Signals.CollectionChanged += Signals_CollectionChanged;
            foreach (var signal in vm.Signals)
                MakeLineSeries(signal);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void Signals_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if(e.NewItems != null)
                foreach (var signal in e.NewItems.OfType<BaseSignalViewModel>())
                    MakeLineSeries(signal);
            if(e.OldItems != null)
                foreach (var signal in e.OldItems.OfType<BaseSignalViewModel>())
                    RemoveLineSeries(signal);
        }
        private void MakeLineSeries(BaseSignalViewModel vm)
        {
            var series = (LineSeries)_converter.Convert(vm, typeof(LineSeries), null, CultureInfo.InvariantCulture);
            if (series == null)
                return;
            series.Tag = vm;
            Plot.Series.Add(series);
        }
        private void RemoveLineSeries(BaseSignalViewModel vm)
        {
            var series = Plot.Series.FirstOrDefault(x => x.Tag == vm);
            Plot.Series.Remove(series);
        }
    }
}
