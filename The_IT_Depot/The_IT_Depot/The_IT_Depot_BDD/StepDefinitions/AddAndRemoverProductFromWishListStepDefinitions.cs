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
    public class AddAndRemoverProductFromWishListStepDefinitions:CoreCodes
    {
        IWebDriver driver = AllHooks.driver;
        [When(@"User add the product to the wish list")]
        public void WhenUserAddTheProductToTheWishList()
        {
            driver.FindElement(By.XPath("(//a[@class='AddToWishList'])/button")).Click();
            Log.Information("User add the product to the wish list");
            
        }

        [Then(@"User wait for the wish list page with selected product to load")]
        public void ThenUserWaitForTheWishListPageWithSelectedProductToLoad()
        {
            TakeScreenShot(driver);
            Log.Information("Screenshot taken");
            try
            {
                DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
                wait.PollingInterval = TimeSpan.FromMilliseconds(100);
                wait.Timeout = TimeSpan.FromSeconds(20);
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                IWebElement element=wait.Until(d => d.FindElement(By.XPath("//h1[text()='My Wish List']")));
                Assert.That(element.Displayed);
                LogTestResult("Wish List Page loading Test", "SWish List Pageloading  Success");
            }
            catch (AssertionException ex)
            {
                LogTestResult("Wish List Page loading test ", "Wish List Page loading  Failed", ex.Message);
            }
        }

        [When(@"User remove the product from the wish list")]
        public void WhenUserRemoveTheProductFromTheWishList()
        {
            driver.FindElement(By.XPath("(//a[text()='×'])[1]")).Click();
        }

        [Then(@"User check if the wish list is empty")]
        public void ThenUserCheckIfTheWishListIsEmpty()
        {
            TakeScreenShot(driver);
            Log.Information("Screenshot taken");
            try
            {
                DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
                wait.PollingInterval = TimeSpan.FromMilliseconds(100);
                wait.Timeout = TimeSpan.FromSeconds(20);
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                IWebElement element = wait.Until(d => d.FindElement(By.XPath("//p[text()='Your Wishlist is Empty']")));
                Assert.That(element.Displayed);
                LogTestResult("Empty WishList Check Test", "Empty WishList Check text   Success");
            }
            catch (AssertionException ex)
            {
                LogTestResult("Empty WishList Check Test ", "Search result loading  Failed", ex.Message);
            }
        }
    }
}
