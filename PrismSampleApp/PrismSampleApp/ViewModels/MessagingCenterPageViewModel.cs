using Prism.Navigation;
using PrismSampleApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PrismSampleApp.ViewModels
{
	public class MessagingCenterPageViewModel : ViewModelBase
	{
		private readonly INavigationService _navigationService;

		public MessagingCenterPageViewModel (INavigationService NavigationService)
		{
			_navigationService = NavigationService;
			SendMessageCommand = new Command(SendMessageCommandHandler);	
		}
		public ICommand SendMessageCommand { get; set; }
		public void SendMessageCommandHandler()
		{
			MessagingCenter.Send<MessagingCenterPageViewModel, DateTime>(this, "Hi", DateTime.Now);
		}
	}
}