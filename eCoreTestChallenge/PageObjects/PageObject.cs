using AventStack.ExtentReports;
using CustomSelenium.ElementObjects.Element;
using eCoreTestChallenge.Report;
using NUnit.Framework;
using OpenQA.Selenium;

namespace eCoreTestChallenge.PageObjects
{
    public abstract class PageObject
    {
        private TextLabel? _pageHeader;

        public abstract PageObject AssureUserIsOnPage();
      
        protected PageObject AssureUserIsOnPage(string expectedValue, By? by=null)
        {
            if (by == null)
                by = By.CssSelector("h2");
            _pageHeader = new TextLabel(by);
            Assert.AreEqual(expectedValue, _pageHeader.GetText());
            Reporter.Log(Status.Pass, $"Assured that user is on {expectedValue}  page.");
            return this;
        }
    }
}