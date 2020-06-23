using RSS_Module.Services;
using RSS_Module.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace RSS_Module.View
{
    /// <summary>
    /// Interaction logic for RSSReaderView.xaml
    /// </summary>
    public partial class RSSReaderMainView : UserControl
    {
        private readonly RSSReaderViewModel _rssReaderViewModel;

        public RSSReaderMainView()
        {
            InitializeComponent();

            _rssReaderViewModel = new RSSReaderViewModel();
            DataContext = _rssReaderViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string url = txtUrl.Text;
            var rssService = new RssService(url);
            icFeeds.ItemsSource = rssService.GetLatest();
        }
    }
}