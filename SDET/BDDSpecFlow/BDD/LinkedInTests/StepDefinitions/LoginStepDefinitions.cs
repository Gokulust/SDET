using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace LinkedInTests.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {
        static IWebDriver driver;
        IWebElement? passwordInput;
        [BeforeFeature]
        public static void InitializeBrowser()
        {
            driver =new EdgeDriver();
        }
        [Given(@"user will be on the login page")]
        public void GivenUserWillBeOnTheLoginPage()
        {
            driver.Url = "https://www.linkedin.com/";
        }
        [AfterFeature]
        public static void CleanUp()
        {
            driver?.Quit();
        }

        [Given(@"user will enter '(.*)'")]
        public void GivenUserWillEnterUsername(string userName)
        {
            DefaultWait<IWebDriver?> fluentWait = new DefaultWait<IWebDriver?>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(10);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element not found";

            IWebElement emailInput = fluentWait.Until(d => d.FindElement(By.Id("session_key")));
            emailInput.SendKeys(userName);
        }

        [Given(@"User will enter '(.*)'")]
        public void GivenUserWillEnterPassword(string pwd)
        {
            DefaultWait<IWebDriver?> fluentWait = new DefaultWait<IWebDriver?>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(10);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element not found";

            passwordInput = fluentWait.Until(d => d.FindElement(By.Id("session_password")));
            passwordInput.SendKeys(pwd);
        }

        [When(@"User will click On Login button")]
        public void WhenUserWillClickOnLoginButton()
        {
            IJavaScriptExecutor? js = (IJavaScriptExecutor?)driver;
            js?.ExecuteScript("arguments[0].scrollIntoView(true);", driver?.FindElement(By.XPath("//button[@type='submit']")));

            Thread.Sleep(5000);
            js?.ExecuteScript("arguments[0].click();", driver?.FindElement(By.XPath("//button[@type='submit']")));
        }

        [Then(@"User will redirected to home page")]
        public void ThenUserWillRedirectedToHomePage()
        {
            Assert.That(driver.Title.Contains("Security"));
        }
    }
}
