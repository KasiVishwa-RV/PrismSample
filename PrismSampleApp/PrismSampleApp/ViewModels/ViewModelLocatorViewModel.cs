using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrismSampleApp.ViewModels
{
    public class ViewModelLocatorViewModel : BindableBase, INavigatedAware
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private readonly INavigationService _navigationService;

        public ViewModelLocatorViewModel(INavigationService navigationService)
        {
            Title = "Hello ViewModelLocator";
            _navigationService = navigationService;
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {

        }
    }
}