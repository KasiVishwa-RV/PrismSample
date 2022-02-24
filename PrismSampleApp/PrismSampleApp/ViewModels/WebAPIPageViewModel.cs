using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using PrismSampleApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Windows.Input;
using Xamarin.Forms;

namespace PrismSampleApp.ViewModels
{ 
    public class WebAPIPageViewModel : BindableBase
    {
        public WebAPIPageViewModel()
        {
            ClickCommand = new Command(ClickCommandHandler);
        }
        public ICommand ClickCommand { get; set; }
        private async void ClickCommandHandler()
        {
            string url =await client.GetStringAsync(WebUrl);
            var collection = JsonConvert.DeserializeObject<Root>(url);
            Content = new List<Result>(collection.Results);

        }

        public const string WebUrl = "https://randomuser.me/api/?results=50";
        public HttpClient client = new HttpClient();
        private Root _itemsSource;
        public event PropertyChangedEventHandler PropertyChanged;
        public Root ItemsSource
        {
            get
            {
                return _itemsSource;
            }

            set
            {
                _itemsSource = value;
                RaisepropertyChanged("ItemsSource");
            }
        }
        private List<Result> _content;
        public List<Result> Content
        {
            get
            {
                return _content;
            }
            set
            {
                SetProperty(ref _content, value);
            }

        }

        private void RaisepropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }
    }
}
