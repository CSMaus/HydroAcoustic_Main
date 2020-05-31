using Caliburn.Micro;
using HydroAcousticApp_1.ViewModels.Signals;
using OxyPlot.Wpf;
using System;
using System.Globalization;
using System.Windows.Data;

namespace HydroAcousticApp_1.Converters
{
    class SignalViewModelToLineSeries : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is BaseSignalViewModel signalVM && targetType == typeof(LineSeries))
            {
                var result = new LineSeries();
                var binding = new Binding(nameof(BaseSignalViewModel.SignalPoints));
                binding.Source = signalVM;
                binding.Mode = BindingMode.OneWay;
                binding.NotifyOnSourceUpdated = true;
                BindingOperations.SetBinding(result, LineSeries.ItemsSourceProperty, binding);
                //result.SetBinding(LineSeries.ItemsSourceProperty, binding);
                return result;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
