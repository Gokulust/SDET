using BunnyCart.Hooks;
using BunnyCart.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Serilog;
using System;
using TechTalk.SpecFlow;

namespace The_IT_Depot_BDD.StepDefinitions
{
    [Binding]
    public class SearchToCheckoutStepDefinitions:CoreCodes
    {
        IWebDriver driver = AllHooks.driver;
        [Given(@"User will be on Homepage")]
        public void GivenUserWillBeOnHomepage()
        {
            driver.Url = "https://www.theitdepot.com/";
            driver.Manage().Window.Maximize();
        }

        [When(@"User search for ""([^""]*)"" on the home page")]
        public void WhenUserSearchForOnTheHomePage(string searchText)
        {
            IWebElement? searchInput = driver.FindElement(By.Id("keywords"));
            searchInput?.SendKeys(searchText);
            Log.Information("Typed search text " + searchText);
            
        }

        [When(@"User click on the search button")]
        public void WhenUserClickOnTheSearchButton()
        {
            IWebElement searchButton = driver.FindElement(By.XPath("//button[i[@class='fa fa-search']]"));
            searchButton?.Click();
            Log.Information("User clicked on the search button");
        }

        [Then(@"User wait for the search results page to load with title ""([^""]*)""")]
        public void ThenUserWaitForTheSearchResultsPageToLoad(string searchText)
        {
            TakeScreenShot(driver);
            Log.Information("Screenshot taken");
            try
            {
                Assert.That(driver.FindElement(By.XPath("//h4[text()='Search Result for : " + searchText + "']")).Displayed);
                LogTestResult("Search result loading Test", "Search result loading  Success");
            }
            catch (AssertionException ex)
            {
                LogTestResult("Search result loading ", "Search result loading  Failed", ex.Message);
            }

        }

        [When(@"User click on the subcategory checkbox")]
        public void ThenUserClickOnTheSubcategoryCheckbox()
        {
            driver.FindElement(By.Id("subcategory_filter0")).Click();
            Log.Information("User click on the subcategory checkbox");

           
        }

        [When(@"User click on the sort by selection box")]
        public void ThenUserClickOnTheSortBySelectionBox()
        {
            driver.FindElement(By.Id("search_sort_dropdown")).Click();
            Log.Information("User click on the sort by selection box");
        }

        [When(@"User select the sort by option high to low")]
        public void ThenUserSelectTheSortByOptionHighToLow()
        {
            driver.FindElement(By.XPath("//option[@value='price_desc']")).Click();
            Log.Information("User select the sort by option high to low");
        }


        [When(@"User click on the product with product number ""([^""]*)""")]
        public void ThenUserClickOnTheProductWithProductNumber(string productNumber)
        {
            driver.FindElement(By.XPath("(//div[@class='card-text px-2 py-1 font-size85 product_title'])[" + productNumber + "]")).Click();
            Log.Information("User click on the product with product number");
        }

        [Then(@"User wait for the selected product page to load")]
        public void ThenUserWaitForTheSelectedProductPageToLoad()
        {
            TakeScreenShot(driver);
            Log.Information("Screenshot taken");
            try
            {
                Assert.That(driver.FindElement(By.XPath("//a[@class='AddToWishList']/button")).Displayed); 
                LogTestResult("Selected product loading Test", "Selected product loading  Success");
            }
            catch (AssertionException ex)
            {
                LogTestResult("Selected product loading ", "Selected product loading  Failed", ex.Message);
            }
        }

        [When(@"User click on the add to cart button")]
        public void ThenUserClickOnTheAddToCartButton()
        {
    
            driver.FindElement(By.XPath("(//a[@class='AddToCart'])[2]/button")).Click();
            Log.Information("User click on the add to cart button");
        }

        [Then(@"User wait for the cart page to load with the selected product")]
        public void ThenUserWaitForTheCartPageToLoadWithTheSelectedProduct()
        {
            TakeScreenShot(driver);
            Log.Information("Screenshot taken");
            try
            {
                DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
                wait.PollingInterval = TimeSpan.FromMilliseconds(100);
                wait.Timeout = TimeSpan.FromSeconds(20);
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                IWebElement element= wait.Until(driver => driver.FindElement(By.XPath("//button[text()='CHECKOUT ']")));
                Assert.That(element.Displayed);
                LogTestResult("Cart page loading Test", "Cart page loading  Success");
            }
            catch (AssertionException ex)
            {
                LogTestResult("Cart page loading ", "Cart page loading  Failed", ex.Message);
            }
        }

        [When(@"User click on the checkout button")]
        public void ThenUserClickOnTheCheckoutButton()
        {            
            driver.FindElement(By.XPath("//button[text()='CHECKOUT ']")).Click();
            Log.Information("User click on the checkout button");
        }

        [Then(@"User wait for the checkout page to load with the selected product")]
        public void ThenUserWaitForTheCheckoutPageToLoadWithTheSelectedProduct()
        {
            TakeScreenShot(driver);
            Log.Information("Screenshot taken");
            try
            {
                Assert.That(driver.FindElement(By.XPath("//h5[text()='Checkout']")).Displayed);
                LogTestResult("checkout page loading Test", "checkout page loading  Success");
            }
            catch (AssertionException ex)
            {
                LogTestResult("Scheckout page loading ", "Scheckout page loading  Failed", ex.Message);
            }
        }
    }
}
