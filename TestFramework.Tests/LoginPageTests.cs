using TestFramework.Application.Pages;
using NUnit.Framework;

namespace TestFramework.Tests
{
    [TestFixture]
    public class HomePageTests : BaseTest
    {
        private readonly string url = "https://imdb.com";

        [Test]
        public void SearchMovieTest()
        {
            extentReportUtils.CreateATestCase("Search movie test");
            extentReportUtils.AddTestLog(AventStack.ExtentReports.Status.Info, $"{nameof(HomePageTests)} - {nameof(SearchMovieTest)} exection started");

            commonDriver.NavigateToFirstURL(url);
            var homePage = new IMDBHomePage(commonDriver.Driver);
            homePage.SearchMovie("Star Wars");

            var expectedTitle = "Find - IMDb";
            var actualTitle = commonDriver.PageTitle;

            Assert.That(expectedTitle == actualTitle);
        }

        [Test]
        public void SearchMovieTest_Fail()
        {
            extentReportUtils.CreateATestCase("Search movie fail test");
            extentReportUtils.AddTestLog(AventStack.ExtentReports.Status.Info, $"{nameof(HomePageTests)} - {nameof(SearchMovieTest_Fail)} exection started");

            commonDriver.NavigateToFirstURL(url);
            var homePage = new IMDBHomePage(commonDriver.Driver);
            homePage.SearchMovie("Star Wars");

            var expectedTitle = "Wrong title";
            var actualTitle = commonDriver.PageTitle;

            Assert.That(expectedTitle == actualTitle);
        }

        [Test]
        public void SignInButtonTest()
        {
            extentReportUtils.CreateATestCase("Facebook button test");
            extentReportUtils.AddTestLog(AventStack.ExtentReports.Status.Info, $"{nameof(SignInButtonTest)} - {nameof(SignInButtonTest)} exection started");

            commonDriver.NavigateToFirstURL(url);
            var homePage = new IMDBHomePage(commonDriver.Driver);
            homePage.ClickSignInButton();

            var expectedTitle = "Sign in with IMDb - IMDb";
            var actualTitle = commonDriver.PageTitle;

            Assert.That(expectedTitle == actualTitle);
        }
    }
}