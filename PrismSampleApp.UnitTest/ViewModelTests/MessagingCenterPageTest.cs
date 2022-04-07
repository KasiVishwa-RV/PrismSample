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
            //Arrange
            string Messages = $"Visited the page @ {DateTime.Now}";
            //string msg = $"Visited the page @ {DateTime.Now}";
            _messagingCenter.Setup(x => x.Subscribe<MessagingCenterPageViewModel, DateTime>(this, "Hi", DateTime.Now));
            
            NavigationService.Setup(x => x.NavigateAsync("MessagingCenterPage")).ReturnsAsync(_fixture.Create<NavigationResult>());

            //Act
            _messagingCenter.Setup(x=>x.Send(this, "Hi", DateTime.Now));
            //MessagingCenter.Subscribe<MessagingCenterPageViewModel, DateTime>(this, "Hi", (p, DateTime) =>
            //{
            //    homePageViewModel.Messages = $"Visited the page @ {DateTime.Now}";
            //});
            homePageViewModel.GoToMessagingCenterPageCommand.Execute(new());
            //_messagingCenter.Send<MessagingCenterPageViewModel, DateTime>(messagingCenterPageViewModel, "Hi", DateTime.Now);

            //Assert
            NavigationService.Verify(x => x.NavigateAsync("MessagingCenterPage"));
            
            
        }
    }
}
