using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_19_2023
{
    internal class FlipkartTests:CoreCode
    {
        [Test]
        [Order(0)]
        [Author("Gokul", "Gokul@gmail.com")]
        [Description("Search For a product")]
        [Category("Regression Testing")]
        public void SearchForProduct()
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element Not Found";

            fluentWait.Until(d => d.FindElement(By.ClassName("_30XB9F"))).Click();


            IWebElement SearchInput = fluentWait.Until(d => d.FindElement(By.XPath("//input[@title='Search for Products, Brands and More']")));
            SearchInput.SendKeys("Laptops");
            SearchInput.SendKeys(Keys.Enter);
            Thread.Sleep(2000);
        }
        [Test]
        [Order(10)]
        [Author("Gokul", "Gokul@gmail.com")]
        [Description("Add to cart")]
        [Category("Regression Testing")]

        public void AddToCart()
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element Not Found";
            IWebElement productLink = fluentWait.Until(d => d.FindElement(By.XPath("//div[@class='_4rR01T'][1]")));
            productLink.Click();
            Thread.Sleep(2000);

           
            List<string> lswindow=driver.WindowHandles.ToList();
            driver.SwitchTo().Window(lswindow[1]);
            IWebElement addTOCart = fluentWait.Until(d => d.FindElement(By.XPath("//button[@class='_2KpZ6l _2U9uOA _3v1-ww']")));
            addTOCart.Click();
            Thread.Sleep(2000);
            fluentWait.Until(d => d.FindElement(By.XPath("//div[@class='YUhWwv']"))).Click();
            Thread.Sleep(2000);
        }
    }
}
