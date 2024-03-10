using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;

namespace Assignment_20_2023
{
    internal class Naaptol:CoreCodes
    {
        [Test]
        [Order(0)]
        [Author("Gokul", "Gokul@gmail.com")]
        [Description("Search For a product")]
        [Category("Regression Testing")]
        public void SearchForProduct()
        {
            //DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            //fluentWait.Timeout = TimeSpan.FromSeconds(5);
            //fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            //fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            //fluentWait.Message = "Element Not Found";



            IWebElement SearchInput = driver.FindElement(By.Id("header_search_text"));
            SearchInput.SendKeys("eyewear");
            SearchInput.SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            Assert.That(driver.Url.Contains("eyewear"));
        }
        [Test]
        [Order(8)]
        [Author("Gokul", "Gokul@gmail.com")]
        [Description("Select a Product")]
        [Category("Regression Testing")]

        public void SelectAProduct()
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element Not Found";
            IWebElement productLink = fluentWait.Until(d => d.FindElement(By.XPath("//div[@id='productItem5' ]")));
            Actions actions = new Actions(driver);
            Action action = () => actions.MoveToElement(productLink).Build().Perform();
            action.Invoke();
            productLink.Click();
            List<string> lswindow = driver.WindowHandles.ToList();
            driver.SwitchTo().Window(lswindow[1]);
            Assert.That(driver.Url.Contains("reading-glasses-with-led-lights-lrg4"));
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
            


           
            IWebElement addTOCart = fluentWait.Until(d => d.FindElement(By.XPath("//a[text()='Black-2.50']")));
            addTOCart.Click();
            Thread.Sleep(2000);
            fluentWait.Until(d => d.FindElement(By.Id("cart-panel-button-0"))).Click();
            Thread.Sleep(2000);
          
        }

        [Test]
        [Order(20)]
        [Author("Gokul", "Gokul@gmail.com")]
        [Description("View Cart Product")]
        [Category("Regression Testing")]

        public void ViewCartProduct()
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element Not Found";
            IWebElement ProductCheck = fluentWait.Until(d => d.FindElement(By.PartialLinkText("Reading Glasses with LED Lights (LRG4)")));
            Assert.AreEqual(ProductCheck.Text, "Reading Glasses with LED Lights (LRG4)");
            driver.FindElement(By.XPath("//a[@title='Close']"));

        }
    }
}
