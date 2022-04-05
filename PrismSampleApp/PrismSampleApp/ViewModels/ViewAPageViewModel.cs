using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using PrismSampleApp.Services.Interfaces;
using PrismSampleApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace PrismSampleApp.ViewModels
{
    public class ViewAPageViewModel : ViewModelBase
    {
        public ICommand NavigateToViewBCommand { get; set; }
        public ICommand GoHomeCommand { get; set; }
        public DelegateCommand ShowTimeACommand { get; set; }
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
        public ViewAPageViewModel(INavigationService navigationService, IApplicationCommands applicationCommands)
        {
            GoHomeCommand= new Command(ExecuteNavigateCommand);
            NavigateToViewBCommand = new Command(ExecuteNavigateCommandB);
            _navigationService = navigationService;
            ShowTimeACommand = new DelegateCommand(ShowTimeCommandHandler);
            applicationCommands.ShowAllCommand.RegisterCommand(ShowTimeACommand);
        }
        
        private readonly INavigationService _navigationService;
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

        async void ExecuteNavigateCommandB()
        {
            await _navigationService.NavigateAsync("ViewBPage");
        }
        

        async void ExecuteNavigateCommand()
        {
            await _navigationService.GoBackToRootAsync();
        }
    }

}