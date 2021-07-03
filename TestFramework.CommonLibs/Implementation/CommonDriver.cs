using System;
using TestFramework.CommonLibs.Implementation.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;

namespace TestFramework.CommonLibs.Implementation
{
    public class CommonDriver
    {
        public IWebDriver Driver {get; private set;}
        public int PageLoadTimeout { private get => pageLoadTimeout; set => pageLoadTimeout = value; }
        public int ElementDetectionTimeout { private get => elementDetectionTimeout; set => elementDetectionTimeout = value; }

        private int pageLoadTimeout;
        private int elementDetectionTimeout;

        public CommonDriver(BrowserType browserType)
        {
            pageLoadTimeout = 60;
            elementDetectionTimeout = 10;

            Driver = browserType switch
            {
                BrowserType.Chrome => new ChromeDriver(),
                BrowserType.Edge => new EdgeDriver(),
                _ => throw new NotImplementedException("Invalid Browser type " + browserType)
            };
        }

        public void NavigateToFirstURL(string url){
            url = url.Trim();

            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(pageLoadTimeout);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(elementDetectionTimeout);
            Driver.Url = url;
        }

        public string PageTitle => Driver.Title;

        public void CloseBrowser()
        {
            if (Driver != null){
                Driver.Close();
            }
        }

        public void CloseAllBrowsers()
        {
            if (Driver != null){
                Driver.Quit();
            }
        }
    }
}