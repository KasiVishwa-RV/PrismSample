using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Threading.Tasks;
using Prism.Services;
using PrismSampleApp.Views;
using PrismSampleApp.Services.Interfaces;
using PrismSampleApp.Repository.Interfaces;
using PrismSampleApp.Model;
using PrismSampleApp.Resx;

namespace PrismSampleApp.ViewModels
{
    public class LoginPageViewModel :ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IPageDialogService _pageDialogService;
        private readonly IEmployeeRepository<EmployeeModel> _employeeRepository;
        private string _username;
        private string _password;
        public ICommand LoginCommand { get; set; }
        public ICommand SignUpCommand { get; set; }
        public LoginPageViewModel(INavigationService NavigationService , IPageDialogService pageDialogService , IEmployeeRepository<EmployeeModel> employeeRepository)
        {
            _navigationService = NavigationService;
            _employeeRepository = employeeRepository;
            //_employeeRepository.Insert(new EmployeeModel { Email = "john", Password = "54321" });
            _pageDialogService = pageDialogService;
            LoginCommand = new Command(LoginCommandHandler);
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
               SetProperty(ref _password , value);
                
            }
        }
        public async void LoginCommandHandler()
        {
            var result = await _employeeRepository.Get();
            var user = result.Where(x => x.Email == Username && x.Password == Password);
            if (user!=null)
            {
                await _navigationService.NavigateAsync("MainPage");
            }
            else
            {
                await _pageDialogService.DisplayAlertAsync(AppResource.LoginPage,AppResource.WrongCredentials, "Retry");
            }
        }
        public async void SignUpCommandHandler()
        {
            await _navigationService.NavigateAsync("SignUpPage");
        }
    }
}