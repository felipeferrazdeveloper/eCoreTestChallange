using OpenQA.Selenium;

namespace CustomSelenium.ElementObjects.Element;

public class TextField : ElementObject
{
    public TextField(By byLocator, int timeoutSeconds = 3) : base(byLocator, timeoutSeconds)
    {
    }

    public TextField Clear() 
    { 
        this
            .GetVisibleElement()
            .Clear();
        return this;
    }
     
    public TextField FillTextField(string value)
    {
        if (value == null)
            throw new NullReferenceException("Check data! value to Fill TextField is NULL");
           
        this
            .GetVisibleElement()
            .SendKeys(value);

        return this;           
    }

    public TextField ClearAndFillTextField(string value)
    {
        if (value == null)
            throw new NullReferenceException("Check data! value to Fill TextField is NULL");

        return this
            .Clear()
            .FillTextField(value);
    }
}