using CustomSelenium;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCoreTestChallange
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
