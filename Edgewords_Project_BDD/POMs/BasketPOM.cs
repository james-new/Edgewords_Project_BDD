using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EdgewordsProjectBDD.Supports;


namespace EdgewordsProjectBDD.POMs
{
    internal class BasketPOM
    {
        private IWebDriver driver;
        public BasketPOM(IWebDriver driver)
        {
            this.driver = driver;
        }
        public IWebElement Coupon => driver.FindElement(By.CssSelector("input#coupon_code"));
        public IWebElement Apply => driver.FindElement(By.CssSelector("button[name='apply_coupon']")); //add coupon

        public IWebElement DiscountPrice => driver.FindElement(By.CssSelector(".cart-discount.coupon-edgewords > td > .amount.woocommerce-Price-amount"));

        public IWebElement RemoveCoupon => driver.FindElement(By.CssSelector(".woocommerce-remove-coupon"));
        public IWebElement RemoveItem => driver.FindElement(By.CssSelector(".remove"));

        public IWebElement Checkout => driver.FindElement(By.LinkText("Proceed to checkout"));

        public IWebElement MyAccount => driver.FindElement(By.LinkText("My account"));

        public IWebElement StringPrice => driver.FindElement(By.CssSelector(".cart-subtotal > td > .amount.woocommerce-Price-amount"));

        public  string Price; //string of discount ammount

        public string PriceNoPound; //string of discount without the £ sign

        public static decimal DecPrice; //PriceNoPound as a decimal

        public  string ItemPrice; //string of item price

        public  string ItemPriceNoPound; //String of item price without £ sign

        public static decimal TotalPrice; //ItemPriceNoPound as decimal 

        public static decimal Discount; //Discount percentage


        public void BasketGetPrices()

        {
            ElementPresent(driver, By.CssSelector(".cart-discount.coupon-edgewords > td > .amount.woocommerce-Price-amount"));
            Price = DiscountPrice.Text;
            Console.WriteLine(Price);
            PriceNoPound = Price[1..];
            Decimal.TryParse(PriceNoPound, out DecPrice);

            //parses discount to a decimal

            ItemPrice = StringPrice.Text;
            ItemPriceNoPound = ItemPrice[1..];
            Decimal.TryParse(ItemPriceNoPound, out TotalPrice);

            //parses total price to a decimal 

            ElementPresent(driver, By.CssSelector(".woocommerce-remove-coupon"));
            RemoveCoupon.Click(); //removes coupon
            System.Threading.Thread.Sleep(1000);
            ElementPresent(driver, By.CssSelector(".remove"));
            RemoveItem.Click(); //removes item from basket
        }

            public void BasketCalcDiscount()
            
            {
            Discount = DecPrice / TotalPrice * 100;
            Console.WriteLine(BasketPOM.DecPrice);
            Console.WriteLine(BasketPOM.TotalPrice);
            Console.WriteLine(Discount);
        }
           
        


    }
}
