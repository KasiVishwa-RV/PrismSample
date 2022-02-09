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
    public class LoginPageViewModel : INavigatedAware, INotifyPropertyChanged
    {
        private string _title;
        public string Title
        {
            get
            {
                return _title;

            }
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
        public LoginPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            Title = "Login Page";
            NavigateCommand = new Command(ExecuteNavigateCommand);
        }

        private readonly INavigationService _navigationService;

        public ICommand NavigateCommand { get; set; }

        private string _username;
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }
        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private async void ExecuteNavigateCommand()
        {
            if (Username == "admin" && Password == "123")
            {
                await _navigationService.NavigateAsync("MainPage");
            }
        }
        public void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {

        }
    }
}