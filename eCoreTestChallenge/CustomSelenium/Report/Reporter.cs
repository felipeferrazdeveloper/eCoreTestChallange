using System.Text.RegularExpressions;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using eCoreTestChallenge.Data.PageData;
using NUnit.Framework;
using OpenQA.Selenium;

namespace eCoreTestChallenge.Report
{
    public static class Reporter
    {
        private static ExtentReports _extent;
        private static ExtentTest _testCase;
        private static string _currentTestName;
        private static int _currentDataSetNumber;
        private static ExtentTest _currentNode;


        public static string Folder = Regex.Match(Directory.GetCurrentDirectory(), ".+(?=\\\\eCoreTestChallenge\\\\bin\\\\Debug\\\\net6.0)").Value + "\\Output\\";
        public static string ScreenShotFolder = Folder + "\\screenshots\\";

        public static string NowString()
        {
            return String.Format("{0,4:D}_{1,2:D2}_{2,2:D2}_{3,2:D2}.{4,2:D2}.{5,2:D2}.{6,4:D4}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute,
               DateTime.Now.Second, DateTime.Now.Millisecond);
        }
            

        public static void OneTimeSetup()
        {
            var htmlReporter = new ExtentHtmlReporter(Folder + $"reports\\{NowString()}\\")
            {
                Config =
                {
                    EnableTimeline = true,
                    Theme = Theme.Dark,
                    DocumentTitle = "eCore Test Report",
                }
            };

            _extent = new ExtentReports();


            //To be filled with environment variables
            _extent.AddSystemInfo("Environment", "PRD");
            _extent.AddSystemInfo("Selenium", "v4.9.1");
            _extent.AddSystemInfo("WebDriver", "ChromeDriver");
            _extent.AddSystemInfo("NUnit", "v3.13.3");

            _extent.AttachReporter(htmlReporter);
        }

        public static void TestSetup(string testName, string testData)
        {
            if (!testName.Equals(_currentTestName))
            {
                _testCase = _extent.CreateTest(testName);
                _currentTestName = testName;
                _currentDataSetNumber = 1;
            }
            _currentNode = _testCase.CreateNode(String.Format(testData,_currentDataSetNumber));
            _currentDataSetNumber++;
        }

        /// <summary>
        /// Attach a screenshot to current node Report
        /// </summary>
        /// <param name="filePath">Full Path of screenshot including filename and extension</param>
        public static void AttachScreenShot(string filePath)
        {
            _currentNode.AddScreenCaptureFromPath(filePath);
        }

        /// <summary>
        /// Log a info or Step in test node
        /// </summary>
        /// <example>Possible Status:
        /// <code>
        ///     public enum Status
        /// {
        /// Pass,
        /// Fail,
        /// Fatal,
        /// Error,
        /// Warning,
        /// Skip,
        /// }
    /// </code>.
    /// Info and Debug are not valid status for this method
    /// </example>
    /// <param name="status">Enum of Status </param>
    /// <param name="message"></param>
        public static void Log(Status status, string message)
        {
            if (status != Status.Pass)
                _testCase.Fail(message);
              
            _currentNode.Log(status, message);
        }

        public static void LogInputData(string fieldName, string value)
        { 
            Log(Status.Pass, $"User filled {fieldName} with: <b>{value}</b>");
        }

        public static void LogUserAction(string actionName, string elementName)
        {
            Log(Status.Pass, $"User {actionName} on {elementName}");
        }
        public static void LogException(Exception exception)
        {
            if(exception.GetType() != typeof(AssertionException))
                _currentNode.Fail(exception);
        }

        public static void TestTearDown(TestContext.ResultAdapter result)
        {
            if (result.FailCount > 0)
                _currentNode.Fail(result.Message);
            else
                _currentNode.Pass("Test finished successfully!");

        }

        public static void FlushReport()
        {
            _extent.Flush();
        }
    }
}
