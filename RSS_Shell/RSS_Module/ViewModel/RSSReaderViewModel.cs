using RSS_Module.Model;
using RSS_Module.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace RSS_Module.ViewModel
{
    /// <summary>
    /// ViewModel for RSS View
    /// </summary>
    public sealed class RSSReaderViewModel : INotifyPropertyChanged
    {
        private string _rssUrl;
        private ObservableCollection<Feed> _rss_Feeds;
        public ICommand AddSubscriptionCommand { get; set; }

        public RSSReaderViewModel()
        {
            AddSubscriptionCommand = new RelayCommand(ExecuteMyMethod, CanExecuteMyMethod);

            string url = "http://feeds.feedburner.com/ScottHanselman";
            var rssService = new RssService(url);
            RSS_Feeds = new ObservableCollection<Feed>(rssService.GetLatest());
        }

        public ObservableCollection<Feed> RSS_Feeds
        {
            get { return _rss_Feeds; }

            set
            {
                _rss_Feeds = value;
                OnPropertyChange("RSS_Feeds");
            }
        }

        public string RSSUrl
        {
            get { return _rssUrl; }
            set
            {
                if (_rssUrl != value)
                {
                    _rssUrl = value;
                    OnPropertyChange("RSSUrl");
                }
            }
        }

        #region ICommand
        private bool CanExecuteMyMethod(object parameter)
        {
            if (string.IsNullOrEmpty(RSSUrl))
            {
                return false;
            }
            else
            {
                if (RSSUrl != string.Empty)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private void ExecuteMyMethod(object parameter)
        {
            string url = RSSUrl;
            RssService rssService = new RssService(url);
            Feed feed =  rssService.GetLatest()[0];
            RSS_Feeds.Add(feed);
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
