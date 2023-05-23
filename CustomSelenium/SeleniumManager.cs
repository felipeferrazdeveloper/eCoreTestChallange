using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CustomSelenium
{
    public class SeleniumManager
    {
        private static IWebDriver Driver;

        static public IWebDriver GetWebDriver() {
            if (Driver != null)
                return Driver;
            else
                throw new Exception("No driver session available");
        }

        public static void StartSession(String url)
        {
            if (Driver == null)
            {
                Driver = new ChromeDriver();
                Driver.Url = url;
            }
        }
        public static void FinishSession()
        {
            if (Driver != null)            
                Driver.Quit();            
        }
        
        public static void SelectNextTab()
        {            
            IList<String> allTabs = Driver.WindowHandles;
            allTabs.Remove(Driver.CurrentWindowHandle);                        
            
            Driver.SwitchTo().Window(allTabs.First());
        }
    }
}