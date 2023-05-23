using CustomSelenium.ElementObjects.Element;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Reflection.PortableExecutable;

namespace eCoreTestChallange.PageObjects.Page
{
    public class InvoiceListPage : PageObject
    {
        public override InvoiceListPage AssertUserIsOnPage()
        {
            return (InvoiceListPage)this.AssertUserIsOnPage("Invoice List");
        }
    }


}
