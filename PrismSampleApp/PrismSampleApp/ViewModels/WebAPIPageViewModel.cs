using Newtonsoft.Json;
using Prism.Mvvm;
using PrismSampleApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Windows.Input;
using Xamarin.Forms;
using Flurl;
using Flurl.Http;
using Prism.Navigation;
using PrismSampleApp.Services;
using System.Collections.ObjectModel;
using PrismSampleApp.Services.Interfaces;

namespace PrismSampleApp.ViewModels
{
    public class WebAPIPageViewModel : BindableBase, INavigationAware,IWebApiService
    {
        public WebAPIPageViewModel(INavigationService navigationService,IWebApiService webApiService)
        {
            ClickCommand = new Command(ClickCommandHandler);
            ItemTappedCommand = new Command(ItemTappedCommandHandler);
            _navigationService = navigationService;
            _webApiService = webApiService;
        }
        public ICommand ClickCommand { get; set; }
        public ICommand ItemTappedCommand { get; set; }

        private INavigationService _navigationService;
        private IWebApiService _webApiService;
        private void ClickCommandHandler()
        {
            IntializingService();
        }
        private int tapCount = 0;
        private async void ItemTappedCommandHandler()
        {

            tapCount++;
            if (tapCount % 2 != 0)
            {
                await _navigationService.NavigateAsync("ViewContactList");
            }
        }
        private List<Result> _apiContacts;
        public List<Result> ApiContacts
        {
            get
            {
                return _apiContacts;
            }
            set
            {
                SetProperty(ref _apiContacts, value);
            }

        }

        public INavigationService NavigationService => _navigationService;

        public List<Result> RecievedContacts { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            
        }

        public void IntializingService()
        {
            _webApiService.IntializingService();
            ApiContacts = _webApiService.RecievedContacts;
        }
    }
}
