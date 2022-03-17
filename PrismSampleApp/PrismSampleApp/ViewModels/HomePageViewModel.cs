using PrismSampleApp.Model;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using Prism.Navigation;
using PrismSampleApp.Services.Interfaces;
using System;

namespace PrismSampleApp.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IWebApiService _webApiService;
        public HomePageViewModel(INavigationService navigationService,IWebApiService webApiService)
        {
            ClickCommand = new Command(ClickCommandHandler);
            ItemSelectedCommand = new Command(ItemSelectedCommandHandler);
            _navigationService = navigationService;
            _webApiService = webApiService;
        }
        private async void ItemSelectedCommandHandler()
        { 
            await _navigationService.NavigateAsync("ViewContactListPage");
        }

        public ICommand ClickCommand { get; set; }
        public ICommand ItemSelectedCommand { get; set; }
        private void ClickCommandHandler()
        {
            IntializingService();
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
        public async void IntializingService()
        {
           var a = _webApiService.IntializingService();
            ApiContacts = await a;
        }
    }
}