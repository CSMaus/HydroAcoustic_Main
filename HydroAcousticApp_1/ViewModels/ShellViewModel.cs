using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HydroAcousticApp_1.Models;
using System.ComponentModel;

namespace HydroAcousticApp_1.ViewModels
{
    public class ShellViewModel : Conductor<Screen>, INotifyPropertyChanged
    {
        private Screen activeSecondaryItem;

        public Screen ActiveSecondaryItem
        {
            get => activeSecondaryItem;
            set
            {
                activeSecondaryItem = value;
                NotifyOfPropertyChange();
            }
        }
        public IObservableCollection<Screen> Parameters { get; } = new BindableCollection<Screen>();

        public IObservableCollection<Screen> Graphs { get; } = new BindableCollection<Screen>();

        public ShellViewModel()
        {
            Parameters.Add(IoC.Get<WaterParamsViewModel>());
            Parameters.Add(IoC.Get<SignalParamsViewModel>());
            Graphs.Add(IoC.Get<GraphSpeedViewModel>());
            Graphs.Add(IoC.Get<GraphSignalsViewModel>());
            ActiveItem = Parameters[0];
            ActiveSecondaryItem = Graphs[0];
        }
    }
}
