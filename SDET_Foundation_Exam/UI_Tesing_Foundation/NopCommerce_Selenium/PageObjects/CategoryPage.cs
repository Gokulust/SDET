using NopCommerce_Selenium.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NopCommerce_Selenium.PageObjects
{
    internal class CategoryPage
    {
        IWebDriver driver;
       
        public CategoryPage(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        private DefaultWait<IWebDriver> CreateWait()
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.PollingInterval = TimeSpan.FromMilliseconds(100);
            wait.Timeout = TimeSpan.FromSeconds(5);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            return wait;
        }

        
        public ProductListPage ClickCategoryLink(string category)
        {
            IWebElement categoryLink = driver.FindElement(By.LinkText(category));
            CoreCodes.ScrollViewInto(driver, categoryLink);
            categoryLink.Click();
            return new ProductListPage(driver);
        }
    }
}
