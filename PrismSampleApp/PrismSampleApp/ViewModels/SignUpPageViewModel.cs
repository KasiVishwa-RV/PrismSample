using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using PrismSampleApp.Model;
using PrismSampleApp.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace PrismSampleApp.ViewModels
{
    public class SignUpPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IEmployeeRepository<EmployeeModel> _employeeRepository;
        private string _username;
        private string _password;
        private string _email;
        public ICommand SignUpCommand { get; set; }
        public SignUpPageViewModel(INavigationService navigationService, IEmployeeRepository<EmployeeModel> employeeRepository)
        {
            _navigationService = navigationService;
            _employeeRepository = employeeRepository;
            SignUpCommand = new Command(SignUpCommandHandler);
        }
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                SetProperty(ref _username, value);
            }
        }
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                SetProperty(ref _password, value);

            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                SetProperty(ref _email, value);
            }
        }
        public async void SignUpCommandHandler()
        {
            await _employeeRepository.Insert(new EmployeeModel { Email = Email, UserName = Username, Password = Password });
            await _navigationService.GoBackAsync();
        
        }
    }
}
