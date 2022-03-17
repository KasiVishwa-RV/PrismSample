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

namespace PrismSampleApp.ViewModels
{
    public class LoginPageViewModel :ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IPageDialogService _pageDialogService;
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
        }

        public ICommand LoginCommand { get; set; }

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
        public async void LoginCommandHandler()
        {
            if (Username == "admin" && Password =="123")
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