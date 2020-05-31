using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using HydroAcousticApp_1.Services;
using HydroAcousticApp_1.ViewModels.Signals;

namespace HydroAcousticApp_1.ViewModels
{
    class SignalParamsViewModel : Screen
    {
        private double _time = 100;
        public IObservableCollection<BaseSignalViewModel> Signals { get; } = new BindableCollection<BaseSignalViewModel>();
        public SignalParamsViewModel()
        {
            DisplayName = "Signal params";
        }

        public double Time
        {
            get => _time;
            set
            {
                _time = value;
                NotifyOfPropertyChange();
            }
        }
        public void Plus()
        {
            var signal = new SineWaveSignalViewModel(this);
            Signals.Add(signal);
        }

        internal void Remove(BaseSignalViewModel sineWaveSignalViewModel)
        {
            Signals.Remove(sineWaveSignalViewModel);
        }
    }
}
