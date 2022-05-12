using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgewordsProjectBDD.POMs
{
    internal class MyAccountPOM
    {
        private IWebDriver driver;

        public MyAccountPOM(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement Logout => driver.FindElement(By.CssSelector(".woocommerce-MyAccount-content > p:nth-of-type(1) > a"));
        public IWebElement Orders => driver.FindElement(By.LinkText("Orders"));

       // public IWebElement OrderNumber => driver.FindElement(By.PartialLinkText("OrderNo"));

        public IWebElement OrderNumber => driver.FindElement(By.CssSelector("tr:nth-of-type(1) > .woocommerce-orders-table__cell.woocommerce-orders-table__cell-order-number > a"));

        public string OrderNumberHash;

        public string OrderNumberNoHash;


         
        public void GetOrderNumber()
        {
            Orders.Click();
            OrderNumberHash = OrderNumber.Text;
            OrderNumberNoHash = OrderNumberHash[1..];
            Console.WriteLine($"The hash removed number is {OrderNumberNoHash}");
        }
    }

}
