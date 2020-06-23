using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;

namespace RSS_Module
{
    /// <summary>
    /// Module with attached regions
    /// </summary>
    public class RSSApplicationModule : IModule
    {
        #region Fields
        private IRegionManager _regionManager;
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
        #endregion
    }
}
