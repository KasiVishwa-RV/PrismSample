using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace PrismSampleApp.ViewModels
{
    public class AddPersonViewModel : BindableBase
    {
        public AddPersonViewModel()
        {
            PersonList = new ObservableCollection<PersonModel>
            {
                new PersonModel{Name="Karthik"},
                new PersonModel{Name="Abraham"},
                new PersonModel{Name="John"}
            };

        }
        private ObservableCollection<PersonModel> _personList;
        public ObservableCollection<PersonModel> PersonList
        {
            get
            {
                return _personList;
            }
            set
            {
                SetProperty(ref _personList, value);
            }
        }

    }
    public class PersonModel
    {
        public string Name { get; set; }
    }

}
