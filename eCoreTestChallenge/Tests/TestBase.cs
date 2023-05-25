using AventStack.ExtentReports.Model;
using CustomSelenium;
using eCoreTestChallenge.Report;
using NUnit.Framework;

namespace eCoreTestChallenge.Tests;

public class TestBase
{
    [SetUp]
    public void TestSetup()
    {
        CustomSeleniumManager.StartSession("https://automation-sandbox-python-mpywqjbdza-uc.a.run.app/", TestContext.CurrentContext.Test.FullName);
        Reporter.BeforeScenario(TestContext.CurrentContext.Test.FullName);
    }

    [TearDown]
    public void TestTearDown()
    {
        CustomSeleniumManager.FinishSession();
        Reporter.TearDown();
    }
}