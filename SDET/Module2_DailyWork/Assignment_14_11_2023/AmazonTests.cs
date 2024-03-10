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
    internal class AmazonTests
    {
        IWebDriver? driver;
        public void InitializeChromeDriver()
        {
            driver = new ChromeDriver();
            driver.Url = "https://www.Amazon.com";
            driver.Manage().Window.Maximize();
        }

        public void TitleTest()
        {
            string title = driver.Title;
            
            Assert.AreEqual("Amazon.com. Spend less. Smile more.", title);
            Console.WriteLine("Title Test - Pass");
        }
        public void OrganisationTypeTest()
        {
            Assert.That(driver.Url.Contains(".com"));
            Console.WriteLine("Organisation type test - Pass");

        }
        public void Destruct()
        {
            driver.Close();

        }


    }
}
