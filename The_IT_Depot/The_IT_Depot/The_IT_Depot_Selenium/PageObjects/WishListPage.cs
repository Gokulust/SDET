using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_IT_Depot_Selenium.PageObjects
{
    internal class WishListPage
    {
        IWebDriver driver;
        public WishListPage(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        private DefaultWait<IWebDriver> CreateWait()
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.PollingInterval = TimeSpan.FromMilliseconds(100);
            wait.Timeout = TimeSpan.FromSeconds(20);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            return wait;
        }

        [FindsBy(How=How.XPath,Using = "(//a[text()='×'])[1]")]

        private IWebElement RemoveButton { get; set; }

        [FindsBy(How=How.XPath,Using = "//h1[text()='My Wish List']")]

        private IWebElement MyWishListElement { get; set; }

        

        public void ClickOnRemoveButton()
        {
            RemoveButton.Click();
        }
        public bool IsMyWishListTitlePresnent()
        {
            CreateWait().Until(d =>MyWishListElement.Displayed);
           return MyWishListElement.Displayed;
        }

        public bool IsWishListProductPresnent(string productName)
        {
            return driver.FindElement(By.XPath("//a[text()='" + productName+"']")).Displayed;
        }
        public bool IsWishListEmpty()
        {
            IWebElement IsEmpty = CreateWait().Until(d => d.FindElement(By.XPath("//p[text()='Your Wishlist is Empty']")));
            return IsEmpty.Displayed;
        }

    }
}
