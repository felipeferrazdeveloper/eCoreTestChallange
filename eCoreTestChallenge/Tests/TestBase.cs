using eCoreTestChallenge.Report;
using NUnit.Framework;
using System.Reflection;
using eCoreTestChallenge.Data.PageData;
using RazorEngine.Compilation.ImpromptuInterface.Optimization;
using eCoreTestChallenge.CustomSelenium;

namespace eCoreTestChallenge.Tests;

public class TestBase
{
    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        Reporter.OneTimeSetup();
    }

    [SetUp]
    public void EachTestSetUp()
    {
        var methodName = TestContext.CurrentContext.Test.MethodName;
        var methodDescription = this
            .GetType()
            .GetMethod(methodName)
            .GetCustomAttribute<DescriptionAttribute>().Properties.Get("Description");
        
        var type = GetType().GetMethod(methodName).GetCustomAttribute<TestCaseSourceAttribute>();
        var data = type.MethodParams;
        var testData = "Test Execution {0}";

        if (data != null)
            testData = data.ToString();
        
        Reporter.TestSetup((string)methodDescription, testData);

        CustomSeleniumManager.StartSession("https://automation-sandbox-python-mpywqjbdza-uc.a.run.app/");
    }

    [TearDown]
    public void TestTearDown()
    {
        Reporter.TestTearDown(TestContext.CurrentContext.Result);
        CustomSeleniumManager.FinishSession();
    }

    [OneTimeTearDown]
    public void ClassTearDown()
    {
        Reporter.FlushReport();
    }
}