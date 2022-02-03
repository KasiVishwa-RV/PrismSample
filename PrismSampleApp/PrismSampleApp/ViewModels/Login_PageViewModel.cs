using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrismSampleApp.ViewModels
{
    public class Login_PageViewModel : BindableBase, INavigatedAware
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
        public Login_PageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            Title = "Login Page";
        }

        private readonly INavigationService _navigationService;

        private DelegateCommand _navigateCommand;
        public DelegateCommand NavigateCommand =>
            _navigateCommand ?? (_navigateCommand = new DelegateCommand(ExecuteNavigateCommand));

        //private string _userName;
        //public string UserName
        //{
        //    get
        //    {
        //        return _userName;
        //    }
        //    set
        //    {
        //        SetProperty(ref _userName, value);
        //    }
        //}
        //private string _password;
        //public string Password
        //{
        //    get
        //    {
        //        return _password;
        //    }
        //    set
        //    {
        //        SetProperty(ref _password, value);
        //    }
        //}

        

        async void ExecuteNavigateCommand()
        {
            //if (UserName == "admin" && Password == "123")
            //{
                await _navigationService.NavigateAsync("MainPage");
            //}
            
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {

        }
    }
}