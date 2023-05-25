using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CustomSelenium
{
    public class CustomSeleniumManager
    {
        private static IWebDriver? Driver;

        static public IWebDriver GetWebDriver() => Driver ?? throw new Exception("No driver session available");

        public static void StartSession(String url)
        {
            Driver ??= new ChromeDriver(url);
            Driver.Navigate().GoToUrl(url);
        }

        public static void FinishSession()
        {
            Driver?.Quit();
            Driver = null;
        }

        public static void SelectNextTab()
        {            
            IList<String> allTabs = new List<String>(GetWebDriver().WindowHandles);
            allTabs.Remove(GetWebDriver().CurrentWindowHandle);                        
            
            GetWebDriver().SwitchTo().Window(allTabs.First());
        }
    }
}