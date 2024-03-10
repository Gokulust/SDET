using AventStack.ExtentReports;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_IT_Depot_Selenium.PageObjects;
using The_IT_Depot_Selenium.Utilities;
using Serilog;
using The_IT_Depot_Selenium.Utilities;
using System.Data;

namespace The_IT_Depot_Selenium.TestScripts
{
    [TestFixture]
    internal class SearchToCheckoutEnd_To_EndTest : CoreCodes
    {
        [Test]
        public void SearchToCheckoutEndToEnd()
        {
            LogUpdates();
            string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string? excelFilePath = currDir + "/TestData/SearchProductData.xlsx";
            string? sheetName = "SearchProductData";
            Func<DataRow, SearchProductData> myfunction = (row) => { return new SearchProductData() { ProductName = ExcelUtils.GetValueOrDefault(row, "product name"), ProductNumber = ExcelUtils.GetValueOrDefault(row, "product number") }; };
            List<SearchProductData> excelSaerchData = ExcelUtils.ReadSearchData(excelFilePath, sheetName, myfunction);
            HomePage homePage = new(driver);
            foreach (var excel in excelSaerchData)
            {
                homePage.TypeSearchKeyWordInSearchInputBox(excel.ProductName);
                var searchResultsPage = homePage.ClicksOnSearchButton();
                WaitAndLogAssertion(() => searchResultsPage.IsTitlePresent(excel.ProductName), "Search Results Page Loading");
                searchResultsPage.ClickOnSubCategoryCheckBox();
                searchResultsPage.ClickOnSortBySelectionBox();
                searchResultsPage.ClickOnSortByOptionHighToLow();
                var productName = searchResultsPage.ProductName(excel.ProductNumber);
                var productPage = searchResultsPage.ClickOnProduct(excel.ProductNumber);
                string[] productNamearr = productName.Split("(");
                string fullProductName = productPage.GetFullProductName();
                WaitAndLogAssertion(() => productPage.IsTitlePresent(productNamearr[0]), "Selected Product Page Loading");
                var cartPage = productPage.ClickOnAddToCartButton();
                WaitAndLogAssertion(() => driver.FindElement(By.XPath("//button[text()='CHECKOUT ']")).Displayed, "Cart Page Loading With Selected Product");
                var checkoutPage = cartPage.ClickonCheckoutButton();
                WaitAndLogAssertion(() => driver.FindElement(By.XPath("//h5[text()='Checkout']")).Displayed, "Checkout Page Loading With Selected Product");
                driver.Navigate().GoToUrl("https://www.theitdepot.com/");
            }



        }
        void WaitAndLogAssertion(Func<bool> condition, string testName)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            ExtentTest test = ExtentObject.CreateTest(testName);

            try
            {
                Log.Information(testName + " test " + "started");
                wait.Until(driver => condition());
                Assert.That(condition(), Is.True);
                test.Pass(testName + " test " + "passed");
                Log.Information(testName + " test " + "passed");
            }
            catch (WebDriverTimeoutException)
            {
                TakeScreenShot(testName);
                test.Fail(testName + " test " + "failed");
                Log.Error(testName + " test " + "failed");
            }
        }

    }
}
