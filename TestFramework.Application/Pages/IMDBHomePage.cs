using TestFramework.CommonLibs.Implementation;
using OpenQA.Selenium;

namespace TestFramework.Application.Pages
{
    public class IMDBHomePage
    {      
        private readonly string searchInputCssSelector = "#suggestion-search";
        private readonly string searchButtonCssSelector = "#suggestion-search-button";
        private readonly string signInCssSelector = "#imdbHeader > div.ipc-page-content-container.ipc-page-content-container--center.navbar__inner > div._3x17Igk9XRXcaKrcG3_MXQ.navbar__user.UserMenu-sc-1poz515-0.lkfvZn > a";

        private readonly CommonElement _commonElement;
        private readonly IWebDriver _driver;

        private IWebElement searchInput => _driver.FindElement(By.CssSelector(searchInputCssSelector));
        private IWebElement searchButton => _driver.FindElement(By.CssSelector(searchButtonCssSelector));
        private IWebElement signInButton => _driver.FindElement(By.CssSelector(signInCssSelector));

        public IMDBHomePage(IWebDriver driver)
        {
            _commonElement = new CommonElement();
            _driver = driver;
        }

        public void SearchMovie(string movieTitle)
        {
            _commonElement.SetText(searchInput, movieTitle);
            _commonElement.Click(searchButton);
        }

        public void ClickSignInButton() => _commonElement.Click(signInButton);
    }
}