using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_IT_Depot_Selenium.PageObjects
{
    internal class HomePage
    {
        IWebDriver driver;
        public HomePage(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How=How.Id,Using = "keywords")]
        private IWebElement SearchInputBox { get; set; }

        [FindsBy(How=How.XPath,Using = "//button[i[@class='fa fa-search']]")]

        private IWebElement SearchButton { get; set;}

        public void TypeSearchKeyWordInSearchInputBox(string searchKeyWord)
        {
            SearchInputBox.SendKeys(searchKeyWord);
        }
        public SearchResultProductsPage ClicksOnSearchButton()
        {
            SearchButton.Click();
            return new SearchResultProductsPage(driver);
        }
    }
}
