using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rediff.PageObjects
{
    internal class SigninPage
    {
        IWebDriver driver;
        public SigninPage(IWebDriver driver) {
            this.driver = driver?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }

        //Arrange
        [FindsBy(How=How.Id,Using ="login1")]
        public IWebElement UserNameText { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement PasswordText { get; set; }

        [FindsBy(How = How.Id, Using = "remember")]
        public IWebElement RememberMeCheckBox { get; set; }

        [FindsBy(How = How.Id, Using = "proceed")]
        public IWebElement SignInButton { get; set; }

        public void TypeUserName(string username)
        {
            UserNameText.SendKeys(username);
        }

        public void TypePasswordText(string password)
        {
            PasswordText.SendKeys(password);
        }

        public void ClickRememberMe()
        {
            RememberMeCheckBox.Click();
        }

        public void ClickSignInButton()
        {
            SignInButton.Click();
        }
    }
}
