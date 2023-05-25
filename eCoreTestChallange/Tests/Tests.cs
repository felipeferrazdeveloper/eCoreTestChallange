using eCoreTestChallange.Data.PageData;
using eCoreTestChallange.PageObjects.Page;
using NUnit.Framework;
using System.Collections;
using System.Data;
using DescriptionAttribute = NUnit.Framework.DescriptionAttribute;

namespace eCoreTestChallange.Tests
{
    [TestFixture]
    public class Tests : TestBase
    {
        static IEnumerable PositiveLoginTestCaseSource()
        {
            foreach (DataRow row in LoginData.PositiveLoginTestData().Rows)
            {
                yield return new TestCaseData(row["Data"]);
            }
        }
        [Test]
        [Description("TC001 User can authenticate in the application with valid credentials")]
        [TestCaseSource(nameof(PositiveLoginTestCaseSource))]
        public void PositiveLogin(LoginData data)
        {
            LoginPage loginPage = new();
            InvoiceListPage invoiceListPage = new();

            _ = loginPage
                .AssureUserIsOnPage()
                .LoginWithCredentials(data);

            _ = invoiceListPage
                .AssureUserIsOnPage();
        }

        static IEnumerable NegativeLoginTestCaseSource()
        {
            foreach (DataRow row in LoginData.NegativeLoginTestData().Rows)
            {
                yield return new TestCaseData(row["Data"]);
            }
        }
        [Test]
        [Description("TC002 application denies the user with invalid credentials")]
        [TestCaseSource(nameof(NegativeLoginTestCaseSource))]
        public void NegativeLogin(LoginData data)
        {
            LoginPage loginPage = new();
            InvoiceListPage invoiceListPage = new();

            _ = loginPage
                .AssureUserIsOnPage()
                .LoginWithCredentials(data)
                .ValidateAccessDeniedMessage();
        }


        static IEnumerable ValidateInvoiceDetailsTestCaseSource()
        {
            foreach (DataRow row in InvoiceData.SampleInvoiceTestData().Rows)
            {
                yield return new TestCaseData(row["Data"]);
            }
        }
        [Test]
        [Description("TC003 Check listed invoice info presented")]
        [TestCaseSource(nameof(ValidateInvoiceDetailsTestCaseSource))]
        public void ValidateInvoiceDetails(InvoiceData data)
        {
            LoginPage loginPage = new();
            InvoiceListPage invoiceListPage = new();
            InvoiceDetailsPage invoiceDetailsPage = new(); 
            _ = loginPage
                .AssureUserIsOnPage()
                .LoginWithCredentials(data);
            _ = invoiceListPage
                .AssureUserIsOnPage()
                .AccessFirstInvoiceDetails();
            _ = invoiceDetailsPage
                .AssureUserIsOnPage()
                .ValidateInvoiceData(data);
        }        
    }
}