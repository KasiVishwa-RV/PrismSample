using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace PrismSampleApp.ViewModels
{
    public class AddContactPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private ObservableCollection<Contacts> _contactList;
        private string _contactName;
        
        private string _mobileNumber;
        public AddContactPageViewModel(INavigationService navigationService)
        {
            ContactCommand = new Command(ContactCommandHandler);
            _navigationService = navigationService;
            ContactList = new ObservableCollection<Contacts>
            {
                
            };
           AddCommand = new Command(() =>
            {
                ContactList.Add(new Contacts { Name = ContactName, Number = MobileNumber }); ;
            });
        }
        public ObservableCollection<Contacts> ContactList
        {
            get
            {
                return _contactList;
            }
            set
            {
                SetProperty(ref _contactList, value);
            }
        }
        public ICommand AddCommand { get; set; }
        public ICommand ContactCommand { get; set; }


        public string ContactName
        {
            get
            {
                return _contactName;
            }
            set
            {
                SetProperty(ref _contactName, value);
            }
        }
        public string MobileNumber
        {
            get
            {
                return _mobileNumber;
            }
            set
            {
                SetProperty(ref _mobileNumber, value);
            }
        }
        private async void ContactCommandHandler()
        {
            var contactPage = new NavigationParameters();
            contactPage.Add("contactList", ContactList);
            //contactPage.Add("number", MobileNumber);
            await _navigationService.NavigateAsync("ViewContactListPage",contactPage);
        }
    }
    public class Contacts
    {
        public string Name { get; set; }
        public string Number { get; set; }
    }
}