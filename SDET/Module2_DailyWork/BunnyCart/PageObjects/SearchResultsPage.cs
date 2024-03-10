using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCart.PageObjects
{
    internal class SearchResultsPage
    {
        
        IWebDriver? driver;
        public SearchResultsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }
        /*
        [FindsBy(How = How.XPath, Using = "//*[@id='amasty-shopby-product-list']/div[2]" +
            "/ol/li[1]/div/div[2]/strong/a[1]")]
        private IWebElement? FirstProductLink { get;  }
        */
        [FindsBy(How =How.XPath,Using = "//a[@class='product-item-link'][2]")]
        private IWebElement FirstProductLink { get; set; }

        public string? GetFirstProductLink()
        {
            //IWebElement? FirstProductLink = driver.FindElement(By.XPath(
            //    "//*[@id='amasty-shopby-product-list']/div[2]" +
            //    "/ol/li[1]/div/div[2]/strong/a[1]"));
            return FirstProductLink?.Text;
        }
        public ProductPage ClickFirstProductLink(int count)
        {

            IWebElement? FirstProductLink = driver.FindElement(
           By.XPath("//*[@id='amasty-shopby-product-list']/div[2]/ol/li" +
           "[" + count + "]/div/div[2]/strong/a[1]"));

            FirstProductLink?.Click();
            return new ProductPage(driver);
        }
    }
}
