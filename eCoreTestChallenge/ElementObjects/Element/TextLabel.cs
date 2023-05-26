using System.Text.RegularExpressions;
using OpenQA.Selenium;

namespace eCoreTestChallenge.ElementObjects.Element
{
    public class TextLabel : ElementObject
    {
        public TextLabel(By byLocator, int timeoutSeconds = 3) : base(byLocator, timeoutSeconds)
        {
        }

        public virtual string GetText()
        {
            return GetVisibleElement().Text.Trim();
        }

        public string GetText(string regex)
        {
            var match = Regex.Match(GetText(), regex);
            return match.Value;
        }
    }
}