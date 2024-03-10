using AventStack.ExtentReports;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_IT_Depot_Selenium.Utilities;
using The_IT_Depot_Selenium.PageObjects;
using System.Data;
using Serilog;

namespace The_IT_Depot_Selenium.TestScripts
{
    internal class AddAndRemoveProductFromWishListEnd_To_EndTest : CoreCodes
    {
        [Test]
        public void AddAndRemoveWhisListProductEndToEnd()
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
                Console.WriteLine(fullProductName);
                Console.WriteLine(productNamearr[0]);
                WaitAndLogAssertion(() => productPage.IsTitlePresent(productNamearr[0]), "Selected Product Page Loading");
                var wishListPage = productPage.ClickOnAddToWishList();
                WaitAndLogAssertion(() => wishListPage.IsWishListProductPresnent(fullProductName) && wishListPage.IsMyWishListTitlePresnent(), "Wish List Page With Selected Product Loading");
                wishListPage.ClickOnRemoveButton();
                WaitAndLogAssertion(() => wishListPage.IsWishListEmpty(), "Wish List Empty Checking");


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
