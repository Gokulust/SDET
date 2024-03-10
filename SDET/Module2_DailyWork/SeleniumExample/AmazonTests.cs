using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumExample
{
    internal class AmazonTests
    {
        IWebDriver? driver;
        public void InitializeChromeDriver()
        {
            driver = new ChromeDriver();
            driver.Url = "https://www.amazon.com";
            driver.Manage().Window.Maximize();



        }
        public void InitializeEdgeDriver()
        {
            driver = new EdgeDriver();
            driver.Url = "https://www.amazon.com";
            driver.Manage().Window.Maximize();
        }
        public void TitleTest()
        {
            Thread.Sleep(1000);
            string title = driver.Title;

            Assert.AreEqual("Amazon.com. Spend less. Smile more.", title);
            Console.WriteLine("title Length:", title);
            Console.WriteLine("Title test-pass");

        }
        public void LogoClickedTest()
        {
            driver.FindElement(By.Id("nav-logo-sprites")).Click();
            Assert.AreEqual("Amazon.com. Spend less. Smile more.", driver.Title);
            Console.WriteLine("Logo Click Test-pass");

        }
        public void SearchProductTest()
        {
            driver.FindElement(By.Id("twotabsearchtextbox")).SendKeys("mobiles");
            Thread.Sleep(2000);
            driver.FindElement(By.Id("nav-search-submit-button")).Click();
            Thread.Sleep(2000);
            Assert.That(("Amazon.com : mobiles").Equals(driver.Title) && (driver.Url).Contains("mobiles"));
            Console.WriteLine("Search Product Test -Pass");

        }
        public void ReloadHomePage()
        {
            driver.Navigate().GoToUrl(driver.Url);
            Thread.Sleep(2000);
        }
        public void TodaysDealsTest()
        {
            IWebElement todaysdeals = driver.FindElement(By.LinkText("Today's Deals"));
            if(todaysdeals == null)
            {
                throw new NoSuchElementException("Today's Deals Link not present");
            }
            todaysdeals.Click();
            Assert.That(driver.FindElement(By.TagName("h1")).Text.Equals("Today's Deals"));
            Console.WriteLine("TodaysDeals test -pass");
        }
        public void SignInAccListTest()
        {
            IWebElement helloSignin = driver.FindElement(By.Id("nav-link-accountList-nav-line-1"));
                if(helloSignin==null)
            {
                throw new NoSuchElementException("Hello, Signin is not present");
            }
            IWebElement accountandlists = driver.FindElement(By.XPath("//*[@id=\"nav-link-accountList\"]/span"));
            if(accountandlists==null)
            {
                throw new NoSuchElementException("Hello, Account & Lists is not present");
            }
              Assert.That(helloSignin.Text.Equals("Hello, sign in"));
              Console.WriteLine("Hello, Sign is present -pass");
            Assert.That(accountandlists.Text.Equals("Account & Lists"));
            Console.WriteLine("Account & List is present -Pass");
        }
        public void SearchAndFilterProductByBrandTest()
        {
            driver.FindElement(By.Id("twotabsearchtextbox")).SendKeys("mobile phones");
            Thread.Sleep(3000);
            driver.FindElement(By.Id("nav-search-submit-button")).Click();
            IWebElement motocheckbox=driver.FindElement(By.XPath("//*[@id=\"p_89/Motorola\"]/span/a/div/label/i"));
            motocheckbox.Click();
            Thread.Sleep(2000);
            Assert.True(driver.FindElement(By.XPath("//*[@id=\"p_89/Motorola\"]/span/a/div/label/input")).Selected);
            Console.WriteLine("Motorolais selected");
            driver.FindElement(By.ClassName("a-expander-prompt")).Click();
            IWebElement BLUcheckbox = driver.FindElement(By.XPath("//*[@id=\"p_89/BLU\"]/span/a/div/label/i"));
            BLUcheckbox.Click();
            Assert.True(driver.FindElement(By.XPath("//*[@id=\"p_89/BLU\"]/span/a/div/label/input")).Selected);
            Console.WriteLine("BLU is selected");
        }
        public void Destruct()
        {
            driver.Close();

        }
    }
}
