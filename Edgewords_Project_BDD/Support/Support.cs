using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgewordsProjectBDD
{
    public static class Supports
    {
        public static void ElementPresent(IWebDriver driver, By element)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(drv => drv.FindElement(element).Displayed);
            //10 second wait
        }

        public static void ClearAndEnter(IWebElement driver, string info)
        {

            driver.Clear();
            driver.SendKeys(info);
            //clears a text box then enters new data

        }


    }
}
    