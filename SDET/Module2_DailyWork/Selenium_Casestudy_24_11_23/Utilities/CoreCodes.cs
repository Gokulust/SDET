using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_Casestudy_24_11_23.Utilities
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

            string[] lines=File.ReadAllLines(fullPath);
            properties = new Dictionary<string, string>();
            foreach (string line in lines)
            {
                if(!string.IsNullOrEmpty(line)&& line.Contains("="))
                {
                    string[] split= line.Split('=');
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
            sparkReporter=new ExtentSparkReporter(currentDir+"/ExtentReports/extent-report_"+DateTime.Now.ToString("yyyyMMdd_HHmmss")+".html");
            ExtentObject.AttachReporter(sparkReporter);
            
            ReadConfigSettings();
            if (properties["﻿browser"].ToLower()=="edge")
            {
                driver = new EdgeDriver();
            }
            else if(properties["﻿browser"].ToLower() == "chrome")
            {
                driver = new ChromeDriver();
            }

            driver.Url = properties["baseUrl"];
            driver.Manage().Window.Maximize();
        }
        public static void ScrollViewInto(IWebDriver driver,IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true)", element);
        }
        [OneTimeTearDown]

        public void TearDown()
        {
            driver.Quit();
            ExtentObject.Flush();
        }
    }
}
