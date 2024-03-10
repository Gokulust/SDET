using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNuintExamples
{
    internal class Elements:CoreCodes
    {
        [Test]
        //public void TestChechBox()
        //{
        //    Thread.Sleep(3000);
        //    IWebElement elemt = driver.FindElement(By.XPath("//h5[text()='Elements']//"));
        //    elemt.Click();
        //    IWebElement cbMneu = driver.FindElement(By.XPath("//span[text()='Check Box'"));
        //    cbMneu.Click();

        //    List<IWebElement> expandcollapse = driver.FindElements(By.ClassName("rct-collapse rct-collapse-btn")).ToList();
        //    foreach(var item in expandcollapse)
        //    {
        //        item.Click();
        //    }
        //    IWebElement commandscheckbox = driver.FindElement(By.XPath("//span[text()='commands'"));
        //    commandscheckbox.Click();

        //    Assert.True(driver.)
        //}
        public void TestFormElemnts()
        {
            IWebElement firstNameField = driver.FindElement(By.Id("firstName"));
            firstNameField.SendKeys("Gokul");
            Thread.Sleep(2000);

            IWebElement lastNameField = driver.FindElement(By.Id("lastName"));
            lastNameField.SendKeys("Raj");
            Thread.Sleep(2000);

            IWebElement emailField = driver.FindElement(By.XPath("//input[@id='userEmail']"));
            emailField.SendKeys("gokulrajan@gmail.com");
            Thread.Sleep(2000);

            IWebElement genderField = driver.FindElement(By.XPath("//input[@id='gender-radio-1']//following::label"));
            genderField.Click();
            Thread.Sleep(2000);

            IWebElement mobileNumberField = driver.FindElement(By.Id("userNumber"));
            mobileNumberField.SendKeys("123456789");
            Thread.Sleep(2000);

            IWebElement dobField = driver.FindElement(By.Id("dateOfBirthInput"));
            dobField.Click();
            Thread.Sleep(1000);

            IWebElement dobMonth = driver.FindElement(By.XPath("//select[@class='react-datepicker__month-select']"));
            SelectElement selectMonth = new SelectElement(dobMonth);
            selectMonth.SelectByIndex(5);
            Thread.Sleep(1000);

            IWebElement dobYear = driver.FindElement(By.XPath("//select[@class='react-datepicker__year-select']"));
            SelectElement selectYear = new SelectElement(dobYear);
            selectYear.SelectByText("1991");
            Thread.Sleep(1000);

            IWebElement dobDay = driver.FindElement(By.XPath("//div[text()='5']"));
            dobDay.Click();
            Thread.Sleep(1000);

            IWebElement subjectsField = driver.FindElement(By.Id("subjectsInput"));
            subjectsField.SendKeys("Maths");
            subjectsField.SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            subjectsField.SendKeys("chemistry");
            subjectsField.SendKeys(Keys.Enter);
            Thread.Sleep(2000);

            IWebElement hobbiesCheckbox = driver.FindElement(By.XPath("//label[text()='Sports']"));
            hobbiesCheckbox.Click();
            Thread.Sleep(2000);

            IWebElement uploadImg = driver.FindElement(By.Id("uploadPicture"));
            uploadImg.SendKeys("C:\\Users\\Administrator\\Pictures\\Saved Pictures");
            Thread.Sleep(2000);

            IWebElement currentAddressField = driver.FindElement(By.Id("currentAddress"));
            currentAddressField.SendKeys("123 Street, City, Country");
            Thread.Sleep(1000);

            /*
            IWebElement submitButton = driver.FindElement(By.Id("submit"));
            submitButton.Click();
            */



        }
        [Test]
        public void TestWindows()
        {
            driver.Url = "https://demoqa.com/browser-windows";
            string parentWindowHandle = driver.CurrentWindowHandle;
            Console.WriteLine("Parent Window's handle -> " + parentWindowHandle);

            IWebElement clickElement = driver.FindElement(By.Id("tabButton"));
            for (var i = 0; i < 3; i++)
            {
                clickElement.Click();
                Thread.Sleep(1000);
            }
            List<string> lstWindow = driver.WindowHandles.ToList();
            string lastWindowHandle = "";
            foreach (var handle in lstWindow)
            {
                Console.WriteLine("Switching to window ->" + handle);
                driver.SwitchTo().Window(handle);
                Thread.Sleep(1000);
                Console.WriteLine("Navigating to google.com");
                driver.Navigate().GoToUrl("https://google.com");
                Thread.Sleep(1000);

                lastWindowHandle = handle;
            }
            driver.SwitchTo().Window(parentWindowHandle);
            driver.Quit();
        }

        [Test]
        public void TestAlerts()
        {
            driver.Url = "https://demoqa.com/alerts";

            IWebElement element = driver.FindElement(By.Id("alertButton"));
            Thread.Sleep(5000);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", element);

            IAlert simpleAlert = driver.SwitchTo().Alert();

            Console.WriteLine("Alert text is " + simpleAlert.Text);
            simpleAlert.Accept();
            Thread.Sleep(1000);

            element = driver.FindElement(By.Id("confirmButton"));
            Thread.Sleep(3000);
            element.Click();

            IAlert confirmationAlert = driver.SwitchTo().Alert();
            string alertText = confirmationAlert.Text;

            Console.WriteLine("Alert Text is " + alertText);
            confirmationAlert.Dismiss();

            element = driver.FindElement(By.Id("promtButton"));
            element.Click();
            Thread.Sleep(5000);
            IAlert promptAlert = driver.SwitchTo().Alert();
            alertText = promptAlert.Text;
            Console.WriteLine("Alert Text is " + alertText);
            promptAlert.SendKeys("Accepting the alert");
            Thread.Sleep(5000);
            promptAlert.Accept();

        }
    }
}
