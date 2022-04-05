using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using PrismSampleApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace PrismSampleApp.ViewModels
{
    public class ViewBPageViewModel : ViewModelBase
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
        private string _time;
        public string Time
        {
            get
            {
                return _time;
            }
            set
            {
                SetProperty(ref _time, value);
            }
        }
        public void ShowTimeCommandHandler()
        {
            Time = $"Time: {DateTime.Now}";
        }
        public ViewBPageViewModel(INavigationService navigationService,IApplicationCommands applicationCommands)
        {
            Title = "View B";
            _navigationService = navigationService;
            ShowTimeBCommand = new DelegateCommand(ShowTimeCommandHandler);
            applicationCommands.ShowAllCommand.RegisterCommand(ShowTimeBCommand);
        }
        private DelegateCommand _navigateCommand;
        public DelegateCommand ShowTimeBCommand { get; set; }
        private readonly INavigationService _navigationService;
        public DelegateCommand NavigateToCCommand =>
            _navigateCommand ?? (_navigateCommand = new DelegateCommand(ExecuteNavigateCommandC));

        async void ExecuteNavigateCommandC()
        {
            await _navigationService.NavigateAsync("ViewCPage");
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