using TestFramework.CommonLibs.Implementation;
using TestFramework.CommonLibs.Implementation.Enums;
using TestFramework.CommonLibs.Utils;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;

namespace TestFramework.Tests
{
    [TestFixture]
    public class BaseTest
    {
        public CommonDriver commonDriver;

        protected ExtentReportUtils extentReportUtils;
        protected ScreenshotUtils screenshotUtils;
        protected string reportsFolderPath = @"C:\Users\petru.ritivoiu\OneDrive - 888Holdings\Desktop\TestFramework\reports\index.html"; //weird bug from ExtentReports
        protected string screenshotFolderPath = @"C:\Users\petru.ritivoiu\OneDrive - 888Holdings\Desktop\TestFramework\screenshots\screenshot";

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            extentReportUtils = new ExtentReportUtils(reportsFolderPath);
            commonDriver = new CommonDriver(BrowserType.Chrome);
            screenshotUtils = new ScreenshotUtils(commonDriver.Driver);
        }

        [SetUp]
        public void SetUp()
        {

        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome == ResultState.Failure)
            {
                extentReportUtils.AddTestLog(AventStack.ExtentReports.Status.Fail, "One or more errors have occured");

                var filename = @$"{screenshotFolderPath}_{DateTime.Now.ToString("dd'-'MM'-'yyyy'T'HH-mm-ss")}.jpeg";
                screenshotUtils.TakeScreenshot(filename);

                extentReportUtils.AddScreenshot(filename);
            }
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            extentReportUtils.FlushReport();
            commonDriver.CloseAllBrowsers();
        }
    }
}