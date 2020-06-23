using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.UnityExtensions;
using RSS_Module;
using RSS_Module.Interfaces;
using RSS_Module.Model;
using RSS_Module.Services;
using System;
using System.Windows;

namespace RSS_Shell
{
    public class Bootstrapper : UnityBootstrapper
    {
        #region Methods
        protected override DependencyObject CreateShell()
        {
            return new Shell();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();
            App.Current.MainWindow = (Window)this.Shell;
            App.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();

            ModuleCatalog moduleCatalog = (ModuleCatalog)this.ModuleCatalog;
            moduleCatalog.AddModule(typeof(RSSApplicationModule));

            InitDI();
        }

        private void InitDI()
        {
            var container = new WindsorContainer();
            container.Register(Component.For(typeof(IWEBReaderService<Feed>)).ImplementedBy<RssService>());

            RSSApplicationModule.SetContainer(container);
        }
        #endregion
    }
}
