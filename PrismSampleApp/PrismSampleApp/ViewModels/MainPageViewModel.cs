using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PrismSampleApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IPageDialogService _pageDialogService;
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
        public MainPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            Title = "Main Page";
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;
            NavigateToACommand = new Command(ExecuteNavigateCommandA);
            NavigateToBCommand = new Command(ExecuteNavigateCommandB);
            NavigateToCCommand = new Command(ExecuteNavigateCommandC);
            
        }

        public ICommand NavigateToACommand { get; set; }
        public ICommand NavigateToBCommand { get; set; }
        public ICommand NavigateToCCommand{ get; set; }

        private async void ExecuteNavigateCommandA()
        {
            var viewA = new NavigationParameters();
            viewA.Add("title", "Hello from MainPage");
            await _navigationService.NavigateAsync("ViewAPage", viewA);
        }
        private async void ExecuteNavigateCommandB()
        {

            var viewB = new NavigationParameters();
            viewB.Add("title", "Hello from MainPage");

            await _navigationService.NavigateAsync("ViewBPage", viewB);
        }
        private async void ExecuteNavigateCommandC()
        {

            var viewC = new NavigationParameters();
            viewC.Add("title", "Hello from MainPage");
            await _navigationService.NavigateAsync("ViewCPage", viewC);
        }
        public Task<bool> CanNavigateAsync(INavigationParameters parameters)
        {
            return _pageDialogService.DisplayAlertAsync(Title, "Navigate", "Yes", "No");

        }
    }
}