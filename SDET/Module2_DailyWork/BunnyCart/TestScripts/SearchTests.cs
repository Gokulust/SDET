using BunnyCart.PageObjects;
using BunnyCart.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCart.TestScripts
{
    [TestFixture]
    internal class SearchTests : CoreCodes
    {
        [Test]
        [TestCase("Water", 2)]
        public void SearchProductAndAddToCartTest(string searchtext, int count)
        {
            BunnyCartHomePage bchp = new BunnyCartHomePage(driver);
            var searchrespage = bchp?.TypeSearchInput(searchtext);
            CoreCodes.ScrollIntoView(driver, driver.FindElement(By.XPath("//*[@id=\'amasty-" +
                "shopby-product-list\']/div[2]/ol/li[1]")));
            Thread.Sleep(3000);
            //Assert.That(searchtext.Contains(searchrespage.GetFirstProductLink()));
            var productpage = searchrespage?.ClickFirstProductLink(count);
            //Assert.That(searchtext.Equals(productpage?.GetProductTitleLabel()));
            Thread.Sleep(3000);
            productpage?.ClickIncQtyLink();
            Thread.Sleep(3000);
            productpage?.ClickAddToCartBtn();
            Thread.Sleep(3000);

        }
    }
}
