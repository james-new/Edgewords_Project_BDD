using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;


 namespace Edgewords_Project_BDD.Support

 {
    [Binding]
    public class Hooks1
    {
        public static IWebDriver? driver;

        [BeforeScenario]
       
            public void SetUp()
            {
                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
            driver.Url = Environment.GetEnvironmentVariable("URL"); 
            }

      [AfterScenario]
        public void TearDown()
        {
            driver.FindElement(By.LinkText("My account")).Click();
            driver.FindElement(By.LinkText("Log out")).Click();
            driver.Quit();
        }
    }
}
   