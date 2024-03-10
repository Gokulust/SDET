using BunnyCart.PageObjects;
using BunnyCart.Utilities;
using DocumentFormat.OpenXml.Drawing.ChartDrawing;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCart.TestScripts
{
    [TestFixture]
    internal class BunnyCartTests : CoreCodes
    {

        [Test]
        public void SignUpTest()
        {
            BunnyCartHomePage bunnyCartHomePage = new BunnyCartHomePage(driver);
            bunnyCartHomePage.ClickCreateAnAccountLink();
            Thread.Sleep(1000);

            try
            {
                Assert.That(driver?.FindElement(By.XPath("//div[" +
                    "@class='modal-inner-wrap']//following::h1[2]")).Text,
                    Is.EqualTo("Create an Account"));
                test = extent.CreateTest("Create Account Link Test");
                test.Pass("Create Account Link success");

            }
            catch (AssertionException)
            {
                test = extent.CreateTest("Create Account Link Test");
                test.Fail("Create Account Link failed");

            }


            Assert.That(driver?.FindElement(By.XPath("//div[" +
                 "@class='modal-inner-wrap']//following::h1[2]")).Text,
                 Is.EqualTo("Create an Account"));

            string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string? excelFilePath = currDir + "/TestData/InputData.xlsx";
            string? sheetName = "CreateAccount";

            List<SignUp> excelDataList = ExcelUtils.ReadExcelData(excelFilePath, sheetName);

            foreach (var excelData in excelDataList)
            {

                string? firstName = excelData?.FirstName;
                string? lastName = excelData?.LastName;
                string? email = excelData?.Email;
                string? pwd = excelData?.Password;
                string? conpwd = excelData?.ConfirmPassword;
                string? mbno = excelData?.MobileNumber;

                Console.WriteLine($"First Name: {firstName}, Last Name: {lastName}, Email: {email}, Password: {pwd}, Confirm Password: {conpwd}, Mobile Number: {mbno}");


                bunnyCartHomePage.SignUp(firstName, lastName, email, pwd, conpwd, mbno);


            }

        }
        //try
        //{
        //    Assert.That(driver.FindElement(By.XPath("//div[" + "@class='modal-inner-wrap']//following::h1[2]")).Text,
        //        Is.EqualTo("Create an Account"));
        //    bunnyCartHomePage.ClickCreateAccountButton("raj", "kumar", "raj@gmail.com", "12345", "12345", "9876543423");
        //}
        //catch(AssertionException)
        //{
        //    Console.WriteLine("Sign Up failed");
        //}


    }
}
