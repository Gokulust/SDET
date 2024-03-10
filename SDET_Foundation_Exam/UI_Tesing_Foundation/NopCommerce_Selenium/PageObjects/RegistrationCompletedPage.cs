using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NopCommerce_Selenium.PageObjects
{
    internal class RegistrationCompletedPage
    {
        IWebDriver driver;
        public RegistrationCompletedPage(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }

        public bool IsResgistrationCompletedPresentOrNot()
        {
            try
            {
                return driver.FindElement(By.XPath("//div[text()='Your registration completed']")).Displayed;
            }
            catch
            {
                return false; 
            }
        }
    }
}
