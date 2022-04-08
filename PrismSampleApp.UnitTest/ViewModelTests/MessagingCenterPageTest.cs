using AutoFixture;
using Moq;
using Prism.Navigation;
using PrismSampleApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xunit;

namespace PrismSampleApp.UnitTest.ViewModelTests
{
    public class MessagingCenterPageTest
    {
        private readonly Mock<INavigationService> NavigationService;
        private readonly Mock<IMessagingCenter> _messagingCenter;
        private readonly MessagingCenterPageViewModel messagingCenterPageViewModel;
        private readonly HomePageViewModel homePageViewModel;
        private readonly Fixture _fixture = new Fixture();
        public MessagingCenterPageTest()
        {
            NavigationService = new Mock<INavigationService>();
            _messagingCenter = new Mock<IMessagingCenter>();
            messagingCenterPageViewModel = new MessagingCenterPageViewModel(NavigationService.Object,_messagingCenter.Object);
            homePageViewModel = new HomePageViewModel(NavigationService.Object, _messagingCenter.Object);
        }
        [Fact]
        public void MessageSubscription()
        {
        }
    }
}
