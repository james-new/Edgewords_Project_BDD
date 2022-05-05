using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edgewords_Project_BDD.POMs
{
     class ShoppingPOM  

    {
        private IWebDriver driver;

        public ShoppingPOM(IWebDriver driver)
        {
            this.driver = driver;
        }


       public IWebElement add => driver.FindElement(By.CssSelector("[class='post-27 product type-product status-publish has-post-thumbnail product_cat-accessories first instock sale shipping-taxable purchasable product-type-simple'] [data-product_id]")); //add beanie to basket
        
       public IWebElement basket => driver.FindElement(By.CssSelector("a[title='View cart']")); //go to basket

        public IWebElement MyAccount => driver.FindElement(By.LinkText("My account"));
    }

}
