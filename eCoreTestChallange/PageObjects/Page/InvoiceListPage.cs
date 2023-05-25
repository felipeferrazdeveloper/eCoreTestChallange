using CustomSelenium;
using CustomSelenium.ElementObjects.Element;
using OpenQA.Selenium;

namespace eCoreTestChallenge.PageObjects.Page;

public class InvoiceListPage : PageObject
{
    public override InvoiceListPage AssureUserIsOnPage()
    {
        return (InvoiceListPage)this.AssureUserIsOnPage("Invoice List");
    }

    public InvoiceListPage AccessFirstInvoiceDetails()
    {
        AccessInvoiceDetailsAtPosition(1);
        return this;
    }

    public InvoiceListPage AccessInvoiceDetailsAtPosition(int position)
    {
        Button invoiceLink = new(By.XPath("//a[text()='Invoice Details']["+position+"]"));
        invoiceLink.Click();
        CustomSeleniumManager.SelectNextTab();
        return this;
    }
}