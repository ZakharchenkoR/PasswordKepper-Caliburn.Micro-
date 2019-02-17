using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using PasswordBox.ViewModels;
using PasswordBox.Infrasrtucture;
using PasswordBox.Models;

namespace PasswordBox
{
    public class Bootstrapper:BootstrapperBase
    {
        private SimpleContainer simpleContainer;

        public Bootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            simpleContainer = new SimpleContainer();
            simpleContainer.Singleton<IWindowManager, WindowManager>();
            simpleContainer.Singleton<IEventAggregator, EventAggregator>();
            simpleContainer.PerRequest<StartViewModel, StartViewModel>();
            simpleContainer.Singleton<IIDSaver, JSONIDSaver>();
            simpleContainer.Singleton<IDLoader, JSONIDLoader>();
            simpleContainer.Singleton<IEncoder, PasswordBox.Models.Encoder>();
        }

        protected override void BuildUp(object instance)
        {
            simpleContainer.BuildUp(instance);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return simpleContainer.GetAllInstances(service);
        }

        protected override object GetInstance(Type service, string key)
        {
            return simpleContainer.GetInstance(service, key);
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<StartViewModel>();
        }
    }
}
