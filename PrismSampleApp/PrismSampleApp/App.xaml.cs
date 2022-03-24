
using Prism;
using Prism.Ioc;
using Prism.Modularity;
using PrismSampleApp.ApplicationCommand;
using PrismSampleApp.Services;
using PrismSampleApp.Services.Interfaces;
using PrismSampleApp.ViewModels;
using PrismSampleApp.Views;
using System.Threading.Tasks;
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
            await NavigationService.NavigateAsync("NavigationPage/WorldTimePage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        { 
            containerRegistry.Register<IWebApiService,WebApiService>();
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();
            containerRegistry.RegisterSingleton<IApplicationCommands, ApplicationCommands>();


            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<ViewAPage, ViewAPageViewModel>();
            containerRegistry.RegisterForNavigation<ViewBPage, ViewBPageViewModel>();
            containerRegistry.RegisterForNavigation<ViewCPage, ViewCPageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<AddContactPage, AddContactPageViewModel>();
            containerRegistry.RegisterForNavigation<ViewContactListPage, ViewContactListPageViewModel>();
            containerRegistry.RegisterForNavigation<AddPersonPage, AddPersonPageViewModel>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
            containerRegistry.RegisterForNavigation<WorldTimePage, WorldTimePageViewModel>();
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
