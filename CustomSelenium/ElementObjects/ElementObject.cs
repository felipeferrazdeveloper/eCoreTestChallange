using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CustomSelenium.ElementObjects
{
    public abstract class ElementObject
    {
        private IWebElement Element { get; set; }
        protected WebDriverWait Wait { get; set; }
        protected By ByLocator { get; set; }

        protected ElementObject(By byLocator, int timeoutSeconds)
        {
            this.ByLocator = byLocator;
            this.Wait = new WebDriverWait(CustomSeleniumManager.GetWebDriver(), new TimeSpan(0, 0, timeoutSeconds));            
        }

        protected IWebElement GetVisibleElement()
        {
            try
            {
                this.Element = Wait.Until(SeleniumExtras.WaitHelpers
                    .ExpectedConditions.ElementExists(ByLocator));
            }
            catch (TimeoutException ex)
            {
                throw new Exception(String.Format("Element not visible! Timeout after {0} seconds. ", Wait.Timeout.TotalSeconds) + ex);
            }
            return this.Element;
        }
    }
}
