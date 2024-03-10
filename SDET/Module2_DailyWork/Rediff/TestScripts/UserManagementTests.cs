using Rediff.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rediff.TestScripts
{
    [TestFixture]
    internal class UserManagementTests:CoreCodes
    {
        //Asserts
        [Test,Order(1),Category("Smoke test")]
        public void CreateAccountLinkTest()
        {
            var homepage = new RediffHomePage(driver);
            driver.Navigate().GoToUrl("https://www.rediff.com/");
            homepage.ClickOnCreateAccount();
            Thread.Sleep(2000);
            Assert.That(driver.Url.Contains("register"));
        }
        [Test,Order(2),Category("Smoke test")]
        public void SignInTest()
        {
            var homepage = new RediffHomePage(driver);
            driver.Navigate().GoToUrl("https://www.rediff.com/");
            homepage.SigInClick();
            Thread.Sleep(2000);
            Assert.That(driver.Url.Contains("login"));
        }
        [Test,Order(1),Category("Regression Testing")]
        public void CreateAccountTest()
        {
            var homepage = new RediffHomePage(driver);
            if(!driver.Url.Equals("https://www.rediff.cpm/"))
            {
                driver.Navigate().GoToUrl("https://www.rediff.com/");

            }
            var createAccountpage=homepage.createAccountClick();
            Thread.Sleep(3000);
            createAccountpage.FullNameType("gokul");
            createAccountpage.RediffMailType("gokul@gmi.com");
            createAccountpage.CheckAvailabilityButtonClick();
            Thread.Sleep(2000);
        }
        [Test, Order(2), Category("Regression Testing")]
        public void SignIn()
        {
            var homepage=new RediffHomePage(driver);
            if (!driver.Url.Equals("https://www.rediff.cpm/"))
            {
                driver.Navigate().GoToUrl("https://www.rediff.com/");

            }
            Thread.Sleep(3000);
            var siginPage = homepage.SigInClick();
            siginPage.TypeUserName("gokul");
            siginPage.TypePasswordText("pass");
            siginPage.ClickRememberMe();
            Assert.False(siginPage.RememberMeCheckBox.Selected);
            Thread.Sleep(2000);
            siginPage.ClickSignInButton();
            
            Thread.Sleep(2000);

        }
    }
}
