using OpenQA.Selenium;

namespace CustomSelenium.ElementObjects.Element
{
    public class ListTextLabel : TextLabel
    {
        public ListTextLabel(By byLocator, int timeoutSeconds = 3) : base(byLocator, timeoutSeconds)
        {
        }

        public override String GetText()
        {
            String text = base.GetText();
            return text.Split(':')[1].Trim();
        }
    }
}
