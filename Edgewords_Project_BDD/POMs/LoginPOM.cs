using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgewordsProjectBDD.POMs
{
    class LoginPOM
    {
        private IWebDriver driver;
        public LoginPOM(IWebDriver driver)
        {
            this.driver = driver;
        }


        public IWebElement Dismiss => driver.FindElement(By.CssSelector(".woocommerce-store-notice__dismiss-link")); //dismiss notifiaction at bottom
        public IWebElement Loginname => driver.FindElement(By.CssSelector("input#username")); //username

        public IWebElement NewPassword => driver.FindElement(By.CssSelector("input#password")); //password
        public IWebElement Login => driver.FindElement(By.CssSelector("button[name='login']")); //log in to the site
        public IWebElement Shop => driver.FindElement(By.CssSelector(".menu-item.menu-item-43.menu-item-object-page.menu-item-type-post_type > a"));

        public void LoginSteps(string Username)
        {
            Dismiss.Click(); //dismiss blue banner
            Loginname.SendKeys(Username);
        }

        public void EnterPassword(string Password)
        {
            NewPassword.SendKeys(Password);
            Login.Click();
        }
            
        
           
    }
}

