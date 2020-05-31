using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HydroAcousticApp_1.Services;
using OxyPlot;

namespace HydroAcousticApp_1.ViewModels
{
    class GraphSignalsViewModel : Screen
    {
        public GraphSignalsViewModel()
        {
            DisplayName = "Signals";
            IoC.Get<SignalParamsViewModel>().PropertyChanged += GraphSignalsViewModel_PropertyChanged;
        }

        private void GraphSignalsViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
        }
    }
}
