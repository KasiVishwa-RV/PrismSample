using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using PrismSampleApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

[assembly: Dependency(typeof(ViewAViewModel))]
namespace PrismSampleApp.ViewModels
{
    public class ViewAViewModel : BindableBase, INavigationAware
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
        public ViewAViewModel(INavigationService navigationService)
        {
            Title = "View A";
            _navigationService = navigationService;
        }
        private DelegateCommand _navigateCommand;
        private readonly INavigationService _navigationService;
        public DelegateCommand NavigateCommandB =>
            _navigateCommand ?? (_navigateCommand = new DelegateCommand(ExecuteNavigateCommandB));

        async void ExecuteNavigateCommandB()
        {
            await _navigationService.NavigateAsync("ViewB");
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