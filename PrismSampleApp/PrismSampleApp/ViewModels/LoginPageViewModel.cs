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
    public class LoginPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
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
        public LoginPageViewModel(INavigationService NavigationService)
        {
            _navigationService = NavigationService;
            Title = "Login Page";
            NavigateCommand = new Command(ExecuteNavigateCommand);
        }


        public ICommand NavigateCommand { get; set; }

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
        private async void ExecuteNavigateCommand()
        {
            if (Username == "admin" && Password == "123")
            {
                await _navigationService.NavigateAsync("MainPage");
            }
        }
    }
}