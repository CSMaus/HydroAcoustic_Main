using Caliburn.Micro;
using HydroAcousticApp_1.Services;
using OxyPlot;
using System;

namespace HydroAcousticApp_1.ViewModels.Signals
{
    class SineWaveSignalViewModel : BaseSignalViewModel
    {
        GenerateSignals _generator;
        public double Amplitude
        {
            get => _generator.Amplitude;
            set
            {
                _generator.Amplitude = value;
                NotifyOfPropertyChange();
            }
        }
        public double Phase
        {
            get => _generator.Phase * 180 / Math.PI;
            set
            {
                _generator.Phase = value * Math.PI / 180;
                NotifyOfPropertyChange();
            }
        }

        public double Frequency
        {
            get => _generator.Frequency;
            set
            {
                _generator.Frequency = value;
                NotifyOfPropertyChange();
            }
        }
        public SineWaveSignalViewModel(SignalParamsViewModel owner) : base(owner)
        {
            _generator = IoC.Get<GenerateSignals>();
            GeneratePoints();
        }
        public override void GeneratePoints()
        {
            SignalPoints.Clear();
            double timeMax = IoC.Get<SignalParamsViewModel>().Time;
            double step = timeMax / 1000;
            var solver = IoC.Get<GenerateSignals>();
            for (var t = 0.0; t < timeMax; t += step)
                SignalPoints.Add(new DataPoint(t, solver.SineGenerate(t)));
        }
    }
}
