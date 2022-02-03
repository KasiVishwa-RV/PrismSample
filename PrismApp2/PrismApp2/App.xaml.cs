using Prism;
using Prism.Ioc;
using PrismApp2.ViewModels;
using PrismApp2.Views;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace PrismApp2
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
            DependencyService.Register<IViewAViewModel,ViewAViewModel>();

            await NavigationService.NavigateAsync("NavigationPage/Login_Page");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<ViewA, ViewAViewModel>();
            containerRegistry.RegisterForNavigation<ViewB, ViewBViewModel>();
            containerRegistry.RegisterForNavigation<ViewC, ViewCViewModel>();
            containerRegistry.RegisterForNavigation<ViewModelLocator, ViewModelLocatorViewModel>();
            containerRegistry.RegisterForNavigation<Login_Page, Login_PageViewModel>();
        }
    }
}
