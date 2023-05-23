using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomSelenium.Elements
{
    public class TextField
    {
        private IWebElement Element;
        private WebDriverWait Wait;
        private By ByLocator;

        public TextField(By byLocator, long timeout = 1500)
        {
            this.ByLocator = byLocator;
            this.Wait = new WebDriverWait(SeleniumManager.GetWebDriver(), new TimeSpan(0,0,3));            
        }


        public TextField() { }
        public void ClearAndFillTextField(String value)
        {
            this.Element = Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(ByLocator));
            Element.Clear();
            Element.SendKeys(value);
        }
    }
}
