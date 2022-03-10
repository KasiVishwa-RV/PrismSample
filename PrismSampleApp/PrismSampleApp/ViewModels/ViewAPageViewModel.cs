using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
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
        public ViewAPageViewModel(INavigationService navigationService)
        {
            GoHomeCommand= new Command(ExecuteNavigateCommand);
            NavigateToViewBCommand = new Command(ExecuteNavigateCommandB);
            _navigationService = navigationService;
        }
        
        private readonly INavigationService _navigationService;

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