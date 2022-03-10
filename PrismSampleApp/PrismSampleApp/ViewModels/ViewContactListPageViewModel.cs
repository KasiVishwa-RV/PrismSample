using Flurl.Http;
using Prism.Commands;
using Prism.Common;
using Prism.Mvvm;
using Prism.Navigation;
using PrismSampleApp.Model;
using PrismSampleApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace PrismSampleApp.ViewModels
{
    public class ViewContactListPageViewModel : ViewModelBase
    {
        public ViewContactListPageViewModel(INavigationService navigationService,IWebApiService webApiService)
        {
            _webApiService = webApiService;
        }
        private List<Result> _content;
        public List<Result> Content
        {
            get
            {
                return _content;
            }
            set
            {
                SetProperty(ref _content, value);
            }

        }
        public List<Result> RecievedContacts { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private IWebApiService _webApiService;
        public void OnNavigatedTo()
        {
            IntializingService();
        }
        public async void IntializingService()
        {
            var a= _webApiService.IntializingService();
            Content =await a;
        }
    }
}
