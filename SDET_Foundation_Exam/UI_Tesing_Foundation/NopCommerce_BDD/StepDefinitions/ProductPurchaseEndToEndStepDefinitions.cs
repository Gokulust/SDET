using AventStack.ExtentReports;
using NopCommerce_BDD.Hooks;
using NopCommerce_BDD.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Serilog;
using System;
using TechTalk.SpecFlow;

namespace NopCommerce_BDD.StepDefinitions
{
    [Binding]
    public class ProductPurchaseEndToEndStepDefinitions:CoreCodes
    {
        IWebDriver driver = AllHooks.driver;
        ExtentTest test;
        ExtentReports extent = AllHooks.extent;

        [When(@"user click on the Computers link")]
        public void WhenUserClickOnTheComputersLink()
        {
            test = extent.CreateTest("ProductPurchaseEndToEndTest");
            IWebElement computerLink = driver.FindElement(By.LinkText("Computers"));
            computerLink.Click();
        }

        [Then(@"user should be redirected to the Computers category page")]
        public void ThenUserShouldBeRedirectedToTheComputersCategoryPage()
        {
            try
            {
                Assert.That(driver.Url.Contains("computers"));
                test.Info("ComputerLinkNavigatesToComputerPage step passed");
                test.AddScreenCaptureFromPath(TakeScreenShot(driver), "ComputerLinkNavigatesToComputerPage");
                Log.Information("ComputerLinkNavigatesToComputerPage step passed");
            }
            catch(AssertionException ex)
            {
                test.Info("ComputerLinkNavigatesToComputerPage step failed");
                Log.Information("ComputerLinkNavigatesToComputerPage step failed");
                test.Fail("ProductPurchaseEndToEndTest failed");
                test.AddScreenCaptureFromPath(TakeScreenShot(driver), "ComputerLinkNavigatesToComputerPage step failed");
            }
            
            
        }

        [When(@"user navigate to the category ""([^""]*)""")]
        public void WhenUserNavigateToTheCategory(string category)
        {
            IWebElement categoryLink = driver.FindElement(By.LinkText(category));
            CoreCodes.ScrollViewInto(driver, categoryLink);
            categoryLink.Click();
        }

        [Then(@"user should see the list of products in the selected ""([^""]*)""")]
        public void ThenUserShouldSeeTheListOfProductsInTheSelectedCategory(string category)
        {
            try
            {
                Assert.That(driver.Url.Contains(category.ToLower()));
                test.Info("PageNavigatesToSelectedCategoryPage step passed");
                Log.Information("PageNavigatesToSelectedCategoryPage step passed");
            }
            catch (AssertionException ex)
            {
                test.Info("PageNavigatesToSelectedCategoryPage step failed");
                Log.Information("PageNavigatesToSelectedCategoryPage step failed");
                test.Fail("ProductPurchaseEndToEndTest failed");
                test.AddScreenCaptureFromPath(TakeScreenShot(driver), "PageNavigatesToSelectedCategoryPage step failed");
            }
           
        }

        [When(@"user select the product at position ""([^""]*)""")]
        public void WhenUserSelectTheProductAtPosition(string position)
        {
            IWebElement productElement = driver.FindElement(By.XPath("//div[@class='item-grid']/div[" + position + "]"));
            CoreCodes.ScrollViewInto(driver, productElement);
            productElement.Click();
        }

        [Then(@"user should be redirected to the product page ""([^""]*)""")]
        public void ThenUserShouldBeRedirectedToTheProductPage(string productName)
        {
            try
            {
                Assert.That(driver.Url.Contains(productName.ToLower()));
                test.Info("ProductPageLoading step passed");
                Log.Information("ProductPageLoading step passed");
            }
            catch (AssertionException ex)
            {
                test.Info("ProductPageLoading step failed");
                Log.Information("ProductPageLoading step failed");
                test.Fail("ProductPurchaseEndToEndTest failed");
                test.AddScreenCaptureFromPath(TakeScreenShot(driver), "ProductPageLoading step failed");
            }
           
        }

        [When(@"user add the product to the cart")]
        public void WhenUserAddTheProductToTheCart()
        {
            IWebElement addToCartButton = driver.FindElement(By.XPath("(//button[text()='Add to cart'])[1]"));
            ScrollViewInto(driver, addToCartButton);
            Thread.Sleep(1000);
            addToCartButton.Click();
            Thread.Sleep(1000);

            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.PollingInterval = TimeSpan.FromMilliseconds(100);
            wait.Timeout = TimeSpan.FromSeconds(10);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            ScrollViewInto(driver, driver.FindElement(By.XPath("//div[@class='bar-notification-container']")));
            IWebElement goCartPage = wait.Until(d => d.FindElement(By.XPath("//p[@class='content']/a")));
            ScrollViewInto(driver, driver.FindElement(By.XPath("//div[@class='bar-notification-container']")));
            goCartPage.Click();
        }

        [Then(@"user should see the cart page")]
        public void ThenUserShouldSeeTheCartPage()
        {
            try
            {
                Assert.That(driver.Url.Contains("cart"));
                test.Info("CartPageLoading step passed");
                Log.Information("CartPageLoading step passed");
            }
            catch (AssertionException ex)
            {
                test.Info("CartPageLoading step failed");
                Log.Information("CartPageLoading step failed");
                test.Fail("ProductPurchaseEndToEndTest failed");
                test.AddScreenCaptureFromPath(TakeScreenShot(driver), "CartPageLoading  step failed");

            }
           
        }

        [When(@"user proceed to checkout as a new user")]
        public void WhenUserProceedToCheckoutAsANewUser()
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.PollingInterval = TimeSpan.FromMilliseconds(100);
            wait.Timeout = TimeSpan.FromSeconds(10);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            IWebElement termsOfServiceCheckBox =wait.Until(driver=> driver.FindElement(By.Id("termsofservice")));
            CoreCodes.ScrollViewInto(driver, termsOfServiceCheckBox);
            termsOfServiceCheckBox.Click();

            IWebElement checkoutButton = driver.FindElement(By.Id("checkout"));
            checkoutButton.Click();

            IWebElement register =wait.Until(driver=>driver.FindElement(By.XPath("//button[text()='Register']")));
            register.Click();
        }

        [Then(@"user should see the registration page")]
        public void ThenUserShouldSeeTheRegistrationPage()
        {
            try
            {
                Assert.That(driver.Url.Contains("register"));
                test.Info("RegistrationPageLoading step passed");
                Log.Information("RegistrationPageLoading step passed");
            }
            catch (AssertionException ex)
            {
                test.Info("RegistrationPageLoading step failed");
                Log.Information("RegistrationPageLoading step failed");
                test.Fail("ProductPurchaseEndToEndTest failed");
                test.AddScreenCaptureFromPath(TakeScreenShot(driver), "RegistrationPageLoading step failed");
            }
           
        }

        [When(@"user register as a new user with details ""([^""]*)"",""([^""]*)"",""([^""]*)"",""([^""]*)"",""([^""]*)"",""([^""]*)"",""([^""]*)"",""([^""]*)"",""([^""]*)"",""([^""]*)""")]
        public void WhenUserRegisterAsANewUserWithDetails(string gender, string firstName, string lastName, string email, string date, string month, string year, string company, string password, string confirmpassword)
        {
            driver.FindElement(By.XPath("//input[@value='" + gender + "']"));
            driver.FindElement(By.Id("FirstName")).SendKeys(firstName);
            driver.FindElement(By.Id("LastName")).SendKeys(lastName);
            CoreCodes.ScrollViewInto(driver, driver.FindElement(By.Id("Email")));
            driver.FindElement(By.Name("DateOfBirthDay")).Click();
            driver.FindElement(By.XPath("//select[@name='DateOfBirthDay']/option[@value='" + date + "']")).Click();
            driver.FindElement(By.Name("DateOfBirthMonth")).Click();
            driver.FindElement(By.XPath("//select[@name='DateOfBirthMonth']/option[@value='" + month + "']")).Click();
            driver.FindElement(By.Name("DateOfBirthYear")).Click();
            driver.FindElement(By.XPath("//select[@name='DateOfBirthYear']/option[@value='" + year + "']")).Click();
            driver.FindElement(By.Id("Email")).SendKeys(email);
            driver.FindElement(By.Id("Company")).SendKeys(company);
            CoreCodes.ScrollViewInto(driver, driver.FindElement(By.Id("Password")));
            driver.FindElement(By.Id("Password")).SendKeys(password);
            driver.FindElement(By.Id("ConfirmPassword")).SendKeys(confirmpassword);
            driver.FindElement(By.Id("register-button")).Click();
        }


        [Then(@"user should complete the registration and purchase the product successfully")]
        public void ThenUserShouldCompleteTheRegistrationAndPurchaseTheProductSuccessfully()
        {
            try
            {
                Assert.That(driver.FindElement(By.XPath("//div[text()='Your registration completed']")).Displayed);
                test.Info("User Registration With Purschasing Product step passed");
                test.AddScreenCaptureFromPath(TakeScreenShot(driver), "User Registration With Purschasing Product step passed");
                Log.Information("User Registration With Purschasing Product step passed");
            }
            catch (AssertionException ex)
            {
                test.Info("User Registration With Purschasing Product step failed");
                Log.Information("User Registration With Purschasing Product failed");
                test.Fail("ProductPurchaseEndToEndTest failed");
                test.AddScreenCaptureFromPath(TakeScreenShot(driver), "User Registration With Purschasing Product step failed");

            }
            test.Pass("ProductPurchaseEndToEnd Test Passed Successfully");
            
        }
    }
}
