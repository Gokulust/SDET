using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using Selenium_Casestudy_24_11_23.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Selenium_Casestudy_24_11_23.PageObjects;

namespace Selenium_Casestudy_24_11_23.TestScripts
{
    [TestFixture]
    internal class NaaptolTests:CoreCodes
    {

        [Test,Order(1),Category("Smoke Testing")]
        
        public void SearchForAProduct()
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(50);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element not found";

            string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string? excelFilePath = currDir + "/TestData/SearchData.xlsx";
            string? sheetName = "SearchData";

            var naaptolHomePage = new NaaptolHomePage(driver);
            List<SearchData> excelSaerchData=SearchUtils.ReadSearchData(excelFilePath,sheetName);
            foreach(var  excel in excelSaerchData)
            {
                var viewProductPage = naaptolHomePage.SearchForAProduct(excel.SearchKeyWord);
                Thread.Sleep(2000);
                try
                {
                    
                    Assert.That(driver.Url.Contains(excel.SearchKeyWord));
                    Test = ExtentObject.CreateTest("page loading for searched keyword");
                    Test.Pass("page successfully loaded for searched keyword");
                }
                catch(AssertionException ex)
                {
                    Test = ExtentObject.CreateTest("page loading for searched keyword");
                    Test.Fail("page loading for searched keyword failed");
                }
               
                string Text = viewProductPage.TextInsideATag(excel.ElementPosition).Text;
                List<string> nextwindow = driver.WindowHandles.ToList();
                var productPage= viewProductPage.ClickOnTheSelectedProduct(excel.ElementPosition);
                try
                {

                    Assert.That(Text.Equals(productPage.ProductTextNameElement.Text));
                    Test = ExtentObject.CreateTest("Selected product loaded");
                    Test.Pass("Selected product loaded passed");
                }
                catch (AssertionException ex)
                {
                    Test = ExtentObject.CreateTest("Selected product loaded");
                    Test.Fail("Selected product loaded failed");
                }
               
                productPage.Sizeselect();
                Thread.Sleep(1000);
                productPage.BuyNowButtonClicked();
                Thread.Sleep(1000);
                try
                {

                    Assert.That(productPage.ProductTextNameElement.Text.Equals(productPage.ProductCartNameElement.Text));
                    Test = ExtentObject.CreateTest("product added to cart");
                    Test.Pass("product added to cart passed");
                }
                catch (AssertionException ex)
                {
                    Test = ExtentObject.CreateTest("product added to cart");
                    Test.Fail("product added to cart");
                }
               
                driver.Close();
                driver.SwitchTo().Window(nextwindow[0]);
                naaptolHomePage.ClearSearchInputElement();

                


            }


        }
    }
}
