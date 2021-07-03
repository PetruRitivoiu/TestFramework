using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace TestFramework.CommonLibs.Utils
{
    public class ExtentReportUtils
    {
        private ExtentHtmlReporter extentHtmlReporter;
        private ExtentReports extentReports;
        private ExtentTest extentTest;

        public ExtentReportUtils(string reportsFolderPath)
        {
            extentHtmlReporter = new ExtentHtmlReporter(reportsFolderPath);
            extentReports = new ExtentReports();
            extentReports.AttachReporter(extentHtmlReporter);
        }

        public void CreateATestCase(string testcasename) => extentTest = extentReports.CreateTest(testcasename);

        public void AddScreenshot(string filename) => extentTest.AddScreenCaptureFromPath(filename);

        public void AddTestLog(Status status, string comment) => extentTest.Log(status, comment);

        public void FlushReport() => extentReports.Flush();

    }
}