using eCoreTestChallenge.Report;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace eCoreTestChallenge.CustomSelenium
{
    public static class CustomSeleniumManager
    {
        private static IWebDriver? _driver;

        private static IWebDriver GetWebDriver() => _driver ?? throw new Exception("No driver session available");

        public static void StartSession(string url)
        {
        ChromeOptions options = new ();
        options.AddArgument("headless");

            _driver ??= new ChromeDriver(url, options);
            _driver.Navigate().GoToUrl(url);
        }

        public static void FinishSession()
        {
            _driver?.Quit();
            _driver = null;
        }

        public static WebDriverWait GetDriverWait(int timeoutSeconds)
        {
            return new WebDriverWait(GetWebDriver(), new TimeSpan(0, 0, timeoutSeconds));
        }


        public static void SelectNextTab()
        {
            IList<string> allTabs = new List<string>(GetWebDriver().WindowHandles);
            allTabs.Remove(GetWebDriver().CurrentWindowHandle);

            GetWebDriver().SwitchTo().Window(allTabs.First());
        }
        public static void TakeScreenShot(string filePath)
        {
            string fileName = Reporter.NowString() + ".png";

            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);

            ITakesScreenshot screenshooter = _driver as ITakesScreenshot;
            Screenshot screenshot = screenshooter.GetScreenshot();

            screenshot.SaveAsFile(filePath + fileName, ScreenshotImageFormat.Png);
            Reporter.AttachScreenShot(filePath + fileName + ".png");
        }
    }
}