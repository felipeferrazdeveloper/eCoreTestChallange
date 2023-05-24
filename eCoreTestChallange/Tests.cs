using eCoreTestChallange.PageObjects.Page;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System.Collections;
using System.Data;
using DescriptionAttribute = NUnit.Framework.DescriptionAttribute;

namespace eCoreTestChallange
{
    [TestFixture]
    public class Tests : TestBase
    {
        [Test]
        [Description("TC001 User can authenticate in the application with valid credentials")]
        [TestCaseSource(nameof(PositiveLoginDataSet))]
        public void PositiveLogin(String username, String password)
        {                       
            LoginPage loginPage = new();
            InvoiceListPage invoiceListPage = new();
            
            _ = loginPage
                .LoginWithCredentials(username, password);
           
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