using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomSelenium.ElementObjects.Element
{
    public class HorizontalTable : ElementObject
    {
        public HorizontalTable(By byLocator, int timeoutSeconds = 3) : base(byLocator, timeoutSeconds)
        {
        }

        public String GetTableDataValue(String columnName, int row=1)
        {           
            int index = -1;
            List<IWebElement> headerItems = new List<IWebElement>(GetVisibleElement().FindElements(By.XPath("//thead//td")));
            foreach (IWebElement element in headerItems)
            {
                if (element.Text.Equals(columnName))
                {
                    index = headerItems.IndexOf(element);
                    index++;
                    break;
                }                    
            }
            if (index == -1)
                throw new Exception("Column '"+columnName+"' not found!");

            string value = GetVisibleElement().FindElement(By.XPath("//thead/following-sibling::tbody/tr[" + row + "]/td[" + index + "]")).Text;

            return value;
        }
    }
}
