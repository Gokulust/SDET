﻿using AventStack.ExtentReports;
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

namespace NopCommerce_Selenium.Utilities
{
    internal class CoreCodes
    {
        public IWebDriver driver;

        public ExtentReports ExtentObject;

        ExtentSparkReporter sparkReporter;

        public ExtentTest Test;

        Dictionary<string, string> properties;

        public void ReadConfigSettings()
        {
            string currentDir = Directory.GetParent(@"../../../").FullName;

            string fullPath = currentDir + "/ConfigSettings/Config.properties";

            string[] lines = File.ReadAllLines(fullPath);
            properties = new Dictionary<string, string>();
            foreach (string line in lines)
            {
                if (!string.IsNullOrEmpty(line) && line.Contains("="))
                {
                    string[] split = line.Split('=');
                    string key = split[0].Trim();
                    string value = split[1].Trim();
                    properties[key] = value;
                }
            }

        }

        [OneTimeSetUp]
        public void InitializeBrowser()
        {
            string currentDir = Directory.GetParent(@"../../../").FullName;
            ExtentObject = new ExtentReports();
            sparkReporter = new ExtentSparkReporter(currentDir + "/ExtentReport/extent-report_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".html");
            ExtentObject.AttachReporter(sparkReporter);

            ReadConfigSettings();
            driver = DriverFactory.CreateWebDriver(properties["﻿browser"].ToLower());
            driver.Url = properties["baseUrl"];
            driver.Manage().Window.Maximize();

        }
        public static void ScrollViewInto(IWebDriver driver, IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true)", element);
        }
        public static void LogUpdates()
        {
            string directory = Directory.GetParent(@"../../../").FullName;
            string logfilepath = directory + "/Logs/log_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";
            Log.Logger = new LoggerConfiguration().
                    WriteTo.Console().
                    WriteTo.File(logfilepath, rollingInterval: RollingInterval.Day).
                    CreateLogger();
        }
        public string TakeScreenShot(string testName)
        {
            ITakesScreenshot screenshot = (ITakesScreenshot)driver;
            Screenshot ss = screenshot.GetScreenshot();
            string currdir = Directory.GetParent(@"../../../").FullName;
            string filepath = currdir + "/Screenshots/" + testName + "scs_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png";
            ss.SaveAsFile(filepath);
            return filepath;

        }
        [OneTimeTearDown]
        public void TearDown()
        {
            ExtentObject.Flush();
            driver.Quit();
        }

    }
}

