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
       // private readonly ILogger _logger;
        private readonly IEmployeeRepository<EmployeeModel> _employeeRepository;
        private string _title;
        private string _username;
        private string _password;
        public string Title
        {
            get
            {
                return _title;

            }
            set
            {
                SetProperty(ref _title,value);
            }
        }
        public LoginPageViewModel(INavigationService NavigationService , IPageDialogService pageDialogService , IEmployeeRepository<EmployeeModel> employeeRepository)
        {
            _navigationService = NavigationService;
            _employeeRepository = employeeRepository;
            _employeeRepository.Insert(new EmployeeModel { Email = "john", Password = "54321" });
            Title = "Login Page";
            _pageDialogService = pageDialogService;
            LoginCommand = new Command(LoginCommandHandler);
            SendMessageCommand = new Command(SendMessageCommandHandler);
           // _logger = logger;
            //logger = DependencyService.Get<ILogManager>().GetLog();
        }

        public ICommand LoginCommand { get; set; }
        public ICommand SendMessageCommand { get; set; }
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
        public void SendMessageCommandHandler()
        {
                MessagingCenter.Send<LoginPageViewModel, DateTime>(this, "tick", DateTime.Now);
        }
        public async void LoginCommandHandler()
        {
            //_logger.Info("Logging");
            var result = await _employeeRepository.Get();
            var user = result.Where(x => x.Email == Username && x.Password == Password).FirstOrDefault();
            if (user!=null)
            {
                await _navigationService.NavigateAsync("MainPage");
            }
            else
            {
                await _pageDialogService.DisplayAlertAsync(AppResource.LoginPage,AppResource.WrongCredentials, "Retry");
            }
        }
    }
}