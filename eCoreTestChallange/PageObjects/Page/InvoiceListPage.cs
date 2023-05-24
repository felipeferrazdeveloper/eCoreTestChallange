using CustomSelenium.ElementObjects.Element;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Reflection.PortableExecutable;

namespace eCoreTestChallange.PageObjects.Page
{
    public class InvoiceListPage : PageObject
    {
        public override PageObject AssureUserIsOnPage()
        {
            return (InvoiceListPage)this.AssureUserIsOnPage("Invoice List");
        }
    }


}
