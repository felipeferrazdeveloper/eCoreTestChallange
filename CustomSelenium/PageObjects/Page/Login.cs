using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomSelenium.PageObjects.Page
{
    public class Login : PageObject
    {
        public IWebDriver Driver { get; set; }

        WebElement UsernameTextField;
        WebElement PasswordTextField;
        WebElement LoginButton;

        public Login()
        {
            
        }

    }
}
