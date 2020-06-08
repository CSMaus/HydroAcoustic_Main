using Caliburn.Micro;
using HydroAcousticApp_1.ViewModels.Signals;

namespace HydroAcousticApp_1.ViewModels
{
    class GraphSignalsViewModel : Screen
    {
        private SignalParamsViewModel _vm;
        public IObservableCollection<BaseSignalViewModel> Signals => _vm.Signals;
        public GraphSignalsViewModel()
        {
            DisplayName = "Signals";
            _vm = IoC.Get<SignalParamsViewModel>();
            _vm.PropertyChanged += GraphSignalsViewModel_PropertyChanged;
        }

        private void GraphSignalsViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
        }
    }
}
