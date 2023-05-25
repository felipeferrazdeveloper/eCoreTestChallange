using CustomSelenium.ElementObjects.Element;
using eCoreTestChallenge.Data.PageData;
using NUnit.Framework;
using OpenQA.Selenium;

namespace eCoreTestChallenge.PageObjects.Page;

    public class InvoiceDetailsPage : PageObject
    {
        TextLabel HotelName = new TextLabel(By.CssSelector("h4"));
        TextLabel InvoiceNumber = new TextLabel(By.CssSelector("h6"));
        ListTextLabel InvoiceDate = new ListTextLabel(By.XPath("//span[text()='Invoice Date:']/parent::li"));
        ListTextLabel DueDate = new ListTextLabel(By.XPath("//span[text()='Due Date:']/parent::li"));        
        TextLabel BookingCode = new TextLabel(By.XPath("//td[text()='Booking Code']/following-sibling::td"));
        TextLabel Room = new TextLabel(By.XPath("//td[text()='Room']/following-sibling::td"));
        TextLabel TotalStayCount = new TextLabel(By.XPath("//td[text()='Total Stay Count']/following-sibling::td"));
        TextLabel TotalStayAmount = new TextLabel(By.XPath("//td[text()='Total Stay Amount']/following-sibling::td"));
        TextLabel CheckIn = new TextLabel(By.XPath("//td[text()='Check-In']/following-sibling::td"));
        TextLabel CheckOut = new TextLabel(By.XPath("//td[text()='Check-Out']/following-sibling::td"));
        TextLabel CustomerDetails = new TextLabel(By.XPath("//div/br/parent::div"));
        HorizontalTable BillingDetails = new HorizontalTable(By.XPath("//h5[text()='Billing Details']/following-sibling::table"));

        public override InvoiceDetailsPage AssureUserIsOnPage()
        {
            return (InvoiceDetailsPage)this.AssureUserIsOnPage("Invoice Details");
        }

        public InvoiceDetailsPage ValidateInvoiceData(InvoiceData data)
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(data.HotelName, HotelName.GetText());
                Assert.AreEqual(data.InvoiceNumber, InvoiceNumber.GetText());
                Assert.AreEqual(data.InvoiceDate, InvoiceDate.GetText());
                Assert.AreEqual(data.DueDate, DueDate.GetText());                
                Assert.AreEqual(data.BookingCode, BookingCode.GetText());
                Assert.AreEqual(data.Room, Room.GetText());
                Assert.AreEqual(data.TotalStayCount, TotalStayCount.GetText());
                Assert.AreEqual(data.TotalStayAmount, TotalStayAmount.GetText());
                Assert.AreEqual(data.CheckIn, CheckIn.GetText());
                Assert.AreEqual(data.CheckOut, CheckOut.GetText());
                Assert.AreEqual(data.CustomerDetails, CustomerDetails.GetText());                                
                Assert.AreEqual(data.DepositNow, BillingDetails.GetTableDataValue("Deposit Nowt"));
                Assert.AreEqual(data.TaxAndVAT, BillingDetails.GetTableDataValue("Tax&VAT"));
                Assert.AreEqual(data.TotalAmount, BillingDetails.GetTableDataValue("Total Amount"));
            });
            return this;
        }
    }
}