using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Configuration;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;

namespace eCoreTestChallenge.Report
{
    public static class Reporter
    {
        private static ExtentReports _extent;
        private static ExtentTest scenario;

        static Reporter()
        {
            var now = $"{DateTime.Now.Year}{DateTime.Now.Month}{DateTime.Now.Day}{DateTime.Now.Hour}{DateTime.Now.Minute}";

            var directory = Regex.Match(Directory.GetCurrentDirectory(), ".+(?=\\\\bin\\\\Debug\\\\net6.0)").Value;
            directory += "\\ReportOutput";

            var htmlReporter = new ExtentHtmlReporter(directory + $"Report_{now}.html")
            {
                AnalysisStrategy = AnalysisStrategy.Test,
                Config =
                {
                    Theme = Theme.Dark,
                    DocumentTitle = "Test Report"
                }
            };

            _extent = new ExtentReports();

            _extent.AddSystemInfo("Environment", "PRD");
            _extent.AddSystemInfo("Selenium", "v4.9.1");
            _extent.AddSystemInfo("WebDriver", "ChromeDriver");
            _extent.AddSystemInfo("NUnit", "v3.13.3");

            _extent.AttachReporter(htmlReporter);
        }
        

        public static void BeforeFeature()
        {

        }

        public static void BeforeScenario(string testname)
        {
            scenario = _extent.CreateTest(testname);
        }

        public static void AfterStep()
        {

        }

        public static void TearDown()
        {
            _extent.Flush();
        }
    }
}
