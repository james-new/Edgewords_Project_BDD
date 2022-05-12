using System;
using TechTalk.SpecFlow;
using static EdgewordsProjectBDD.Supports;
using static EdgewordsProjectBDD.Support.Hooks1;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using EdgewordsProjectBDD.POMs;

namespace EdgewordsProjectBDD
{
    [Binding]

    
    public class StepDefinitions

    {
        [Given(@"a user has logged on to the website")]
        public void GivenAUserHasLoggedOnToTheWebsite()
        {
            LoginPOM Login = new LoginPOM(driver);
            Login.LoginSteps(Environment.GetEnvironmentVariable("Username")); 
            Login.EnterPassword(Environment.GetEnvironmentVariable("Password"));
            //Inputs environment elements
        }

        [Given(@"I have an item in my basket")]
        public void GivenIHaveAnItemInMyBasket()
        {
       
            LoginPOM Login = new LoginPOM(driver);
            Login.Shop.Click(); //Click shop from login page

            ShoppingPOM Shopping = new ShoppingPOM(driver);
            Shopping.AddToBasket();//adds item to basket
            
            
        }

        [When(@"I apply the coupon '(.*)'")]
        public void WhenIApplyTheCoupon(string Coupon)
           
        {
            BasketPOM basketPOM = new BasketPOM(driver);
            basketPOM.Coupon.SendKeys(Coupon);
            basketPOM.Apply.Click(); //applies coupon
        }

        [Then(@"I get (.*)% off the item price")]
        public void ThenIGetOffTheItemPrice(int SetDiscount)
        {
            
            BasketPOM basketPOM = new BasketPOM(driver);
            basketPOM.BasketGetPrices(); //gets the total price and discount ammount
            basketPOM.BasketCalcDiscount(); //calculates the discount percentage

            Assert.That(BasketPOM.Discount == SetDiscount, $"The discount was {BasketPOM.Discount}, not {SetDiscount}");
        }
        [When(@"I order the item")]
        public void WhenIOrderTheItem()
        {

            BasketPOM Basket = new BasketPOM(driver);
            Basket.Checkout.Click(); 

            CheckoutPOM Checkout = new CheckoutPOM(driver);
            Checkout.CheckoutEnterInfo();     
           
        }

        [Then(@"the order number will be the same in my account as it is at the checkout")]
        public void ThenTheOrderNumberWillBeTheSameInMyAccountAsItIsAtTheCheckout()

        {
            CheckoutPOM Checkout = new CheckoutPOM(driver);
            Checkout.HoldOrderNumber(); //gets the order number from the checkout
          

            MyAccountPOM MyAccount = new MyAccountPOM(driver);
            MyAccount.GetOrderNumber(); //gets the order number from the account page
            Console.WriteLine(Checkout.OrderNumber);
            Console.WriteLine(MyAccount.OrderNumberNoHash);

            Assert.That(Checkout.OrderNumber == MyAccount.OrderNumberNoHash, "The order numbers do not match");
         
        }
    }

}
