using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Windows;
using HydroAcousticApp_1.ViewModels;
using HydroAcousticApp_1.Services;

namespace HydroAcousticApp_1
{
    public class Bootstrapper : BootstrapperBase
    {
        private SimpleContainer _container;
        public Bootstrapper()
        {
            Initialize();
        }
        protected override void Configure()
        {
            base.Configure();
            _container = new SimpleContainer();
            _container.Singleton<IWindowManager, WindowManager>();
            _container.Singleton<ShellViewModel>();
            _container.Singleton<ChenMillero>();
            _container.Singleton<WaterParamsViewModel>();
            _container.Singleton<SignalParamsViewModel>();
            _container.Singleton<GraphSpeedViewModel>();
            _container.Singleton<GraphSignalsViewModel>();
            _container.PerRequest<GenerateSignals>();
        }
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }
        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }
    }
}
