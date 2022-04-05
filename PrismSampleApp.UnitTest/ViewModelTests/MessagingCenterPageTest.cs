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
        private readonly MessagingCenterPageViewModel messagingCenterPageViewModel;
        private readonly HomePageViewModel homePageViewModel;
        private readonly Fixture _fixture = new Fixture();
        public MessagingCenterPageTest()
        {
            NavigationService = new Mock<INavigationService>();
            messagingCenterPageViewModel = new MessagingCenterPageViewModel(NavigationService.Object);
            homePageViewModel = new HomePageViewModel(NavigationService.Object);
        }
        [Fact]
        public void MessageSubscription()
        {
            //Arrange
            var Messages = false;
            MessagingCenter.Subscribe<MessagingCenterPageViewModel, DateTime>(this, "Hi", (p, DateTime) =>
            {
                Messages = true;
            });
            //Act
            homePageViewModel.GoToMessagingCenterPageCommand.Execute(new());
            NavigationService.Verify(x => x.NavigateAsync("MessaginCenterPage"));
            //MessagingCenter.Send<MessagingCenterPageViewModel, DateTime>(messagingCenterPageViewModel, "Hi", DateTime.Now);

            //Assert
            Assert.True(Messages);
        }
    }
}
