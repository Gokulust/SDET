using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_Case_Study.PageObjects
{
    internal class ProductPage
    {
        IWebDriver driver;
        public ProductPage(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How=How.XPath,Using = "//*[@id='square_Details']/h1")]
        public IWebElement ProductTextNameElement { get; set; }

        //Arrange
        [FindsBy(How = How.XPath, Using = "//a[text()='Brown-2.50']")]
        public IWebElement? SelectedSize { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@id='cart-panel-button-0']")]
        public IWebElement? BuyButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@class='input_Special_2']")]
        public IWebElement? Qty { get; set; }

        [FindsBy(How=How.XPath,Using = "//div[@class='cart_info']/h2/a")]

        public IWebElement ProductCartNameElement { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"cartData\"]/li[1]/div[2]/p[2]/a")]
        public IWebElement? Remove { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@title='Close']")]
        public IWebElement? CloseButton { get; set; }

        //Act
        public void Sizeselect()
        {
            SelectedSize?.Click();
        }
        public void BuyNowButtonClicked()
        {
            BuyButton?.Click();
        }
        public void CloseButtonClicked()
        {
            CloseButton?.Click();
        }

    }
}
