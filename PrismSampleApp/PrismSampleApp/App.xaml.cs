
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
            await NavigationService.NavigateAsync("NavigationPage/LoginPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IWebApiService,WebApiService>();
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

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
        }
    }
}
