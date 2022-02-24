using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PrismSampleApp.ViewModels
{
    public class ContactsCollectionViewViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        public ContactsCollectionViewViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
        }
        private ObservableCollection<ContactModel> _collectionList;
        public ObservableCollection<ContactModel> CollectionList
        {
            get
            {
                return _collectionList;
            }
            set
            {
                SetProperty(ref _collectionList, value);
            }
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            var contactList = parameters.GetValue<ObservableCollection<Contacts>>("contactList");

            CollectionList = new ObservableCollection<ContactModel>();
            foreach (var item in contactList)
            {
                CollectionList.Add(new ContactModel
                {
                    ContactName = item.Name,
                    ContactNum = item.Number
                });
            }
        }
    }
    public class ContactModel
    {
        public string ContactName { get; set; }
        public string ContactNum { get; set; }
    }
}