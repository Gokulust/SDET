using BunnyCart.Hooks;
using BunnyCart.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Serilog;
using System;
using TechTalk.SpecFlow;

namespace BunnyCart.StepDefinitions
{
    [Binding]
    public class SearchAndAddToCartSteps : CoreCodes
    {
        IWebDriver? driver = BeforeHooks.driver;
        string? label;

        [Given(@"Search page is loaded")]
        public void GivenSearchPageIsLoaded()
        {
            driver.Url = "https://www.bunnycart.com/catalogsearch/result/?q=water";
        }

        [When(@"User selects a '([^']*)'")]
        public void WhenUserSelectsA(string prodno)
        {
            IWebElement prod = driver.FindElement(By.XPath("(//a[@class='product-item-link'])[" + prodno +"]"));
            label = prod.Text;
            prod.Click();
        }

        [Then(@"Product page is loaded")]
        public void ThenProductPageIsLoaded()
        {
            TakeScreenShot(driver);
            try
            {
                Assert.That(driver.FindElement(By.XPath("//h1[@class='page-title']")).Text.Equals(label));
                LogTestResult("Product Page Test", "Product Page Test success");
            }
            catch (AssertionException ex)
            {
                LogTestResult("Product Page Test", "Product Page Test Failed", ex.Message);
            }
        }
        [When(@"User clicks on the addtocart button")]
        public void WhenUserClicksOnTheAddtocartButton()
        {
            Thread.Sleep(1000);
            IWebElement addToCartButtom = driver.FindElement(By.Id("product-addtocart-button"));
            //CoreCodes.ScrollViewInto(driver, addToCartButtom);
            addToCartButtom.Click();
        }

        [Then(@"Modal with viwecart appers")]
        public void ThenModalWithViwecartAppers()
        {
            try
            {
                Thread.Sleep(2000);

                //IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                //js.ExecuteScript("arguments[0].click()", driver.FindElement(By.XPath("(//footer/button/span)[3]")));
                //CoreCodes.ScrollViewInto(driver, driver.FindElement(By.XPath("(//footer/button/span)[3]")));
                Assert.That(driver.FindElement(By.XPath("(//footer/button/span)[3]")).Displayed);
                LogTestResult("Product Added To Cart ", "Product added to cart success");
            }
            catch (AssertionException ex)
            {
                LogTestResult("Product Added To Cart ", "Product Added To Cart Test Failed", ex.Message);
            }

        }






    }
}
