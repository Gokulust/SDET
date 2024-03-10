using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_IT_Depot_Selenium.PageObjects
{
    internal class CartPage
    {
        IWebDriver driver;
        public CartPage(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How=How.XPath,Using = "//button[text()=\"CHECKOUT \"]")]
        private IWebElement CheckoutButton { get; set; }


        public CheckoutPage ClickonCheckoutButton()
        {
            CheckoutButton.Click();
            return new CheckoutPage(driver);
        }
    }
}
