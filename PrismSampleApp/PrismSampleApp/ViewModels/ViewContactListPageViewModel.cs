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
    public class ViewContactListPageViewModel : ViewModelBase , INavigatedAware
    {
        public ViewContactListPageViewModel()
        {
            
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
        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            var res = parameters.GetValue<List<Result>>("TappedData");
            Content = res;
        }
    }
}
