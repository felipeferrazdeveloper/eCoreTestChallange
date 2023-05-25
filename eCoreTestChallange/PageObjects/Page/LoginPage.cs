using CustomSelenium.ElementObjects.Element;
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
        Assert.AreEqual("Wrong username or password.", _messageFeedbackLabel.GetText());
        return this;
    }
}