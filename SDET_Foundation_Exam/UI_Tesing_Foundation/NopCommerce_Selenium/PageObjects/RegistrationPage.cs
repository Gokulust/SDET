using NopCommerce_Selenium.Utilities;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NopCommerce_Selenium.PageObjects
{
    internal class RegistrationPage
    {
        IWebDriver driver;
        public RegistrationPage(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How=How.Id,Using = "FirstName")]
        private IWebElement FirstNameInputBox { get; set; }

        [FindsBy(How = How.Id, Using = "LastName")]
        private IWebElement LastNameInputBox { get; set; }

        [FindsBy(How =How.Name,Using = "DateOfBirthDay")]
        private IWebElement Date { get; set; }

        [FindsBy(How = How.Name, Using = "DateOfBirthMonth")]
        private IWebElement Month { get; set; }

        [FindsBy(How = How.Name, Using = "DateOfBirthYear")]
        private IWebElement Year { get; set; }

        [FindsBy(How = How.Id, Using = "Email")]
        private IWebElement EmailInputBox { get; set; }

        [FindsBy(How = How.Id, Using = "Company")]
        private IWebElement CompanyInputBox { get; set; }

        [FindsBy(How = How.Id, Using = "Password")]
        private IWebElement PasswordInputBox { get; set; }

        [FindsBy(How = How.Id, Using = "ConfirmPassword")]
        private IWebElement ConfirmPasswordInputBox { get; set; }

        [FindsBy(How = How.Id, Using = "register-button")]
        private IWebElement RegisterButton { get; set; }

        public RegistrationCompletedPage RegisterNewUser(string gender,string firstName,string lastName,string email,string date,string month,string year,string company,string password,string cmfPassword)
        {
            IWebElement genderRadioButton = driver.FindElement(By.XPath("//input[@value='" + gender + "']"));
            genderRadioButton.Click();
            FirstNameInputBox.SendKeys(firstName);
            LastNameInputBox.SendKeys(lastName);
            CoreCodes.ScrollViewInto(driver, CompanyInputBox);
            EmailInputBox.SendKeys(email);
            Date.Click();
            driver.FindElement(By.XPath("//select[@name='DateOfBirthDay']/option[@value='" + date + "']")).Click();
            Month.Click();
            driver.FindElement(By.XPath("//select[@name='DateOfBirthMonth']/option[@value='" + month + "']")).Click();
            Year.Click();
            driver.FindElement(By.XPath("//select[@name='DateOfBirthYear']/option[@value='" + year + "']")).Click();
            CompanyInputBox.SendKeys(company);
            PasswordInputBox.SendKeys(password);
            ConfirmPasswordInputBox.SendKeys(cmfPassword);
            RegisterButton.Click();
            return new RegistrationCompletedPage(driver);
        }

    }
}
