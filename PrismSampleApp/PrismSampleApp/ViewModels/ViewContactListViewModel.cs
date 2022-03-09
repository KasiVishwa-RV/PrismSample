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
    public class ViewContactListViewModel : ViewModelBase, INavigationAware, IWebApiService
    {
        public ViewContactListViewModel(INavigationService navigationService,IWebApiService webApiService) : base(navigationService)
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
        public void IntializingService()
        {
            _webApiService.IntializingService();
            Content = _webApiService.RecievedContacts;
        }
    }
}
