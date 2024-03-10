using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NopCommerce_Selenium.SeleniumDriver
{
    internal class DriverFactory
    {
        public static IWebDriver CreateWebDriver(string browserType)
        {
            IWebDriver driver;

            switch (browserType)
            {
                case "chrome":
                    driver = CreateChromeDriver();
                    break;
                case "edge":
                    driver = CreateEdgeDriver();
                    break;
                default:
                    throw new ArgumentException("Invalid browser type specified");
            }

            return driver;
        }

        private static IWebDriver CreateChromeDriver()
        {

            IWebDriver driver = new ChromeDriver();
            return driver;
        }


        private static IWebDriver CreateEdgeDriver()
        {
            IWebDriver driver = new EdgeDriver();
            return driver;
        }
    }
}
