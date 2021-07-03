using OpenQA.Selenium;

namespace TestFramework.CommonLibs.Implementation
{
    public class CommonElement
    {
        public void Click(IWebElement element) => element.Click();
        public void Clear(IWebElement element) => element.Clear();
        public void SetText(IWebElement element, string text) => element.SendKeys(text);
        public bool IsElementDisplayed(IWebElement element) => element.Displayed;
        public bool IsElementSelected(IWebElement element) => element.Selected;
        public bool IsElementEnabled(IWebElement element) => element.Enabled;
    }
}

