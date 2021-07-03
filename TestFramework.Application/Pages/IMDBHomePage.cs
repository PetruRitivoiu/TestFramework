using TestFramework.CommonLibs.Implementation;
using OpenQA.Selenium;

namespace TestFramework.Application.Pages
{
    public class IMDBHomePage
    {      
        private readonly string searchInputCssSelector = "#suggestion-search";
        private readonly string searchButtonCssSelector = "#suggestion-search-button";

        private readonly CommonElement _commonElement;
        private readonly IWebDriver _driver;

        private IWebElement searchInput => _driver.FindElement(By.CssSelector(searchInputCssSelector));
        private IWebElement searchButton => _driver.FindElement(By.CssSelector(searchButtonCssSelector));

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
    }
}