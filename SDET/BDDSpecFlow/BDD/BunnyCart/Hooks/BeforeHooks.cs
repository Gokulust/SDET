using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Serilog;
using OpenQA.Selenium.Edge;

namespace BunnyCart.Hooks
{
    [Binding]
    public sealed class BeforeHooks
    {
        public static IWebDriver? driver;

        [BeforeFeature]
        public static void InitializeBrowser()
        {
            driver = new EdgeDriver();
        }

        [BeforeFeature]
        public static void LogFileCreation()
        {
            string? currdir = Directory.GetParent(@"../../../")?.FullName;
            string? logfilepath = currdir + "/Logs/SearchFeature_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";

            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File(logfilepath, rollingInterval: RollingInterval.Day)
            .CreateLogger();
        }

        [AfterFeature]
        public static void CleanUp()
        {
            driver?.Quit();
        }

        [AfterScenario]
        public static void NavigateToHomePage()
        {
            driver?.Navigate().GoToUrl("https://www.bunnycart.com/");
        }

    }
}