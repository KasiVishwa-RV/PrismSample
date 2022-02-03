using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrismApp2.ViewModels
{
    public class Login_PageViewModel : BindableBase,INavigatedAware
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
                SetProperty(ref _title, value);
            }
        }
        public Login_PageViewModel(INavigationService _navigationService)
        {
            Title = "Login Page";
        }
        private readonly INavigationService _navigationService;

        private DelegateCommand _navigateCommand;
        public DelegateCommand NavigateCommand =>
            _navigateCommand ?? (_navigateCommand = new DelegateCommand(ExecuteNavigateCommand));

        public object Username { get; private set; }
        public object Password { get; private set; }

        async void ExecuteNavigateCommand()
        {
            if(Username.Equals("admin") && Password.Equals("123"))
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
