using NopCommerce_Selenium.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_IT_Depot_Selenium.PageObjects;

namespace NopCommerce_Selenium.PageObjects
{
    internal class ProductPage
    {
        IWebDriver driver;
        public ProductPage(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        private DefaultWait<IWebDriver> CreateWait()
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.PollingInterval = TimeSpan.FromMilliseconds(100);
            wait.Timeout = TimeSpan.FromSeconds(10);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            return wait;
        }
        [FindsBy(How=How.ClassName,Using = "ico-cart")]

        private IWebElement CartButton { get; set; }
    

        public void ClickOnAddToCartButton()
        {
            
            IWebElement addToCartButton=CreateWait().Until(d => d.FindElement(By.XPath("(//button[text()='Add to cart'])[1]")));
            CoreCodes.ScrollViewInto(driver,addToCartButton);
            addToCartButton.Click();
        }

        public CartPage GoToCart()
        {
            IWebElement goCartPage = CreateWait().Until(d => d.FindElement(By.XPath("//p[@class='content']/a")));
            CoreCodes.ScrollViewInto(driver, driver.FindElement(By.XPath("//div[@class='bar-notification-container']")));
            goCartPage.Click();
            return new CartPage(driver);
        }

    }
}
