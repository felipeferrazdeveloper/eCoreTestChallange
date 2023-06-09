using System.Collections;
using System.Data;
using eCoreTestChallenge.Data.PageData;
using eCoreTestChallenge.PageObjects.Page;
using NUnit.Framework;
using DescriptionAttribute = NUnit.Framework.DescriptionAttribute;

namespace eCoreTestChallenge.Tests
{
    [TestFixture]
    public class Tests : TestBase
    {
        private static IEnumerable PositiveLoginTestCaseSource() => from DataRow row in LoginData.PositiveLoginTestData().Rows select new TestCaseData(row["Data"]);
        [Test]
        [Description("TC001 - Verify user authentication with provided credentials")]
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

        private static IEnumerable NegativeLoginTestCaseSource()
        {
            return from DataRow row in LoginData.NegativeLoginTestData().Rows select new TestCaseData(row["Data"]);
        }

        [Test]
        [Description("TC002 - Verify that the application prevents user login with invalid credentials.")]
        [TestCaseSource(nameof(NegativeLoginTestCaseSource))]
        public void NegativeLogin(LoginData data)
        {
            //Reporter.SetTestData(data);
            LoginPage loginPage = new();

            _ = loginPage
                .AssureUserIsOnPage()
                .LoginWithCredentials(data)
                .ValidateAccessDeniedMessage();
        }


        private static IEnumerable ValidateInvoiceDetailsTestCaseSource() => from DataRow row in InvoiceData.SampleInvoiceTestData().Rows select new TestCaseData(row["Data"]);
        [Test]
        [Description("TC003 - Verify that the invoice information is correctly displayed.")]
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