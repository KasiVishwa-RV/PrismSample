using PrismSampleApp.Model;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using Prism.Navigation;
using PrismSampleApp.Services.Interfaces;

namespace PrismSampleApp.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        private readonly IWebApiService _webApiService;
        private INavigationService _navigationService;
        public HomePageViewModel(INavigationService navigationService,IWebApiService webApiService)
        {
            ClickCommand = new Command(ClickCommandHandler);
            //ItemTappedCommand = new Command(ItemTappedCommandHandler);
            _navigationService = navigationService;
            _webApiService = webApiService;
        }
        public ICommand ClickCommand { get; set; }
        public ICommand ItemTappedCommand { get; set; }

        private void ClickCommandHandler()
        {
            IntializingService();
        }
        private List<Result> _apiContacts;
        public List<Result> ApiContacts
        {
            get
            {
                return _apiContacts;
            }
            set
            {
                SetProperty(ref _apiContacts, value);
            }

        }
        public async void IntializingService()
        {

           var a = _webApiService.IntializingService();
            ApiContacts = await a;
        }
    }
}
