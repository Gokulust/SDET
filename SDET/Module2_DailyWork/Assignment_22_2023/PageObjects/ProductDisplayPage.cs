using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_22_2023.PageObjects
{
    internal class ProductDisplayPage
    {
        IWebDriver driver;
        ProductDisplayPage(IWebDriver driver) {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How =How.XPath,Using = "//a[text()='Black-2.50']")]
        IWebElement SizeElement { get; set; }

        [FindsBy(How=How.Id,Using = "cart-panel-button-0")]
        IWebElement CartButton {  get; set; }

        public void SelectSize()
        {
            SizeElement.Click();
        }
        public void ClickCartButton()
        {
            CartButton.Click();
        }
    }
}
