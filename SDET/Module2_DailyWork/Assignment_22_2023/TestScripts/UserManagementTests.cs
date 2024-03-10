using Assignment_22_2023.PageObjects;
using SeleniumNuintExamples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_22_2023.TestScripts
{
    internal class UserManagementTests:CoreCodes
    {
        [Test, Order(1), Category("Smoke test")]
        public void SearchProduct()
        {
            var homepage = new NaaptolHomePage(driver);
            homepage.TypeSearchElement("eyewear");
            Thread.Sleep(2000);
            homepage.ClickSearchElement();
            Thread.Sleep(2000);
            Assert.That(driver.Url.Contains("eyewear"));
        }
        [Test, Order(2), Category("Smoke test")]
        [TestCase("eyewear")]
        public void SelectProduct(string search)
        {
            var homepage = new NaaptolHomePage(driver);
            if (!driver.Url.Equals("https://www.naaptol.com/"))
            {
                driver.Navigate().GoToUrl("https://www.naaptol.com/");

            }
            homepage.TypeSearchElement(search);
            var viewProductspage = homepage.ClickSearchElement();
            Thread.Sleep(2000);
            viewProductspage.ClickOnTheProduct();

            
        }
        [Test, Order(3), Category("Smoke test")]
        [TestCase("eyewear")]

        public void  AddToCart(string search)
        {

        }

    }
}
