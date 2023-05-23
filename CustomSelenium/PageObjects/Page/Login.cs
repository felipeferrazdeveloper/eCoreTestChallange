using CustomSelenium.Elements;
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

        TextField UsernameTextField;
        TextField PasswordTextField;
        WebElement LoginButton;

        public Login()
        {            
            UsernameTextField = new TextField(By.Name("username"));
            PasswordTextField = new TextField(By.Name("password"));            
        }

    }
}
