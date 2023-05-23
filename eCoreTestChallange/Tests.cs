using eCoreTestChallange.PageObjects.Page;
using NUnit.Framework;
using DescriptionAttribute = NUnit.Framework.DescriptionAttribute;

namespace eCoreTestChallange
{
    [TestFixture]
    public class Tests : TestBase
    {
        [Test]
        [Description("TC001 User can authenticate in the application with provided credentials")]
        public void PositiveLogin()
        {
            LoginPage loginPage = new();
            InvoiceListPage invoiceListPage = new();
            
            _ = loginPage
                .LoginWithCredentials("demouser", "abc123");
           
            _ = invoiceListPage
                .AssertUserIsOnPage();                   
        }

        [Test]        
        public void NegativeLogin() 
        {
           
        }
        
        [Test]
        public void ValidateInvoiceDetails() 
        {
           
        }
    }
}