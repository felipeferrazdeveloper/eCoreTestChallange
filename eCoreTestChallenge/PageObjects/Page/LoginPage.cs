using CustomSelenium.ElementObjects.Element;
using eCoreTestChallenge.Data;
using eCoreTestChallenge.Data.PageData;
using NUnit.Framework;
using OpenQA.Selenium;

namespace eCoreTestChallenge.PageObjects.Page;

public class LoginPage : PageObject
{
    private readonly TextField _usernameTextField = new(By.Name("username"));
    private readonly TextField _passwordTextField = new(By.Name("password"));
    private readonly Button _loginButton = new(By.Id("btnLogin"));
    private readonly TextLabel _messageFeedbackLabel = new(By.CssSelector(".alert"));

    public override LoginPage AssureUserIsOnPage()
    {            
        return (LoginPage)this.AssureUserIsOnPage("Login", By.CssSelector("h1"));
    }       

    public LoginPage LoginWithCredentials(LoginData data)
    {
        _usernameTextField.ClearAndFillTextField(data.Username);
        _passwordTextField.ClearAndFillTextField(data.Password);
        _loginButton.Click();
        return this;
    }

    public LoginPage ValidateAccessDeniedMessage()
    {
        try
        {
            var message = _messageFeedbackLabel.GetText();
            Assert.AreEqual(AppLabels.Wrong_username_or_password, message);
        }
        catch (NoSuchElementException ex)
        {
            throw new NoSuchElementException("Alert message not found!", ex);
        }
        
        return this;
    }
}