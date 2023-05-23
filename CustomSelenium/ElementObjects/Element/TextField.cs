using OpenQA.Selenium;

namespace CustomSelenium.ElementObjects.Element
{
    public class TextField : ElementObject
    {
        public TextField(By byLocator, int timeoutSeconds = 3) : base(byLocator, timeoutSeconds)
        {
        }

        public void Clear() 
        { 
            this
                .GetVisibleElement()
                .Clear();
        }
     
        public void FillTextField(string value)
        {
            this
                .GetVisibleElement()
                .SendKeys(value);
        }

        public void ClearAndFillTextField(string value)
        {
            Clear();
            FillTextField(value);
        }
    }
}
