using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Prism.Navigation;
using Prism.Services;
using PrismSampleApp.ViewModels;
using PrismSampleApp.Views;
using System.Threading.Tasks;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace PrismSampleApp.UnitTest
{
    public class UnitTest
    {
        private readonly Mock<INavigationService> NavigationService;
        private readonly Mock<IPageDialogService> PageDialogService;
        private readonly LoginPageViewModel viewModel;
        private readonly Fixture _fixture = new Fixture();
        public UnitTest()
        {
            NavigationService = new Mock<INavigationService>();
            PageDialogService = new Mock<IPageDialogService>();
            viewModel = new LoginPageViewModel(NavigationService.Object,PageDialogService.Object);
        }
    [Fact]
        public void Login_With_Valid_Credentials()
        {
            //Arrange
            var username = _fixture.Create<string>();
            var password = _fixture.Create<string>();
            //Act
            NavigationService.Setup(x => x.NavigateAsync("MainPage")).ReturnsAsync(_fixture.Create<NavigationResult>());
            PageDialogService.Setup(x => x.DisplayAlertAsync("LoginPage", "Wrong Credentials", "", "Retry"));
            viewModel.Username = "admin";
            viewModel.Password = "123";
            viewModel.LoginCommand.Execute(new());
            //Assert
            NavigationService.Verify(x => x.NavigateAsync("MainPage"));  
        }

        [Fact]
        public void Login_With_InValid_Credentials()
        {
            //Arrange
            var username = _fixture.Create<string>();
            var password = _fixture.Create<string>();
            //Act
            PageDialogService.Setup(x => x.DisplayAlertAsync("LoginPage", "Wrong Credentials", "Retry"));
            viewModel.Username = username ;
            viewModel.Password = password;
            viewModel.LoginCommand.Execute(new());
            //Assert
            PageDialogService.Verify(x => x.DisplayAlertAsync("LoginPage", "Wrong Credentials", "Retry"));
        }
        [Fact]
        public void Login_With_Valid_UserName_Invalid_Password()
        {
            var password = _fixture.Create<string>();
            //Act
            PageDialogService.Setup(x => x.DisplayAlertAsync("LoginPage", "Wrong Credentials", "Retry"));
            viewModel.Username = null;
            viewModel.Password = null;
            viewModel.LoginCommand.Execute(new());
            //Assert
            PageDialogService.Verify(x => x.DisplayAlertAsync("LoginPage", "Wrong Credentials", "Retry"));
        }
        [Fact]
        public void Login_With_InValid_UserName_Valid_Password()
        {
            var username = _fixture.Create<string>();
            //Act
            PageDialogService.Setup(x => x.DisplayAlertAsync("LoginPage", "Wrong Credentials", "Retry"));
            //Arrange
            viewModel.Username = username;
            viewModel.Password = "123";
            viewModel.LoginCommand.Execute(new());
            //Assert
            PageDialogService.Verify(x => x.DisplayAlertAsync("LoginPage", "Wrong Credentials", "Retry"));
        }
        [Fact]
        public void Login_With_Blank_UserName_Blank_Password()
        {
            //Arrange
            
            //Act
            PageDialogService.Setup(x => x.DisplayAlertAsync("LoginPage", "Wrong Credentials", "Retry"));
            viewModel.Username = null;
            viewModel.Password = null;
            viewModel.LoginCommand.Execute(new());
            //Assert
            PageDialogService.Verify(x => x.DisplayAlertAsync("LoginPage", "Wrong Credentials", "Retry"));
        }
        [Fact]
        public void Login_With_Valid_UserName_Blank_Password()
        {
            //Arrange
            //Act
            PageDialogService.Setup(x => x.DisplayAlertAsync("LoginPage", "Wrong Credentials", "Retry"));
            viewModel.Username = "admin";
            viewModel.Password = null;
            viewModel.LoginCommand.Execute(new());
            //Assert
            PageDialogService.Verify(x => x.DisplayAlertAsync("LoginPage", "Wrong Credentials", "Retry"));

        }
        [Fact]
        public void Login_With_InValid_UserName_Blank_Password()
        {
            var username = _fixture.Create<string>();
            //Arrange
            PageDialogService.Setup(x => x.DisplayAlertAsync("LoginPage", "Wrong Credentials", "Retry"));
            viewModel.Username = username;
            viewModel.Password = null;
            //Act
            viewModel.LoginCommand.Execute(new());
            //Assert
            PageDialogService.Verify(x => x.DisplayAlertAsync("LoginPage", "Wrong Credentials", "Retry"));
        }
        [Fact]
        public void Login_With_Blank_UserName_Valid_Password()
        {
            //Arrange
            //Act
            PageDialogService.Setup(x => x.DisplayAlertAsync("LoginPage", "Wrong Credentials", "Retry"));
            viewModel.Username = null;
            viewModel.Password = "123";
            viewModel.LoginCommand.Execute(new());
            //Assert
            PageDialogService.Verify(x => x.DisplayAlertAsync("LoginPage", "Wrong Credentials", "Retry"));
        }
        [Fact]
        public void Login_With_Blank_UserName_InValid_Password()
        {
            var password = _fixture.Create<string>();
            //Arrange
            //Act
            PageDialogService.Setup(x => x.DisplayAlertAsync("LoginPage", "Wrong Credentials", "Retry"));
            viewModel.Username = null;
            viewModel.Password = password;
            viewModel.LoginCommand.Execute(new());
            //Assert
            PageDialogService.Verify(x => x.DisplayAlertAsync("LoginPage", "Wrong Credentials", "Retry"));
        }
    }
}