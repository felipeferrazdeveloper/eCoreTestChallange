
using AventStack.ExtentReports;
using eCoreTestChallenge.CustomSelenium;
using eCoreTestChallenge.Data;
using eCoreTestChallenge.ElementObjects.Element;
using eCoreTestChallenge.Report;
using OpenQA.Selenium;

namespace eCoreTestChallenge.PageObjects.Page
{
    public class InvoiceListPage : PageObject
    {
        public override InvoiceListPage AssureUserIsOnPage()
        {
            return (InvoiceListPage)this.AssureUserIsOnPage(AppLabels.Invoice_List);
        }

        public InvoiceListPage AccessFirstInvoiceDetails()
        {
            AccessInvoiceDetailsAtPosition(1);
            return this;
        }

        public InvoiceListPage AccessInvoiceDetailsAtPosition(int position)
        {
            Button invoiceLink = new(By.XPath($"//a[text()='{AppLabels.Invoice_Details}']["+position+"]"));
            invoiceLink.Click();
            Reporter.LogUserAction("Clicked", $"Invoice link at row #{position}");
            CustomSeleniumManager.SelectNextTab();
            Reporter.Log(Status.Pass, "User selected next tab");
            return this;
        }
    }
}