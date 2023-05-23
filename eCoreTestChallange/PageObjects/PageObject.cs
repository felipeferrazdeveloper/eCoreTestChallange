using CustomSelenium;
using CustomSelenium.ElementObjects.Element;
using NUnit.Framework;
using OpenQA.Selenium;

namespace eCoreTestChallange.PageObjects
{
    public abstract class PageObject
    {
        TextLabel PageHeader;

        public PageObject() 
        {
            PageHeader = new TextLabel(By.CssSelector("h2"));
        }

        public IWebDriver Driver
        {
            get => Driver;
            set => Driver = CustomSeleniumManager.GetWebDriver();
        }

        public abstract PageObject AssertUserIsOnPage();

        protected PageObject AssertUserIsOnPage(String expectedValue)
        {
            Assert.AreEqual(expectedValue, PageHeader.GetText());
            return this;
        }

    }
}
