using OpenQA.Selenium;

namespace CustomSelenium.ElementObjects.Element;

public class HorizontalTable : ElementObject
{
    public HorizontalTable(By byLocator, int timeoutSeconds = 3) : base(byLocator, timeoutSeconds)
    {
    }

    public string GetTableDataValue(string columnName, int row=1)
    {           
        var index = -1;
        var headerItems = new List<IWebElement>(GetVisibleElement().FindElements(By.XPath("//thead//td")));
        foreach (var element in headerItems.Where(element => element.Text.Equals(columnName)))
        {
            index = headerItems.IndexOf(element);
            index++;
            break;
        }
        if (index == -1)
            throw new Exception("Column '"+columnName+"' not found!");

        var value = GetVisibleElement().FindElement(By.XPath("//thead/following-sibling::tbody/tr[" + row + "]/td[" + index + "]")).Text;

        return value;
    }
}