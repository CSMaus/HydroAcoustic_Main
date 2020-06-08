using Caliburn.Micro;
using System.Runtime.CompilerServices;
using LiveCharts;
using LiveCharts.Defaults;

namespace HydroAcousticApp_1.ViewModels.Signals
{
    abstract class BaseSignalViewModel : PropertyChangedBase
    {
        SignalParamsViewModel _owner;
        public ChartValues<ObservablePoint> SignalPoints { get; } = new ChartValues<ObservablePoint>();
        public BaseSignalViewModel(SignalParamsViewModel owner)
        {
            _owner = owner;
            SignalPoints.CollectionChanged += SignalPoints_CollectionChanged;
        }

        private void SignalPoints_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            NotifyOfPropertyChange(nameof(SignalPoints));
        }

        public void Delete()
        {
            _owner.Remove(this);
        }
        public abstract void GeneratePoints();
        public override void NotifyOfPropertyChange([CallerMemberName] string propertyName = null)
        {
            if(propertyName != nameof(SignalPoints))
                GeneratePoints();
            base.NotifyOfPropertyChange(propertyName);
        }
    }
}
