using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EdgewordsProjectBDD.Supports;

namespace EdgewordsProjectBDD.POMs
{
     class ShoppingPOM  

    {
        private IWebDriver driver;

        public ShoppingPOM(IWebDriver driver)
        {
            this.driver = driver;
        }

       public IWebElement Add => driver.FindElement(By.CssSelector("[data-product_id='27']")); //add beanie to basket
        
       public IWebElement Basket => driver.FindElement(By.CssSelector("a[title='View cart']")); //go to basket

        public IWebElement MyAccount => driver.FindElement(By.LinkText("My account"));

        public void AddToBasket()
        {
            Add.Click();
            ElementPresent(driver, By.CssSelector("a[title='View cart']"));
            Basket.Click();

        }
    }

}
