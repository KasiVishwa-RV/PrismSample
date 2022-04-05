
using Prism;
using Prism.Ioc;
using PrismSampleApp.ApplicationCommand;
using PrismSampleApp.Services;
using PrismSampleApp.Services.Interfaces;
using PrismSampleApp.ViewModels;
using PrismSampleApp.Views;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;
using PrismSampleApp.Resx;
using Xamarin.CommunityToolkit.Helpers;

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
            LocalizationResourceManager.Current.Init(AppResource.ResourceManager);
            InitializeComponent();
            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        { 
            containerRegistry.Register<IWebApiService,WebApiService>();
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();
            containerRegistry.RegisterSingleton<IApplicationCommands, ApplicationCommands>();
            containerRegistry.RegisterSingleton<ILogger>();
            containerRegistry.RegisterSingleton<ILogManager>();



            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<ViewAPage, ViewAPageViewModel>();
            containerRegistry.RegisterForNavigation<ViewBPage, ViewBPageViewModel>();
            containerRegistry.RegisterForNavigation<ViewCPage, ViewCPageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<AddContactPage, AddContactPageViewModel>();
            containerRegistry.RegisterForNavigation<ViewContactListPage, ViewContactListPageViewModel>();
            containerRegistry.RegisterForNavigation<AddPersonPage, AddPersonPageViewModel>();
            containerRegistry.RegisterForNavigation<ApiContactsPage, ApiContactsPageViewModel>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
            containerRegistry.RegisterForNavigation<MessagingCenterPage, MessagingCenterPageViewModel>();
        }
        protected override void OnStart()
        {
            base.OnStart();
        }
        protected override void OnSleep()
        {
            base.OnSleep();
        }
        protected override async void OnResume()
        {
            await NavigationService.NavigateAsync("NavigationPage/LoginPage");
        }

    }
}
