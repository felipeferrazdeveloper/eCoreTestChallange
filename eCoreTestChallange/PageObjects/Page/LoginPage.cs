using CustomSelenium.ElementObjects.Element;
using CustomSelenium.ElementObjects.Elements;
using NUnit.Framework;
using OpenQA.Selenium;

namespace eCoreTestChallange.PageObjects.Page
{
    public class LoginPage : PageObject
    {        
        TextField UsernameTextField;
        TextField PasswordTextField;
        Button LoginButton;
        TextLabel MessageFeedbackLabel;

        public LoginPage()
        {            
            UsernameTextField = new TextField(By.Name("username"));
            PasswordTextField = new TextField(By.Name("password"));
            LoginButton = new Button(By.Id("btnLogin"));
            MessageFeedbackLabel = new TextLabel(By.CssSelector(".alert"));
        }

        public override LoginPage AssureUserIsOnPage()
        {            
            return (LoginPage)this.AssureUserIsOnPage("Login", By.CssSelector("h1"));
        }       

        public LoginPage LoginWithCredentials(String username, String password)
        {
            UsernameTextField.ClearAndFillTextField(username);
            PasswordTextField.ClearAndFillTextField(password);
            LoginButton.Click();
            return this;
        }

        public LoginPage ValidateAccessDeniedMessage()
        {
            Assert.AreEqual("Wrong username or password.", MessageFeedbackLabel.GetText());
            return this;
        }
    }
}
