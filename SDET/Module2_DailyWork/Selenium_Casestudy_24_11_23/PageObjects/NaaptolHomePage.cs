using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_Casestudy_24_11_23.PageObjects
{
    internal class NaaptolHomePage
    {
        IWebDriver driver;
        public NaaptolHomePage(IWebDriver driver) {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        //Arrange
        [FindsBy(How=How.Id,Using = "header_search_text")]
        private IWebElement SearchTextBoxElement { get; set; }

        //Act
        public void TypeSearchKeyWord(string search)
        {
            SearchTextBoxElement.SendKeys(search);
        }

        public ViewProductsPage SearchForAProduct(string search)
        {
            TypeSearchKeyWord(search);
            Thread.Sleep(2000);
            SearchTextBoxElement.SendKeys(Keys.Enter);
            return new ViewProductsPage(driver);
        }
        public void ClearSearchInputElement()
        {
            SearchTextBoxElement.Clear();
        }
    }
}
