using NopCommerce_Selenium.Utilities;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_IT_Depot_Selenium.PageObjects;

namespace NopCommerce_Selenium.PageObjects
{
    internal class ProductListPage
    {
        IWebDriver driver;

        public ProductListPage(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }

        public ProductPage ClickOnProductBasedOnProductPosition(string productNumber)
        {
            IWebElement productElement = driver.FindElement(By.XPath("//div[@class='item-grid']/div[" + productNumber + "]"));
            CoreCodes.ScrollViewInto(driver,productElement);
            productElement.Click();
            return new ProductPage(driver);
        }
        public string GetProductNameByProductPosition(string productNumber)
        {
           
            IWebElement productElement = driver.FindElement(By.XPath(" //div[@class='item-grid']/div["+productNumber+"]/div/div[2]/h2"));
            CoreCodes.ScrollViewInto(driver, productElement);
            return productElement.Text.ToLower();
        }

    }
}
