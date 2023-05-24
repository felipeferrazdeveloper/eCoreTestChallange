using eCoreTestChallange.PageObjects.Page;
using NUnit.Framework;
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
                .AssureUserIsOnPage()
                .LoginWithCredentials(username, password);
           
            _ = invoiceListPage
                .AssureUserIsOnPage();                   
        }

        [Test]
        [Description("TC002 application denies the user with invalid credentials")]
        [TestCaseSource(nameof(NegativeLoginDataSet))]
        public void NegativeLogin(String username, String password)
        {
            LoginPage loginPage = new();
            InvoiceListPage invoiceListPage = new();

            _ = loginPage
                .LoginWithCredentials(username, password)
                .ValidateAccessDeniedMessage();
        }

        [Test]
        public void ValidateInvoiceDetails()
        {

        }



        static IEnumerable PositiveLoginDataSet()
        {
            foreach (DataRow row in TestData.PositiveLogin().Rows)
            {
                yield return new TestCaseData(row["username"], row["password"]);
            }
        }

        static IEnumerable NegativeLoginDataSet()
        {
            foreach (DataRow row in TestData.NegativeLogin().Rows)
            {
                yield return new TestCaseData(row["username"], row["password"]);
            }
        }
    }
}