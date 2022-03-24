using Prism.Commands;
using PrismSampleApp.ApplicationCommand;
using PrismSampleApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrismSampleApp.ViewModels
{
    public class WorldTimePageViewModel:ViewModelBase
    {
        public DelegateCommand ShowTimeACommand { get; set; }
        public DelegateCommand ShowTimeBCommand { get; set; }
        private string _time;
        private string _utcTime;
        private IApplicationCommands _applicationCommands;
        public IApplicationCommands ApplicationCommands
        {
            get { return _applicationCommands; }
            set { SetProperty(ref _applicationCommands, value); }
        }
        public WorldTimePageViewModel(IApplicationCommands applicationCommands)
        {
            ApplicationCommands = applicationCommands;
            ShowTimeACommand = new DelegateCommand(ShowTimeACommandHandler);
            ShowTimeBCommand = new DelegateCommand(ShowTimeBCommandHandler);
            applicationCommands.ShowAllCommand.RegisterCommand(ShowTimeACommand);
            applicationCommands.ShowAllCommand.RegisterCommand(ShowTimeBCommand);
        }
        public string Time 
        { 
            get 
            { 
                return _time; 
            }
            set
            {
                SetProperty(ref _time, value);
            }
        }
        public string UtcTime
        {
            get
            {
                return _utcTime;
            }
            set
            {
                SetProperty(ref _utcTime, value);
            }
        }
        public void ShowTimeACommandHandler()
        {
            Time = $"Time:{DateTime.Now}";
        }
        public void ShowTimeBCommandHandler()
        {
            UtcTime = $"Time:{Time}";
        }
    }
}
