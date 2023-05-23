using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CustomSelenium
{
    public class SeleniumManager
    {
        static IWebDriver driver;

        static public IWebDriver GetWebDriver() {
            if (driver == null)
            {
                driver = new ChromeDriver();
                driver.Url = "https://automation-sandbox-python-mpywqjbdza-uc.a.run.app";
            }
            
            return driver; 
        }

        
    }
}