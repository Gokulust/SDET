using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProjectSample.StepDefinitions
{
    [Binding]
    public class GoogleSearchStepDefinitions
    {
        public IWebDriver driver;

        [BeforeScenario] public void InitilaizeBrowser()
        {
            driver = new ChromeDriver();
            
        }
        [AfterScenario] public void Cleanup()
        {
            driver.Quit();
        }

        [Given(@"Google home page should be loaded")]
        public void GivenGoogleHomePageShouldBeLoaded()
        {
            driver.Url = "https://www.google.com/";
            driver.Manage().Window.Maximize();
        }

        [When(@"Type ""(.*)"" in the search text input")]
        public void WhenTypeInTheSearchTextInput(string searchText)
        {
           driver.FindElement(By.Id("APjFqb")).SendKeys(searchText);
        }

        [When(@"Click on the google search button")]
        public void WhenClickOnTheGoogleSearchButton()
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element Not Found";

            IWebElement googleSearchButton = fluentWait.Until(d => { IWebElement searchbutton= d.FindElement(By.Name("btnK")); return searchbutton.Displayed ? searchbutton : null; });
            if (googleSearchButton != null )
            {
                googleSearchButton.Click();
            }
        }

        [Then(@"The results should be displayed on the next page with title ""(.*)""")]
        public void ThenTheResultsShouldBeDisplayedOnTheNextPageWithTitle(string title)
        {
            Assert.That(driver.Title,Is.EqualTo(title));
        }

        [When(@"Click on the IMFL button")]
        public void WhenClickOnTheIMFLButton()
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element Not Found";

            IWebElement IMFL = fluentWait.Until(d => { IWebElement searchbutton = d.FindElement(By.Name("btnK")); return searchbutton.Displayed ? searchbutton : null; });
            if (IMFL != null)
            {
                IMFL.Click();
            }
        }

        [Then(@"The results should be redirected to a new page with title ""([^""]*)""")]
        public void ThenTheResultsShouldBeRedirectedToANewPageWithTitle(string title)
        {
            Assert.That(driver.Title.Contains(title));
        }


    }
}
