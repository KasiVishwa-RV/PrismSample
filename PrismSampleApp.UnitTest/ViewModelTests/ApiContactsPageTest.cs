using AutoFixture;
using Moq;
using Prism.Navigation;
using Prism.Services;
using PrismSampleApp.Services.Interfaces;
using PrismSampleApp.Model;
using PrismSampleApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;

namespace PrismSampleApp.UnitTest.ViewModelTests
{
    public class ApiContactsPageTest
    {
        private readonly Mock<INavigationService> _navigationService;
        private readonly Mock<IPageDialogService> _pageDialogService;
        private readonly Mock<IWebApiService> _webApiService;
        private readonly ApiContactsPageViewModel apiContactsPageViewModel;
        private readonly Fixture _fixture = new Fixture();


        public ApiContactsPageTest()
        {
            _navigationService = new Mock<INavigationService>();
            _pageDialogService = new Mock<IPageDialogService>();
            _webApiService = new Mock<IWebApiService>();
            apiContactsPageViewModel = new ApiContactsPageViewModel(_navigationService.Object, _pageDialogService.Object, _webApiService.Object);
        }

        [Fact]
        public void Will_Save_RandomApiService_Data_to_ApiData()
        {
            //Arrange
            var apiData = _fixture.Build<Result>().CreateMany(50).ToList();

            //Act
            _webApiService.Setup(x => x.IntializingService()).ReturnsAsync(apiData);
            apiContactsPageViewModel.ClickCommand.Execute(new());

            //Assert
            Assert.Equal(apiData,apiContactsPageViewModel.ApiContacts);
        }

        [Fact]
        public void Will_Navigate_to_DetailedPage()
        {
            //Arrange
            var apiData = _fixture.Build<Result>().CreateMany(50).ToList();
            var list = apiData.Where(x => x == apiData.FirstOrDefault()).ToList();
            var specificData = list.FirstOrDefault();

            //Act
            apiContactsPageViewModel.ApiContacts = apiData;
            apiContactsPageViewModel.ItemTappedCommand.Execute(new());

            //Assert
            _navigationService.Verify(x => x.NavigateAsync("ViewContactListPage", It.Is<NavigationParameters>(x => x.ContainsKey("TappedData"))));
        }
    }
}
