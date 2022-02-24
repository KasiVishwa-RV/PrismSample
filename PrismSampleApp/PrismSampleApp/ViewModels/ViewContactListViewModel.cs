using Prism.Commands;
using Prism.Common;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace PrismSampleApp.ViewModels
{
    public class ViewContactListViewModel : ViewModelBase, INavigationAware
    {
        public ViewContactListViewModel(INavigationService navigationService) : base(navigationService)
        {
            
        }
        private ObservableCollection<Contacts> _modelList;
        public ObservableCollection<Contacts> ModelList
        {
            get
            {
                return _modelList;
            }
            set
            {
                SetProperty(ref _modelList, value);
            }
        }
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
           var contactList = parameters.GetValue<ObservableCollection<Contacts>>("contactList");
            ModelList = new ObservableCollection<Contacts>(contactList);
        }
    }
}