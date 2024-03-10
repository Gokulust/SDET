using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Log = Serilog.Log;

namespace BunnyCart.Utilities
{
    public class CoreCodes
    {

        public void TakeScreenShot(IWebDriver driver)
        {
            ITakesScreenshot iss = (ITakesScreenshot)driver;
            Screenshot ss = iss.GetScreenshot();

            string currdir = Directory.GetParent(@"../../../").FullName;
            string? filepath = currdir + "/Screenshots/ss_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png";

            ss.SaveAsFile(filepath);

        }

        protected void LogTestResult(string testName, string result, string errorMessage = null)
        {
            Log.Information(result);

            if (errorMessage == null)
            {
                Log.Information(testName + " Passed");
            }
            else
            {
                Log.Error($"Test failed for {testName}. \n Exception: \n {errorMessage}");

            }
        }
        public static void ScrollViewInto(IWebDriver driver, IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true)", element);
        }
    }
}
