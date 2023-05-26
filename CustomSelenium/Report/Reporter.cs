using System.Text.RegularExpressions;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using NUnit.Framework;

namespace eCoreTestChallenge.Report
{
    public static class Reporter
    {
        private static ExtentReports _extent;
        private static ExtentTest? _test;
        private static string _testDescription;
        public static string Folder;

        public static void SetUpReport()
        {
            Folder = Regex.Match(Directory.GetCurrentDirectory(), ".+(?=\\\\eCoreTestChallenge\\\\bin\\\\Debug\\\\net6.0)").Value + "\\Output\\";

            var htmlReporter = new ExtentHtmlReporter(Folder + $"\\Report_{NowString()}\\report.html")
            {
                Config =
                {
                    Theme = Theme.Dark,
                    DocumentTitle = "eCore Test Report"
                }
            };
            

            _extent = new ExtentReports();

            _extent.AddSystemInfo("Environment", "PRD");
            _extent.AddSystemInfo("Selenium", "v4.9.1");
            _extent.AddSystemInfo("WebDriver", "ChromeDriver");
            _extent.AddSystemInfo("NUnit", "v3.13.3");

            _extent.AttachReporter(htmlReporter);
        }

        public static void SetTestName(string testname)
        {
            if (!testname.Equals(_testDescription))
            {
                _test = _extent.CreateTest(testname);
                _testDescription = testname;
            }
        }

        public static void SetTestData(BaseData data)
        {

        }

        public static void FinishStepNode()
        {
        }

        public static void AddStepToNode()
        {

        }

        public static void AfterTest(TestContext.ResultAdapter result)
        {
            if (result.FailCount > 0)
                _test.Fail(result.Message);
            else
                _test.Pass("Success!");
        }

        public static void TearDown()
        {
            
            _extent.Flush();
        }

        private static string NowString() =>
            $"{DateTime.Now.Year}{DateTime.Now.Month}{DateTime.Now.Day}{DateTime.Now.Hour}{DateTime.Now.Minute}";
    }
}
