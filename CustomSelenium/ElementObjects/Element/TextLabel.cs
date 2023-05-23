using OpenQA.Selenium;

namespace CustomSelenium.ElementObjects.Element
{
    public class TextLabel : ElementObject
    {
        public TextLabel(By byLocator, int timeoutSeconds = 3) : base(byLocator, timeoutSeconds)
        {
        }

        public String GetText()
        {
            return GetVisibleElement().Text;
        }
    }
}
