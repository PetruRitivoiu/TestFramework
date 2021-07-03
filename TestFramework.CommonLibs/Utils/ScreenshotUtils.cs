using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TestFramework.CommonLibs.Utils
{
    public class ScreenshotUtils
    {
        private ITakesScreenshot camera;

        public ScreenshotUtils(IWebDriver webDriver)
        {
            camera = webDriver as ITakesScreenshot;
        }

        public void TakeScreenshot(string filename)
        {
            _ = filename.Trim();

            if (File.Exists(filename))
            {
                throw new Exception("file already exists");
            }

            var screenshot = camera.GetScreenshot();
            screenshot.SaveAsFile(filename);
        }
    }
}
