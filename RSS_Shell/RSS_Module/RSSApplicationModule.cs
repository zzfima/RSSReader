using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;

namespace RSS_Module
{
    public class RSSApplicationModule : IModule
    {
        private IRegionManager _regionManager;

        public RSSApplicationModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion("MainRegion", typeof(View.RSSReaderView));
        }
    }
}
