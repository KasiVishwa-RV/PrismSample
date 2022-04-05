using Prism.Commands;
using Prism.Navigation;
using PrismSampleApp.ApplicationCommand;
using PrismSampleApp.Services.Interfaces;
using PrismSampleApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PrismSampleApp.ViewModels
{
    public class HomePageViewModel:ViewModelBase
    {
        private readonly INavigationService _navigationService;

        private string _messages;
        public ICommand GoToMessagingCenterPageCommand { get; set; }
        public ICommand SubscribeCommand { get; set; }
        public HomePageViewModel(INavigationService NavigationService)
        {
            _navigationService = NavigationService;
            SubscribeCommand = new Command(SubscribeCommandHandler);
            GoToMessagingCenterPageCommand = new Command(GoToMessagingCenterPageCommandHandler);
        }
        public string Messages
        { 
            get 
            { 
                return _messages; 
            }
            set
            {
                SetProperty(ref _messages, value);
            }
        } 
        public void SubscribeCommandHandler()
        {
            MessagingCenter.Subscribe<MessagingCenterPageViewModel, DateTime>(this, "Hi", (p,DateTime) =>
             {
                 Messages=$"Logged in @ {DateTime.Now}";
             });
        }
        private async void GoToMessagingCenterPageCommandHandler()
        {
          await _navigationService.NavigateAsync("MessagingCenterPage");
        }
    }
}
