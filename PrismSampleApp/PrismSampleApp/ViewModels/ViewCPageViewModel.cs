using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using PrismSampleApp.ApplicationCommand;
using PrismSampleApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrismSampleApp.ViewModels
{
    public class ViewCPageViewModel : ViewModelBase
    {
        private IApplicationCommands _applicationCommands;
        public IApplicationCommands ApplicationCommands
        {
            get { return _applicationCommands; }
            set { SetProperty(ref _applicationCommands, value); }
        }
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
        public ViewCPageViewModel(INavigationService navigationService, IApplicationCommands applicationCommands)
        {
            Title = "View C";
            ApplicationCommands = applicationCommands;
            _navigationService = navigationService;
        }
        private DelegateCommand _navigateCommandMainPage;
        private readonly INavigationService _navigationService;
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