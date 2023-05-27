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
               DateTime.Now.Second, DateTime.Now.Millisecond).Trim();
        }
            

        public static void OneTimeSetup()
        {
            var htmlReporter = new ExtentHtmlReporter(Folder + $"reports\\{NowString()}\\")
            {
                AnalysisStrategy = AnalysisStrategy.Class,
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
            _currentNode.Model.Status = Status.Warning;
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

        public static void TestTearDown(TestContext.ResultAdapter result)
        {
            if (result.FailCount > 0)
            {
                string message = result.Message;
                string tMessage = AssertMessageTreatment(message);
                _currentNode.Fail(tMessage);
            }
                
            else
                _currentNode.Pass("Test finished successfully!");

        }

        public static void FlushReport()
        {
            _extent.Flush();
        }

        public  static string AssertMessageTreatment(string message)
        {
            message = message.Trim();
            int expectedLength;
            int actualLength;
            int diffIndex;
            string expectedString;
            string actualString;

            string expectedLengthRegex = @"Expected string length (\d+)";
            string actualLengthRegex = @"but was (\d+)";
            string indexDiffRegex = @"Strings differ at index (\d+)";
            string expectedStringRegex = @"Expected: ""(.*?)""";
            string actualStringRegex = @"But was:  ""(.*?)""";


            Match match = Regex.Match(message, expectedLengthRegex);
            expectedLength = int.Parse(match.Groups[1].Value);

            if (match.Success)
            {

                match = Regex.Match(message, actualLengthRegex);
                actualLength = int.Parse(match.Groups[1].Value);
                match = Regex.Match(message, indexDiffRegex);
                diffIndex = int.Parse(match.Groups[1].Value);
                match = Regex.Match(message, expectedStringRegex);
                expectedString = match.Groups[1].Value;
                match = Regex.Match(message, actualStringRegex);
                actualString = match.Groups[1].Value;

                string diffString = actualString.Substring(diffIndex);

                string output = "<span style='color:red'><b>Assertion failed</b></span><br/>" +
                                "Expected string: <span style='color:green'>" + expectedString+"</span><br/>" +
                                "Actual   string: <span style='color:red'>" + actualString+"</span><br/>" +
                                "The difference begins at \"<b>" + diffString+"</b>\"";
                return output;
            }
            return message;
        }
    }
}
