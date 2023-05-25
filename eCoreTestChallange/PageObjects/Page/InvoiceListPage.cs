using CustomSelenium;
using CustomSelenium.ElementObjects.Elements;
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
            Button InvoiceLink = new Button(By.XPath("//a[text()='Invoice Details']["+position+"]"));
            InvoiceLink.Click();
            CustomSeleniumManager.SelectNextTab();
            return this;
        }
    }
}
