using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CustomSelenium.ElementObjects;

public abstract class ElementObject
{
    private IWebElement? Element { get; set; }
    private WebDriverWait Wait { get; set; }
    private By ByLocator { get; set; }

    protected ElementObject(By byLocator, int timeoutSeconds)
    {
        this.ByLocator = byLocator;
        this.Wait = CustomSeleniumManager.GetDriverWait(timeoutSeconds);
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
            throw new Exception($"Element not visible! Timeout after {Wait.Timeout.TotalSeconds} seconds. " + ex);
        }
        return this.Element;
    }       
}