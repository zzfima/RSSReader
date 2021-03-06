﻿using Castle.Windsor;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using RSS_Module.ViewModel;

namespace RSS_Module
{
    /// <summary>
    /// Module with attached regions
    /// </summary>
    public class RSSApplicationModule : IModule
    {
        #region Fields
        private IRegionManager _regionManager;
        public static WindsorContainer Container;
        public static RSSReaderViewModel RssReaderViewModel;
        #endregion

        #region Ctor
        public RSSApplicationModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Initialize of RSSApplicationModule by adding regions
        /// </summary>
        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion("MainRegion", typeof(View.RSSReaderMainView));
            _regionManager.RegisterViewWithRegion("TreeRegion", typeof(View.RssReaderTree));
        }

        public static void SetContainer(WindsorContainer container)
        {
            Container = container;
            RssReaderViewModel = new RSSReaderViewModel();
        }
        #endregion
    }
}
