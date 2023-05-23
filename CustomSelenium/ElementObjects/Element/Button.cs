using CustomSelenium.ElementObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomSelenium.ElementObjects.Elements
{
    public class Button : ElementObject
    {
        public Button(By byLocator, int timeoutSeconds = 3) : base(byLocator, timeoutSeconds)
        {
        }

        public void Click()
        {
            this
                .GetVisibleElement()
                .Click();
        }
    }
}
