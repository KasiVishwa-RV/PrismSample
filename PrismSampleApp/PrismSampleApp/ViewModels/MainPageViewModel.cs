using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }
        private readonly INavigationService _navigationService;
        private readonly IPageDialogService _dialogService;


        private DelegateCommand _navigateCommandA;
        public DelegateCommand NavigateCommandA =>
            _navigateCommandA ?? (_navigateCommandA = new DelegateCommand(ExecuteNavigateCommandA));


        private DelegateCommand _navigateCommandB;
        public DelegateCommand NavigateCommandB =>
            _navigateCommandB ?? (_navigateCommandB = new DelegateCommand(ExecuteNavigateCommandB));


        private DelegateCommand _navigateCommandC;
        public DelegateCommand NavigateCommandC =>
            _navigateCommandC ?? (_navigateCommandC = new DelegateCommand(ExecuteNavigateCommandC));

        async void ExecuteNavigateCommandA()
        {
            var p = new NavigationParameters();
            p.Add("title", "Hello from MainPage");
            await _navigationService.NavigateAsync("ViewA", p);
        }
        async void ExecuteNavigateCommandB()
        {

            var q = new NavigationParameters();
            q.Add("title", "Hello from MainPage");

            await _navigationService.NavigateAsync("ViewB", q);
        }
        async void ExecuteNavigateCommandC()
        {

            var r = new NavigationParameters();
            r.Add("title", "Hello from MainPage");
            await _navigationService.NavigateAsync("ViewC", r);
        }
        private DelegateCommand _navigateCommandD;
        public DelegateCommand NavigateCommandD =>
            _navigateCommandD ?? (_navigateCommandD = new DelegateCommand(ExecuteNavigateCommandD));
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