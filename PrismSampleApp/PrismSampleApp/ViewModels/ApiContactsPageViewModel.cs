using PrismSampleApp.Model;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using Prism.Navigation;
using PrismSampleApp.Services.Interfaces;
using System;
using Prism.Commands;
using System.Linq;

namespace PrismSampleApp.ViewModels
{
    public class ApiContactsPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IWebApiService _webApiService;
        public ICommand ClickCommand { get; set; }
        public DelegateCommand<object> ItemTappedCommand { get; set; }
        public ApiContactsPageViewModel(INavigationService navigationService, Prism.Services.IPageDialogService @object, IWebApiService webApiService)
        {
            ClickCommand = new Command(ClickCommandHandler);
            ItemTappedCommand = new DelegateCommand<object>(ItemTappedCommandHandler);
            _navigationService = navigationService;
            _webApiService = webApiService;
        }
        private async void ItemTappedCommandHandler(object data)
        {
            var result = data as Result;
            var Data = new NavigationParameters();
            var list = ApiContacts.Where(x => x==result).ToList();
            Data.Add("TappedData", list);
            await _navigationService.NavigateAsync("ViewContactListPage",Data);
        }

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
           var a = await _webApiService.IntializingService();
            ApiContacts = a;
        }
    }
}