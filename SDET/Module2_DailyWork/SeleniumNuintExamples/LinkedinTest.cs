using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNuintExamples
{
    internal class LinkedinTest:CoreCodes
    {
        [Test]
        [Author("Poornima","trsipo@fgh.com")]
        [Description("Check for Valid Login")]
        [Category("Regression Testing")]

        public void LoginOneTest()
        {
            //WebDriverWait wait=new WebDriverWait(driver,TimeSpan.FromSeconds(3));

           // IWebElement emailInput = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("session_key")));
            //IWebElement emailInput = wait.Until(d => d.FindElement(By.Id("session_key")));


           // IWebElement passwordIput= wait.Until(ExpectedConditions.ElementIsVisible(By.Id("session_password")));
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element Not Found";

            IWebElement emailInput = fluentWait.Until(d => d.FindElement(By.Id("session_key")));
            IWebElement passwordInput=fluentWait.Until(d => d.FindElement(By.Id("session_password")));
            
            emailInput.SendKeys("password.com");
            passwordInput.SendKeys("Password");
            Thread.Sleep(2000);
            ClearForm(emailInput);
            ClearForm(passwordInput);

            emailInput.SendKeys("gokul.com");
            passwordInput.SendKeys("gokul");
            Thread.Sleep(2000);
            ClearForm(emailInput);
            ClearForm(passwordInput);

            emailInput.SendKeys("shirim.com");
            passwordInput.SendKeys("shirin");
            Thread.Sleep(2000);
            ClearForm(emailInput);
            ClearForm(passwordInput);


            IWebElement showhide = fluentWait.Until(d=>d.FindElement(By.XPath("//button[@class='font-sans text-md font-bold text-color-action z-10 ml-[12px] hover:cursor-pointer']"))); 
            showhide.Click();

            
            
            Thread.Sleep(1000);

        }
        void ClearForm(IWebElement element)
        {
            element.Clear();
        }
        [Test]
        [Author("gokul","gokul@.com")]
        [Description("Check for invalid login")]
        [Category("smoke testing")]
        public void LoginTwoTest() { 

        }
        [Test]
        [Author("shirin","shirin@gmail.com")]
        [Description("Check for InValid Login")]
        [Category("Regression Testing")]
        //[TestCase("wffgfugv@xty.com","2344")]
        //[TestCase("wfssdiugv@xty.com", "2erd")]
        //[TestCase("gokulugv@xty.com", "we344")]
        [TestCaseSource(nameof(InvalidLoginData))]


        public void LoginThreeTest(string email,string password)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element Not Found";

            IWebElement emailInput = fluentWait.Until(d => d.FindElement(By.Id("session_key")));
            IWebElement passwordInput = fluentWait.Until(d => d.FindElement(By.Id("session_password")));
            emailInput.SendKeys(email);
            passwordInput.SendKeys(password);
            TakeScreenShot();
            IJavaScriptExecutor js=(IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(By.XPath("//button[@type='submit']")));

            Thread.Sleep(5000);

            js.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//button[@type='submit']")));

            ClearForm(emailInput);
            ClearForm(passwordInput);
         

        }
        static object[] InvalidLoginData()
        {
            return new object[]
            {
                new object[] {"gokul@gmail.com","23hsig"},
               
            };
        }
      
    }
}
