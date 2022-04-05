using Prism.AppModel;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using PrismSampleApp.Model;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using PrismSampleApp.Resx;
using System.Globalization;
using Xamarin.CommunityToolkit.Helpers;
namespace PrismSampleApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase , IPageLifecycleAware
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
        private ObservableCollection<MyLanguage> _supportedLanguage;

        public ObservableCollection<MyLanguage> SupportedLanguage
        {
            get { return _supportedLanguage; }
            set { SetProperty(ref _supportedLanguage, value); }
        }

        private MyLanguage _selectedLanguage;
        public MyLanguage SelectedLanguage
        {
            get { return _selectedLanguage; }
            set { SetProperty(ref _selectedLanguage, value); }
        }
        public MainPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            Title = "Main Page";
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;
            NavigateToACommand = new DelegateCommand(ExecuteNavigateCommandA);
            NavigateToBCommand = new DelegateCommand(ExecuteNavigateCommandB);
            NavigateToCCommand = new DelegateCommand(ExecuteNavigateCommandC);
            ChangeLanguageCommand = new Command(PerformOperation);
            SupportedLanguage = new ObservableCollection<MyLanguage>()
            {
                new MyLanguage{Name=AppResource.English,CI="en"},
                new MyLanguage{Name=AppResource.Spanish,CI="es"},
                new MyLanguage{Name=AppResource.French,CI="fr"},
                new MyLanguage{Name=AppResource.Tamil,CI="ta"}
            };
            SelectedLanguage = SupportedLanguage.FirstOrDefault(x => x.CI == LocalizationResourceManager.Current.CurrentCulture.TwoLetterISOLanguageName);
        }
        private void PerformOperation(object obj)
        {
            //CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.UserCustomCulture | CultureTypes.SpecificCultures);
            //var getCulture = CultureInfo.CurrentUICulture.Name;

            LocalizationResourceManager.Current.SetCulture(CultureInfo.GetCultureInfo(SelectedLanguage.CI));
        }

        public DelegateCommand NavigateToACommand { get; set; }
        public DelegateCommand NavigateToBCommand { get; set; }
        public DelegateCommand NavigateToCCommand{ get; set; }
        public ICommand ChangeLanguageCommand { get; set; }

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
        public async  void OnAppearing()
        {
           await _pageDialogService.DisplayAlertAsync("MainPage","We are appearing","ok");
        }

        public async void OnDisappearing()
        {
           await _pageDialogService.DisplayAlertAsync("MainPage", "We are disappearing", "ok");
        }
    }
}