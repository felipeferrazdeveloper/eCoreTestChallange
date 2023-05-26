using eCoreTestChallenge.Report;
using NUnit.Framework;
using System.Reflection;

namespace eCoreTestChallenge.Tests
{
    public class TestBase
    {
        [OneTimeSetUp]
        public void ClassSetup()
        {
            Reporter.SetUpReport();
        }

        [SetUp]
        public void TestSetup()
        {
            var methodName = TestContext.CurrentContext.Test.MethodName;
            var methodDescription = this
                .GetType()
                .GetMethod(methodName)
                .GetCustomAttribute<DescriptionAttribute>().Properties.Get("Description");

            Reporter.SetTestName((string)methodDescription);

            CustomSeleniumManager.StartSession("https://automation-sandbox-python-mpywqjbdza-uc.a.run.app/");
        }

        [TearDown]
        public void TestTearDown()
        {
            Reporter.AfterTest(TestContext.CurrentContext.Result);
            CustomSeleniumManager.FinishSession();
        }

        [OneTimeTearDown]
        public void ClassTearDown()
        {
            Reporter.TearDown();
        }
    }
}