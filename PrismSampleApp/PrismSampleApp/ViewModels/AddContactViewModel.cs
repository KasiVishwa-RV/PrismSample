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
    public class AddContactViewModel : BindableBase, INotifyPropertyChanged
    {
        public AddContactViewModel(INavigationService navigationService)
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
        private ObservableCollection<Contacts> _contactList;
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
        private readonly INavigationService _navigationService;
        public ICommand AddCommand { get; set; }
        public ICommand ContactCommand { get; set; }


        private string _contactName;
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
        private string _mobileNumber;
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
            await _navigationService.NavigateAsync("ViewContactList");
        }
    }
    public class Contacts
    {
        public string Name { get; set; }
        public string Number { get; set; }
    }
}