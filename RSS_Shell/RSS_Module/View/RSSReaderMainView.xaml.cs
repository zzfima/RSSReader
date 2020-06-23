using System.Windows.Controls;

namespace RSS_Module.View
{
    /// <summary>
    /// Interaction logic for RSSReaderView.xaml
    /// </summary>
    public partial class RSSReaderMainView : UserControl
    {
        public RSSReaderMainView()
        {
            InitializeComponent();
            DataContext = RSSApplicationModule.RssReaderViewModel; 
        }
    }
}