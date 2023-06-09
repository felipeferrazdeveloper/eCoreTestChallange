﻿using OpenQA.Selenium;

namespace CustomSelenium.ElementObjects.Element
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
 
