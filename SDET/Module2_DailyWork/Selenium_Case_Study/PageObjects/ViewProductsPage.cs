using OpenQA.Selenium;
using Selenium_Case_Study.Utilities;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_Case_Study.PageObjects
{
    internal class ViewProductsPage
    {
        IWebDriver driver;
        public ViewProductsPage(IWebDriver driver) {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        //div[@class='grid_Square '][5]/div[@class='item_title']/a

        public IWebElement TextInsideATag(string elementNumber)
        {
            IWebElement element = driver.FindElement(By.XPath("//div[@class='grid_Square '][" + elementNumber + "]/div[@class='item_title']/a"));
            return element;
        }
       

        public ProductPage ClickOnTheSelectedProduct(string elementNumber)
        {
            IWebElement selectedElement = driver.FindElement(By.XPath("//div[@class='grid_Square '][" + elementNumber + "]"));
            CoreCodes.ScrollViewInto(driver, selectedElement);
            selectedElement.Click();
            List<string> nextwindow = driver.WindowHandles.ToList();
            driver.SwitchTo().Window(nextwindow[1]);
            return new ProductPage(driver);
        }

    }
}
