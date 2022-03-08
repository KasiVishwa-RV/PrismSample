
using Prism;
using Prism.Ioc;
using PrismSampleApp.Services;
using PrismSampleApp.Services.Interfaces;
using PrismSampleApp.ViewModels;
using PrismSampleApp.Views;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace PrismSampleApp
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/WebAPIPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();
            containerRegistry.RegisterSingleton<IWebApiService, WebApiService>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<ViewA, ViewAViewModel>();
            containerRegistry.RegisterForNavigation<ViewB, ViewBViewModel>();
            containerRegistry.RegisterForNavigation<ViewC, ViewCViewModel>();
            containerRegistry.RegisterForNavigation<ViewModelLocator, ViewModelLocatorViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<AddContact, AddContactViewModel>();
            containerRegistry.RegisterForNavigation<ViewContactList, ViewContactListViewModel>();
            containerRegistry.RegisterForNavigation<AddPerson, AddPersonViewModel>();
            containerRegistry.RegisterForNavigation<ContactsCollectionView, ContactsCollectionViewViewModel>();
            containerRegistry.RegisterForNavigation<WebAPIPage, WebAPIPageViewModel>();
        }
    }
}
