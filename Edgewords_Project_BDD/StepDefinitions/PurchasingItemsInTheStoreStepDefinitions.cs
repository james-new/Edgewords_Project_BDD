using System;
using TechTalk.SpecFlow;

using static Edgewords_Project_BDD.UserInfo;
using static Edgewords_Project_BDD.Support;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using Edgewords_Project_BDD.POMs;

namespace Edgewords_Project_BDD
{
    [Binding]

    
    public class StepDefinitions
    {
        IWebDriver driver = new ChromeDriver();
        //private readonly ScenarioContext _scenarioContext;

        //public StepDefinitions(ScenarioContext scenarioContext)
       // {
            //_scenarioContext = scenarioContext;
       // }
        [Given(@"I have an item in my basket")]
        public void GivenIHaveAnItemInMyBasket()
        {
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.edgewordstraining.co.uk/demo-site/my-account/";
            LoginPOM LoginPOM = new LoginPOM(driver);
            LoginPOM.dismiss.Click();
            LoginPOM.Username.SendKeys(UserInfo.Username);
            LoginPOM.passowrd.SendKeys(UserInfo.Password);
            LoginPOM.login.Click();
            LoginPOM.shop.Click();


            var element = driver.FindElement(By.CssSelector("[class='post-27 product type-product status-publish has-post-thumbnail product_cat-accessories first instock sale shipping-taxable purchasable product-type-simple'] [data-product_id]"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(element);
            actions.Perform();
            //scrolls down to beanie

            ShoppingPOM shoppingPOM = new ShoppingPOM(driver);
            shoppingPOM.add.Click();
            ElementPresent(driver, By.CssSelector("a[title='View cart']"));
            shoppingPOM.basket.Click();
            
        }

        [When(@"I apply the coupon '(.*)'")]
        public void WhenIApplyTheCoupon(string edgewords0)
        {
            BasketPOM basketPOM = new BasketPOM(driver);
            basketPOM.coupon.SendKeys("edgewords");
            basketPOM.apply.Click();
            
        }

        [Then(@"I get (.*)% off the item price")]
        public void ThenIGetOffTheItemPrice(int p0)
        {
            ElementPresent(driver, By.CssSelector(".cart-discount.coupon-edgewords > td > .amount.woocommerce-Price-amount"));
            BasketPOM basketPOM = new BasketPOM(driver);
            var price = basketPOM.DiscountPrice.Text;
            Console.WriteLine(price);
            ElementPresent(driver, By.CssSelector(".woocommerce-remove-coupon"));
            basketPOM.RemoveCoupon.Click();
            System.Threading.Thread.Sleep(1000);
            ElementPresent(driver, By.CssSelector(".remove"));
            basketPOM.RemoveItem.Click();
            ElementPresent(driver, By.CssSelector(".button.wc-backward"));
            basketPOM.Back.Click();
            ElementPresent(driver, By.LinkText("My account"));
            ShoppingPOM shoppingPOM = new ShoppingPOM(driver);
            shoppingPOM.MyAccount.Click();
            MyAccountPOM myAccountPOM = new MyAccountPOM(driver);
            myAccountPOM.Logout.Click();

            driver.Quit();

            if (price == "£2.70")
            {
                Assert.Pass("The discount was 15%");
            }
            else
                Assert.Fail("The discount was not 15%"); ;
        }
        [When(@"I order the item")]
        public void WhenIOrderTheItem()
        {

            BasketPOM basketPOM = new BasketPOM(driver);
            basketPOM.Checkout.Click();

            CheckoutPOM checkoutPOM = new CheckoutPOM(driver);
            checkoutPOM.FirstName.Clear();
            checkoutPOM.FirstName.SendKeys(UserInfo.Name);
            checkoutPOM.LastName.Clear();
            checkoutPOM.LastName.SendKeys(UserInfo.Surname);
            checkoutPOM.HouseNo.Clear();
            checkoutPOM.HouseNo.SendKeys(UserInfo.HouseNo);
            checkoutPOM.City.Clear();
            checkoutPOM.City.SendKeys(UserInfo.City);
            checkoutPOM.PostCode.Clear();
            checkoutPOM.PostCode.SendKeys(UserInfo.Postcode);
            checkoutPOM.Phone.Clear();
            checkoutPOM.Phone.SendKeys(UserInfo.Phone + Keys.Enter);
            
        }

        [Then(@"the order number will be the same in my account as it is at the checkout")]
        public void ThenTheOrderNumberWillBeTheSameInMyAccountAsItIsAtTheCheckout()

        {
            CheckoutPOM checkoutPOM = new CheckoutPOM(driver);
            ElementPresent(driver, By.CssSelector(".order > strong"));
            var OrderNo = "#" + checkoutPOM.OrderNo.Text;
            Console.WriteLine(OrderNo);
            checkoutPOM.MyAccount.Click();
            MyAccountPOM myAccountPOM = new MyAccountPOM(driver);
            myAccountPOM.Orders.Click();
            var OrderConfirm = myAccountPOM.OrderNumber.Text;
            Console.WriteLine(OrderNo);
            Console.WriteLine(OrderConfirm);
            driver.Quit();

            if (OrderNo == OrderConfirm)
            {
                Assert.Pass("The order numbers match");
            }
            else
                Assert.Fail("The order numbers do not match");
        }
    }

}
