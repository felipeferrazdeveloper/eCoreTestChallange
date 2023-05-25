using CustomSelenium;
using NUnit.Framework;

namespace eCoreTestChallange.Tests
{

    public class TestBase
    {
        [SetUp]
        public void TestSetup()
        {
            CustomSeleniumManager.StartSession("https://automation-sandbox-python-mpywqjbdza-uc.a.run.app/");
        }

        [TearDown]
        public void TestTearDown()
        {
            CustomSeleniumManager.FinishSession();
        }
    }
}
