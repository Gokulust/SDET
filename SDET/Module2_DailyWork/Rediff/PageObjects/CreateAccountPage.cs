using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rediff.PageObjects
{
    internal class CreateAccountPage
    {
        IWebDriver driver;
        public CreateAccountPage(IWebDriver driver) {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //Arrange
        [FindsBy(How=How.XPath,Using ="//input[contains(@name,'name')]")]
        public IWebElement FullNameText { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'login')]")]
        public IWebElement RediffMailText { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'btnchkavail')]")]
        public IWebElement CheckAvailability { get; set;}

        [FindsBy(How=How.Id, Using ="Register")]

        public IWebElement CreateMyAccountButton { get; set; }

        //Act
        public void FullNameType(string fullname)
        {
            FullNameText.SendKeys(fullname);
        }
        public void RediffMailType(string email)
        {
            RediffMailText.SendKeys(email);
        }
        public void CheckAvailabilityButtonClick()
        {
            CheckAvailability.Click();
        }
        public void FullNameClear()
        {
            FullNameText.Clear();
        }
        public void RediffMailClear()
        {
            RediffMailText.Clear();
        }
        public void CreatemyAccountButtonClick()
        {
            CreateMyAccountButton.Click();
        }
    }
}
