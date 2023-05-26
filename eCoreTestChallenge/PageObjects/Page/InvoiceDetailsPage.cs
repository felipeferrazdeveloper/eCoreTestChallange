using CustomSelenium.ElementObjects.Element;
using eCoreTestChallenge.Data;
using eCoreTestChallenge.Data.PageData;
using NUnit.Framework;
using OpenQA.Selenium;

namespace eCoreTestChallenge.PageObjects.Page
{
    public class InvoiceDetailsPage : PageObject
    {
        private readonly TextLabel _hotelName = new(By.CssSelector("h4"));
        private readonly TextLabel _invoiceNumber = new(By.CssSelector("h6"));
        private readonly ListTextLabel _invoiceDate = new(By.XPath($"//span[text()='{AppLabels.Invoice_Date_}']/parent::li"));
        private readonly ListTextLabel _dueDate = new(By.XPath($"//span[text()='{AppLabels.Due_Date_}']/parent::li"));
        private readonly TextLabel _bookingCode = new(By.XPath($"//td[text()='{AppLabels.Booking_Code}']/following-sibling::td"));
        private readonly TextLabel _room = new(By.XPath($"//td[text()='{AppLabels.Room}']/following-sibling::td"));
        private readonly TextLabel _totalStayCount = new(By.XPath($"//td[text()='{AppLabels.Total_Stay_Count}']/following-sibling::td"));
        private readonly TextLabel _totalStayAmount = new(By.XPath($"//td[text()='{AppLabels.Total_Stay_Amount}']/following-sibling::td"));
        private readonly TextLabel _checkIn = new(By.XPath($"//td[text()='{AppLabels.Check_In}']/following-sibling::td"));
        private readonly TextLabel _checkOut = new(By.XPath($"//td[text()='{AppLabels.Check_Out}']/following-sibling::td"));
        private readonly TextLabel _customerDetails = new(By.XPath("//div/br/parent::div"));
        private readonly HorizontalTable _billingDetails = new(By.XPath($"//h5[text()='{AppLabels.Billing_Details}']/following-sibling::table"));

        public override InvoiceDetailsPage AssureUserIsOnPage()
        {
            return (InvoiceDetailsPage)this.AssureUserIsOnPage("Invoice Details");
        }

        public InvoiceDetailsPage ValidateInvoiceData(InvoiceData data)
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(data.HotelName, _hotelName.GetText());
                Assert.AreEqual(data.InvoiceNumber, _invoiceNumber.GetText("(?<=Invoice\\s#)\\d{3,}(?=\\s" + "details)"));
                Assert.AreEqual(data.InvoiceDate, _invoiceDate.GetText());
                Assert.AreEqual(data.DueDate, _dueDate.GetText());                
                Assert.AreEqual(data.BookingCode, _bookingCode.GetText());
                Assert.AreEqual(data.Room, _room.GetText());
                Assert.AreEqual(data.TotalStayCount, _totalStayCount.GetText());
                Assert.AreEqual(data.TotalStayAmount, _totalStayAmount.GetText());
                Assert.AreEqual(data.CheckIn, _checkIn.GetText());
                Assert.AreEqual(data.CheckOut, _checkOut.GetText());
                Assert.AreEqual(data.CustomerDetails, _customerDetails.GetText());                                
                Assert.AreEqual(data.DepositNow, _billingDetails.GetTableDataValue(AppLabels.Deposit_Now));
                Assert.AreEqual(data.TaxAndVat, _billingDetails.GetTableDataValue(AppLabels.Tax_VAT));
                Assert.AreEqual(data.TotalAmount, _billingDetails.GetTableDataValue(AppLabels.Total_Amount));
            });
            return this;
        }
    }
}