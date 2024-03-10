using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_22_2023.PageObjects
{
    internal class ViewProductsPage
    {
        IWebDriver driver;
        public ViewProductsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How=How.XPath,Using = "//div[@id='productItem5']")]
        IWebElement ProductLink { get; set; }

        public void ClickOnTheProduct()
        {
           
            Thread.Sleep(3000);
            ProductLink.Click();
        }

       
    }
}
