using NopCommerce_Selenium.Utilities;
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
    internal class CartPage
    {
        IWebDriver driver;
        public CartPage(IWebDriver driver)
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
        [FindsBy(How=How.Id,Using = "termsofservice")]
        private IWebElement TermsOfServiceCheckBox { get; set; }

        [FindsBy(How=How.Id,Using = "checkout")]
        private IWebElement CheckoutButton { get; set; }

        public void ClickOnTermsOfServiceCheckBox()
        {
            CreateWait().Until(d => TermsOfServiceCheckBox.Displayed);
            CoreCodes.ScrollViewInto(driver, TermsOfServiceCheckBox);
            TermsOfServiceCheckBox.Click();
        }
        public CheckoutPage ClickonCheckoutButton()
        {
            CheckoutButton.Click();
            return new CheckoutPage(driver);
        }
    }
}
