using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edgewords_Project_BDD.POMs
{
     class LoginPOM
    {
        private IWebDriver driver;
        public LoginPOM(IWebDriver driver)
        {
            this.driver = driver;
        }

        
       public IWebElement dismiss => driver.FindElement(By.CssSelector(".woocommerce-store-notice__dismiss-link")); //dismiss notifiaction at bottom
        public IWebElement Username => driver.FindElement(By.CssSelector("input#username")); //username
       
        public IWebElement passowrd => driver.FindElement(By.CssSelector("input#password")); //password
        public IWebElement login => driver.FindElement(By.CssSelector("button[name='login']")); //log in to the site
        public IWebElement shop => driver.FindElement(By.CssSelector(".menu-item.menu-item-43.menu-item-object-page.menu-item-type-post_type > a"));
    }
}

