using CustomSelenium.ElementObjects.Element;
using NUnit.Framework;
using OpenQA.Selenium;

namespace eCoreTestChallenge.PageObjects;

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
        return this;
    }
}