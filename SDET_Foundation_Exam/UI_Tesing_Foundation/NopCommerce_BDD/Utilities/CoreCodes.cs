using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NopCommerce_Selenium.SeleniumDriver;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NopCommerce_BDD.Utilities
{
    public class CoreCodes
    {
        public string TakeScreenShot(IWebDriver driver)
        {
            ITakesScreenshot screenshot = (ITakesScreenshot)driver;
            Screenshot ss = screenshot.GetScreenshot();
            string currdir = Directory.GetParent(@"../../../").FullName;
            string filepath = currdir + "/Screenshots/ss_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png";
            ss.SaveAsFile(filepath);
            return filepath;
        }
        public DefaultWait<IWebDriver> GetWait(IWebDriver driver)
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.PollingInterval = TimeSpan.FromMilliseconds(100);
            wait.Timeout = TimeSpan.FromSeconds(10);
            return wait;
        }
        public static void ScrollViewInto(IWebDriver driver, IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true)", element);
        }

    }
}

