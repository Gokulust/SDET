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
    internal class SearchResultProductsPage
    {
        IWebDriver driver;
       
        public SearchResultProductsPage(IWebDriver driver)
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

        [FindsBy(How=How.Id,Using = "subcategory_filter0")]
        private IWebElement SubCategoryCheckBox { get; set; }

        [FindsBy(How=How.Id,Using = "search_sort_dropdown")]
        private IWebElement SortBySelectionBox { get; set; }

        [FindsBy(How=How.XPath,Using = "//option[@value='price_desc']")]
        private IWebElement SortByOptionHighToLow { get; set; }


        

        public void ClickOnSubCategoryCheckBox()
        {
            
            SubCategoryCheckBox.Click();
        }
        public void ClickOnSortBySelectionBox()
        {
            SortBySelectionBox.Click();
        }
        public void ClickOnSortByOptionHighToLow()
        {
            SortByOptionHighToLow.Click();
        }
        public string ProductName(string productNumber)
        {
            Thread.Sleep(2000);// Adding a short delay to handle the content refresh as the element remains unchanged before and after sorting
            IWebElement productElement = driver.FindElement(By.XPath("(//div[@class='card-text px-2 py-1 font-size85 product_title'])[" + productNumber + "]"));
            return productElement.Text;
        }

        public bool IsTitlePresent(string searchedKeyWord)
        {
            IWebElement titleElemet = CreateWait().Until(d => d.FindElement(By.XPath("//h4[text()='Search Result for :" + searchedKeyWord + "']")));
            return titleElemet.Displayed;
                
        }

        public ProductPage ClickOnProduct(string productNumber)
        {

            Thread.Sleep(2000);// Adding a short delay to handle the content refresh as the element remains unchanged before and after sorting
            IWebElement productElement = driver.FindElement(By.XPath("(//div[@class='card-text px-2 py-1 font-size85 product_title'])["+productNumber+"]"));
            productElement.Click();
            return new ProductPage(driver);
        }
    }
}
