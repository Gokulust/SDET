using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_14_11_2023
{
    internal class Tests
    {
        IWebDriver driver;

        public void InitializeChromeDriver()
        {
            driver=new ChromeDriver();
            driver.Url = "https://www.google.com";
            driver.Manage().Window.Maximize();
        }
        public void GoToYahoo()
        {
            //IWebElement googleSearchBox = driver.FindElement(By.Id("APjFqb"));
            //googleSearchBox.SendKeys("yahoo.com");
            //Thread.Sleep(2000);
            //IWebElement gsButton = driver.FindElement(By.Name("btnK"));
            //gsButton.Click();
            driver.Navigate().GoToUrl("https://www.yahoo.com");
            Thread.Sleep(3000);
            Console.WriteLine("name:{0}", driver.Title);
            Assert.AreEqual("Yahoo | Mail, Weather, Search, Politics, News, Finance, Sports & Videos", driver.Title);
            Console.WriteLine("Go To Yahoo -Pass");
        }
        public void BackToGoogle()
        {
            Thread.Sleep(1000);
            driver.Navigate().Back();
            Thread.Sleep(2000);
            Assert.AreEqual("Google", driver.Title);
            Console.WriteLine("Back To Google -Pass");

        }
        public void SearchResultForDiwali()
        {
            IWebElement googleSearchBox = driver.FindElement(By.Id("APjFqb"));
            googleSearchBox.SendKeys("what's new for Diwali 2023?");
            Thread.Sleep(2000);
            IWebElement gsButton = driver.FindElement(By.Name("btnK"));
            gsButton.Click();
            Assert.AreEqual("what's new for Diwali 2023?", driver.Title);
            Console.WriteLine("Search Result For Diwali -Pass");
        }
        public void Refresh()
        {
            driver.Navigate ().Refresh();
        }
        public void Destruct()
        {
            driver.Close();
        }
    }
}
