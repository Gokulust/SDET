using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_IT_Depot_Selenium.PageObjects
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

        [FindsBy(How=How.XPath,Using = "(//a[@class='AddToCart'])[2]/button")]
        private IWebElement AddToCartButton { get; set; }

        [FindsBy(How=How.XPath,Using = "(//a[@class='AddToWishList'])/button")]

        private IWebElement AddToWishList { get; set; }

        public bool IsTitlePresent(string productName)
        {
            IWebElement Title = CreateWait().Until(d=>d.FindElement(By.XPath("//h1[contains(text(), '" + productName + "')]")));
            return Title.Displayed;
        }

        public string GetFullProductName()
        {
            return driver.FindElement(By.XPath("//section[@id='Product']/div/div[2]/div[2]/div[1]/div[1]")).Text;
        }
        public CartPage ClickOnAddToCartButton()
        {
            AddToCartButton.Click();
            return new CartPage(driver);
        }
        public WishListPage ClickOnAddToWishList()
        {
            AddToWishList.Click();
            return new WishListPage(driver);
        }

    }
}
