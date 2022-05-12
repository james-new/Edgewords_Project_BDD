using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EdgewordsProjectBDD.Supports;

namespace EdgewordsProjectBDD.POMs
{
    internal class CheckoutPOM
    {
        private IWebDriver driver;
        public CheckoutPOM(IWebDriver driver)
        {
            this.driver = driver;
        }
        public IWebElement FirstName => driver.FindElement(By.CssSelector("input#billing_first_name"));

        public IWebElement LastName => driver.FindElement(By.CssSelector("input#billing_last_name"));
       
        public IWebElement HouseNo => driver.FindElement(By.CssSelector("input[name='billing_address_1']"));

        public IWebElement City => driver.FindElement(By.CssSelector("input#billing_city"));
        public IWebElement PostCode => driver.FindElement(By.CssSelector("input#billing_postcode"));

        public IWebElement Phone => driver.FindElement(By.CssSelector("input#billing_phone"));

        public IWebElement OrderNo => driver.FindElement(By.CssSelector(".order > strong"));

        public IWebElement MyAccount => driver.FindElement(By.LinkText("My account"));

        public string OrderNumber;


        public void CheckoutEnterInfo()
        {
            ClearAndEnter(FirstName, UserInfo.Name);
            ClearAndEnter(LastName, UserInfo.Surname);
            ClearAndEnter(HouseNo, UserInfo.HouseNo);
            ClearAndEnter(City, UserInfo.City);
            ClearAndEnter(PostCode, UserInfo.Postcode);
            ClearAndEnter(Phone, UserInfo.Phone + Keys.Enter);

        }

        public void HoldOrderNumber()
        {
            ElementPresent(driver, By.CssSelector(".order > strong"));
            OrderNumber = OrderNo.Text;
            MyAccount.Click();
        }

        
    }
}
