using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edgewords_Project_BDD.POMs
{
    internal class BasketPOM
    {
        private IWebDriver driver;
        public BasketPOM(IWebDriver driver)
        {
            this.driver = driver;
        }
        public IWebElement coupon => driver.FindElement(By.CssSelector("input#coupon_code"));
        public IWebElement apply => driver.FindElement(By.CssSelector("button[name='apply_coupon']")); //add coupon

        public IWebElement DiscountPrice => driver.FindElement(By.CssSelector(".cart-discount.coupon-edgewords > td > .amount.woocommerce-Price-amount"));

        public IWebElement RemoveCoupon => driver.FindElement(By.CssSelector(".woocommerce-remove-coupon"));
        public IWebElement RemoveItem => driver.FindElement(By.CssSelector(".remove"));
        public IWebElement Back =>  driver.FindElement(By.CssSelector(".button.wc-backward")); 

        public IWebElement Checkout => driver.FindElement(By.LinkText("Proceed to checkout"));


    }
}
