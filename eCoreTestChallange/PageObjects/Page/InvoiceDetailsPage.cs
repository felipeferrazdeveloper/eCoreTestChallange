using CustomSelenium.ElementObjects.Element;
using eCoreTestChallenge.Data.PageData;
using NUnit.Framework;
using OpenQA.Selenium;

namespace eCoreTestChallenge.PageObjects.Page;

public class InvoiceDetailsPage : PageObject
{
    private readonly TextLabel _hotelName = new(By.CssSelector("h4"));
    private readonly TextLabel _invoiceNumber = new(By.CssSelector("h6"));
    private readonly ListTextLabel _invoiceDate = new(By.XPath("//span[text()='Invoice Date:']/parent::li"));
    private readonly ListTextLabel _dueDate = new(By.XPath("//span[text()='Due Date:']/parent::li"));
    private readonly TextLabel _bookingCode = new(By.XPath("//td[text()='Booking Code']/following-sibling::td"));
    private readonly TextLabel _room = new(By.XPath("//td[text()='Room']/following-sibling::td"));
    private readonly TextLabel _totalStayCount = new(By.XPath("//td[text()='Total Stay Count']/following-sibling::td"));
    private readonly TextLabel _totalStayAmount = new(By.XPath("//td[text()='Total Stay Amount']/following-sibling::td"));
    private readonly TextLabel _checkIn = new(By.XPath("//td[text()='Check-In']/following-sibling::td"));
    private readonly TextLabel _checkOut = new(By.XPath("//td[text()='Check-Out']/following-sibling::td"));
    private readonly TextLabel _customerDetails = new(By.XPath("//div/br/parent::div"));
    private readonly HorizontalTable _billingDetails = new(By.XPath("//h5[text()='Billing Details']/following-sibling::table"));

    public override InvoiceDetailsPage AssureUserIsOnPage()
    {
        return (InvoiceDetailsPage)this.AssureUserIsOnPage("Invoice Details");
    }

    public InvoiceDetailsPage ValidateInvoiceData(InvoiceData data)
    {
        Assert.Multiple(() =>
        {
            Assert.AreEqual(data.HotelName, _hotelName.GetText());
            Assert.AreEqual(data.InvoiceNumber, _invoiceNumber.GetText());
            Assert.AreEqual(data.InvoiceDate, _invoiceDate.GetText());
            Assert.AreEqual(data.DueDate, _dueDate.GetText());                
            Assert.AreEqual(data.BookingCode, _bookingCode.GetText());
            Assert.AreEqual(data.Room, _room.GetText());
            Assert.AreEqual(data.TotalStayCount, _totalStayCount.GetText());
            Assert.AreEqual(data.TotalStayAmount, _totalStayAmount.GetText());
            Assert.AreEqual(data.CheckIn, _checkIn.GetText());
            Assert.AreEqual(data.CheckOut, _checkOut.GetText());
            Assert.AreEqual(data.CustomerDetails, _customerDetails.GetText());                                
            Assert.AreEqual(data.DepositNow, _billingDetails.GetTableDataValue("Deposit Now"));
            Assert.AreEqual(data.TaxAndVat, _billingDetails.GetTableDataValue("Tax&VAT"));
            Assert.AreEqual(data.TotalAmount, _billingDetails.GetTableDataValue("Total Amount"));
        });
        return this;
    }
}