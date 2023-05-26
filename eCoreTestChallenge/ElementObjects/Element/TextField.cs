using AventStack.ExtentReports;
using eCoreTestChallenge.Report;
using OpenQA.Selenium;

namespace eCoreTestChallenge.ElementObjects.Element
{
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
            {
                Reporter.Log(Status.Error, "<span style='color: red'>Check test data!</span> - Value is <b>NULL<b> to fill Text Field");
                throw new NullReferenceException("Check data! value to Fill TextField is NULL");
            }
                
           
            this
                .GetVisibleElement()
                .SendKeys(value);

            return this;           
        }

        public TextField ClearAndFillTextField(string value)
        {
            return this
                .Clear()
                .FillTextField(value);
        }
    }
}