using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace PrismSampleApp.ViewModels
{
    public class ViewBViewModel : BindableBase, INavigationAware
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

        public ViewBViewModel(INavigationService navigationService)
        {
            Title = "View B";
            _navigationService = navigationService;
        }
        private DelegateCommand _navigateCommand;
        private readonly INavigationService _navigationService;
        public DelegateCommand NavigateCommandC =>
            _navigateCommand ?? (_navigateCommand = new DelegateCommand(ExecuteNavigateCommandC));

        async void ExecuteNavigateCommandC()
        {
            await _navigationService.NavigateAsync("ViewC");
        }
        private DelegateCommand _navigateCommandMainPage;
        public DelegateCommand GoHomeCommand =>
            _navigateCommandMainPage ?? (_navigateCommandMainPage = new DelegateCommand(ExecuteNavigateCommand));

        async void ExecuteNavigateCommand()
        {
            await _navigationService.GoBackToRootAsync();
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            Title = parameters.GetValue<string>("title");
        }
    }

}