using AventStack.ExtentReports;
using NopCommerce_Selenium.Helpers;
using NopCommerce_Selenium.PageObjects;
using NopCommerce_Selenium.Utilities;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_IT_Depot_Selenium.PageObjects;
using Serilog;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace NopCommerce_Selenium.TestScripts
{
    [TestFixture]
    internal class ProductPurchaseEndToEndTest:CoreCodes
    {
        [Test]
        public void ProductPurchaseTest()
        {
            // Logging updates using Serilog
            LogUpdates();

            // Retrieving file paths and test data
            string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string? excelFilePath = currDir + "/TestData/NopCommerceData.xlsx";
            string? sheetName = "NopCommerceData";

            // Function to map Excel data to objects
            Func<DataRow,NopCommerceData> myfunction = (row) => { return new NopCommerceData() { Category = ExcelUtils.GetValueOrDefault(row, "category"), ProductPosition = ExcelUtils.GetValueOrDefault(row, "productNumber"),FirstName= ExcelUtils.GetValueOrDefault(row, "firstName"),LastName= ExcelUtils.GetValueOrDefault(row, "lastName"),Gender= ExcelUtils.GetValueOrDefault(row, "gender"),Email= ExcelUtils.GetValueOrDefault(row, "email"),Date= ExcelUtils.GetValueOrDefault(row, "date"),Month= ExcelUtils.GetValueOrDefault(row, "month"),Year= ExcelUtils.GetValueOrDefault(row, "year"),Company= ExcelUtils.GetValueOrDefault(row, "company"),Password= ExcelUtils.GetValueOrDefault(row, "password"),ConfirmPassword= ExcelUtils.GetValueOrDefault(row, "confirmPassword") }; };

            // Reading test data from Excel into a list
            List<NopCommerceData> excelSaerchData = ExcelUtils.ReadSearchData(excelFilePath, sheetName, myfunction);

            

            // Initializing HomePage using WebDriver
            HomePage homePage = new(driver);

            // Iterating through test data
            foreach (var excel in excelSaerchData)
            {
                ExtentTest test = ExtentObject.CreateTest("ProductPurchaseEndToEndTest");
                var categoryPage = homePage.ClickOnComputerLink();
                WaitAndLogAssertion(() => driver.Url.Contains("computers"), test, "ComputerLinkNavigatesToComputerPage");//verifies the navigation from the "Computers" link and checks the URL of the subsequent page.
                var productListPage = categoryPage.ClickCategoryLink(excel.Category);
                WaitAndLogAssertion(() => driver.Url.Contains(excel.Category.ToLower()), test, "PageNavigatesToSelectedCategoryPage");//Verify that the page navigates to the list of products in the selected category.
                string productName = productListPage.GetProductNameByProductPosition(excel.ProductPosition).Replace(" ","-").Replace(".","");
                var productPage = productListPage.ClickOnProductBasedOnProductPosition(excel.ProductPosition);
                WaitAndLogAssertion(() => driver.Url.Contains(productName), test, "ProductPageLoading");//selecting a product based on its position, retrieving its name, and then confirming that clicking on the product leads to a new page with that specific product name loaded
                productPage.ClickOnAddToCartButton();
                var cartPage = productPage.GoToCart();
                WaitAndLogAssertion(() => driver.Url.Contains("cart"), test, "CartPageLoading");//verify that the page navigaet to cart page.
                cartPage.ClickOnTermsOfServiceCheckBox();
                var checkoutPage = cartPage.ClickonCheckoutButton();
                var registrationPage = checkoutPage.ClickOnRegisterButton();
                WaitAndLogAssertion(() => driver.Url.Contains("register"), test, "RegisterPageLoading");//verify that the page navigaet to register page.
                var registrationCompletedPage= registrationPage.RegisterNewUser(excel.Gender, excel.FirstName, excel.LastName, excel.Email, excel.Date, excel.Month,excel.Year,excel.Company,excel.Password,excel.ConfirmPassword);
                WaitAndLogAssertion(() => registrationCompletedPage.IsResgistrationCompletedPresentOrNot(), test, "User Registration With Purschasing Product ");

            }
        }
        void WaitAndLogAssertion(Func<bool> condition, ExtentTest test, string testStep)
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.PollingInterval = TimeSpan.FromMilliseconds(100);
            wait.Timeout = TimeSpan.FromSeconds(10);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            try
            {
                wait.Until(driver => condition());
                Assert.That(condition(), Is.True);
                TakeScreenShot(testStep);
                test.Info(testStep + "passed");
                Log.Information(testStep + "passed");
            }
            catch (WebDriverTimeoutException)
            {
            
                TakeScreenShot(testStep);
                test.Fail(testStep + "failed");
                test.AddScreenCaptureFromPath(TakeScreenShot(testStep));
                Log.Error(testStep + " test " + "failed");
            }
        }
    }
}
