using RSS_Module.Services;
using System.Windows;
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
            BindLatestFeeds();
        }

        private void BindLatestFeeds()
        {
            string url = "http://feeds.feedburner.com/ScottHanselman";
            var rssService = new RssService(url);
            icFeeds.ItemsSource = rssService.GetLatest();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string url = txtUrl.Text;
            var rssService = new RssService(url);
            icFeeds.ItemsSource = rssService.GetLatest();
        }
    }
}