using CustomSelenium;
using CustomSelenium.ElementObjects.Element;
using NUnit.Framework;
using OpenQA.Selenium;

namespace eCoreTestChallenge.PageObjects;

    public abstract class PageObject
    {
        TextLabel? PageHeader;       

        public IWebDriver Driver
        {
            get => Driver;
            set => Driver = CustomSeleniumManager.GetWebDriver();
        }

        public abstract PageObject AssureUserIsOnPage();
      
        protected PageObject AssureUserIsOnPage(String expectedValue, By? by=null)
        {
            if (by == null)
                by = By.CssSelector("h2");
            PageHeader = new TextLabel(by);
            Assert.AreEqual(expectedValue, PageHeader.GetText());
            return this;
        }
    }
}
