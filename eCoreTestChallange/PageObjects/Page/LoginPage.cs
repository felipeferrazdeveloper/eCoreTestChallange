using CustomSelenium.ElementObjects.Element;
using eCoreTestChallenge.Data.PageData;
using NUnit.Framework;
using OpenQA.Selenium;

namespace eCoreTestChallenge.PageObjects.Page;

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

        public LoginPage LoginWithCredentials(LoginData data)
        {
            UsernameTextField.ClearAndFillTextField(data.Username);
            PasswordTextField.ClearAndFillTextField(data.Password);
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
