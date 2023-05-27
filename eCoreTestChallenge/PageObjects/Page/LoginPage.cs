using AventStack.ExtentReports;
using CustomSelenium.ElementObjects.Element;
using eCoreTestChallenge.CustomSelenium;
using eCoreTestChallenge.Data;
using eCoreTestChallenge.Data.PageData;
using eCoreTestChallenge.Report;
using NUnit.Framework;
using OpenQA.Selenium;

namespace eCoreTestChallenge.PageObjects.Page
{
    public class LoginPage : PageObject
    {
        private TextField _usernameTextField = new(By.Name("username"));
        private TextField _passwordTextField = new(By.Name("password"));
        private Button _loginButton = new(By.Id("btnLogin"));
        private TextLabel _messageFeedbackLabel = new(By.CssSelector(".alert"));

        public override LoginPage AssureUserIsOnPage()
        {
            base.AssureUserIsOnPage("Login", By.CssSelector("h1"));
            return this;
        }       

        public LoginPage LoginWithCredentials(LoginData data)
        {

            _usernameTextField.ClearAndFillTextField(data.Username);
            Reporter.LogInputData("Username", data.Username);
            _passwordTextField.ClearAndFillTextField(data.Password);
            Reporter.LogInputData("Password", data.Password);
            _loginButton.Click();
            Reporter.LogUserAction("Clicked","Login button");
            return this;
        }

        public LoginPage ValidateAccessDeniedMessage()
        {
            try
            {
                var message = _messageFeedbackLabel.GetText();
                Assert.AreEqual(AppLabels.Wrong_username_or_password, message);
                Reporter.Log(Status.Pass, $"Message: '{AppLabels.Wrong_username_or_password}' was shown");
            }
            catch (Exception ex)
            {
                Reporter.Log(Status.Fail, $"Cannot achieve alert message");
                CustomSeleniumManager.TakeScreenShot(Reporter.ScreenShotFolder);
                throw ex;
            }
        
            return this;
        }
    }
}