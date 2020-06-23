using RSS_Module.ViewModel;
using System.Windows.Controls;

namespace RSS_Module.View
{
    /// <summary>
    /// Interaction logic for RssReaderTree.xaml
    /// </summary>
    public partial class RssReaderTree : UserControl
    {
        public RssReaderTree()
        {
            InitializeComponent();

            DataContext = RSSApplicationModule.RssReaderViewModel;
        }
    }
}
