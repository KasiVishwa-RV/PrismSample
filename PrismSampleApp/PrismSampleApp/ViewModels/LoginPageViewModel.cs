using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Threading.Tasks;
using Prism.Services;
using PrismSampleApp.Views;
using PrismSampleApp.Services.Interfaces;

namespace PrismSampleApp.ViewModels
{
    public class LoginPageViewModel :ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IPageDialogService _pageDialogService;
        private static ILogger logger = DependencyService.Get<ILogManager>().GetLog();
        private string _title;
        private string _username;
        private string _password;
        public string Title
        {
            get
            {
                return _title;

            }
            set
            {
                SetProperty(ref _title,value);
            }
        }
        public LoginPageViewModel(INavigationService NavigationService,IPageDialogService pageDialogService)
        {
            _navigationService = NavigationService;
            Title = "Login Page";
            _pageDialogService = pageDialogService;
            LoginCommand = new Command(LoginCommandHandler);
            SendMessageCommand = new Command(SendMessageCommandHandler);
        }

        public ICommand LoginCommand { get; set; }
        public ICommand SendMessageCommand { get; set; }
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                SetProperty(ref _username, value);
            }
        }
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
               SetProperty(ref _password , value);
                
            }
        }
        public void SendMessageCommandHandler()
        {
                MessagingCenter.Send<LoginPageViewModel, DateTime>(this, "tick", DateTime.Now);
        }
        public async void LoginCommandHandler()
        {
            logger.Info("Logging");
            if (Username == "admin" && Password == "123")
            {
                await _navigationService.NavigateAsync("MainPage");
            }
            else
            {
                await _pageDialogService.DisplayAlertAsync("LoginPage", "Wrong Credentials", "Retry");
            }
        }
    }
}