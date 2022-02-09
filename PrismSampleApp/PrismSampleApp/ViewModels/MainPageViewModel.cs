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
    public class MainPageViewModel : BindableBase, IConfirmNavigationAsync, INavigationAware
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
        public MainPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            Title = "Main Page";
            _navigationService = navigationService;
            _dialogService = pageDialogService;
            NavigateCommandA = new Command(ExecuteNavigateCommandA);
            NavigateCommandB = new Command(ExecuteNavigateCommandB);
            NavigateCommandC = new Command(ExecuteNavigateCommandC);
            NavigateCommandD = new Command(ExecuteNavigateCommandD);
        }
        private readonly INavigationService _navigationService;
        private readonly IPageDialogService _dialogService;

        public ICommand NavigateCommandA { get; set; }
        public ICommand NavigateCommandB { get; set; }
        public ICommand NavigateCommandC{ get; set; }

        private async void ExecuteNavigateCommandA()
        {
            var viewA = new NavigationParameters();
            viewA.Add("title", "Hello from MainPage");
            await _navigationService.NavigateAsync("ViewA", viewA);
        }
        private async void ExecuteNavigateCommandB()
        {

            var viewB = new NavigationParameters();
            viewB.Add("title", "Hello from MainPage");

            await _navigationService.NavigateAsync("ViewB", viewB);
        }
        private async void ExecuteNavigateCommandC()
        {

            var viewC = new NavigationParameters();
            viewC.Add("title", "Hello from MainPage");
            await _navigationService.NavigateAsync("ViewC", viewC);
        }
        public ICommand NavigateCommandD { get; set; }
        async void ExecuteNavigateCommandD()
        {
            await _navigationService.NavigateAsync("ViewModelLocator");
        }

        public Task<bool> CanNavigateAsync(INavigationParameters parameters)
        {
            return _dialogService.DisplayAlertAsync(Title, "Navigate", "Yes", "No");

        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {

        }
    }
}