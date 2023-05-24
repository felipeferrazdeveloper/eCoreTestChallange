﻿using CustomSelenium.ElementObjects.Element;
using CustomSelenium.ElementObjects.Elements;
using OpenQA.Selenium;

namespace eCoreTestChallange.PageObjects.Page
{
    public class LoginPage : PageObject
    {        
        TextField UsernameTextField;
        TextField PasswordTextField;
        Button LoginButton;

        public LoginPage()
        {            
            UsernameTextField = new TextField(By.Name("username"));
            PasswordTextField = new TextField(By.Name("password"));
            LoginButton = new Button(By.Id("btnLogin"));
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
    }
}