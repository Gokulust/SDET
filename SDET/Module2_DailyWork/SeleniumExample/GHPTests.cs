using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumExample
{
    internal class GHPTests
    {
        IWebDriver? driver;
        public void InitializeChromeDriver()
        {
            driver = new ChromeDriver();
            driver.Url = "https://www.google.com";
            driver.Manage().Window.Maximize();



        }
        public void InitializeEdgeDriver()
        {
            driver = new EdgeDriver();
            driver.Url = "https://www.google.com";
            driver.Manage().Window.Maximize();
        }
        public  void TitleTest()
        {
            Thread.Sleep(1000);
            string title = driver.Title;

            Assert.AreEqual("Google", title);
            Console.WriteLine("title Length:",title);
            Console.WriteLine("Title test-pass");
            
        }
        public void GSTest()
        {
            IWebElement serachinputtextbox = driver.FindElement(By.Id("APjFqb"));
            serachinputtextbox.SendKeys("hp laptop");
            Thread.Sleep(2000);
            IWebElement gsButton = driver.FindElement(By.Name("btnK"));
            gsButton.Click();
            string title = driver.Title;
            Assert.AreEqual("hp laptop - Google Search", title);
            Console.WriteLine("Google Search Test -Pass");

        }
        public void PageSourceTest()
        {
            Console.WriteLine("PS :"+driver.PageSource);
            Console.WriteLine(driver.Url);
            Assert.AreEqual("https://www.google.com/", driver.Url);
            Console.WriteLine("PS Length"+driver.PageSource.Length);
        }
        public void GmaiLinkTest()
        {
            driver.Navigate().Back();
            driver.FindElement(By.LinkText("Gmail")).Click();
            Thread.Sleep(3000);
            string title = driver.Title;
            Assert.That(title.Contains("Gmail"));
            Console.WriteLine("GmailLinkTest-Pass");
           
        }

        public void ImagesLinkTest()
        {
            driver.Navigate().Back();
            driver.FindElement(By.PartialLinkText("mag")).Click();
            Thread.Sleep(1000);
            Assert.That(driver.Title.Contains("Images"));
            Console.WriteLine("ImageLinkTest-Pass");
        }
        public void LocalizationTest()
        {
            string loc = driver.FindElement(By.XPath("/html/body/div[1]/div[6]/div[1]")).Text;
            Thread.Sleep(1000);
            Assert.That(loc.Equals("India"));
            Console.Write("Localization Test-Pass");

        }
        public void GAppYoyubeTest()
        {
            Thread.Sleep(1000);
            IWebElement menuIcon = driver.FindElement(By.CssSelector("a.gb_d"));
            menuIcon.Click();
            Thread.Sleep(2000);
            IWebElement youtubeIcon = driver.FindElement(By.CssSelector("a.tX9u1b"));
            youtubeIcon.Click();
            Thread.Sleep(3000);
            Assert.AreEqual("https://www.youtube.com/", driver.Url);
            Console.WriteLine("Youtube-Pass");
        }
        public void Destruct()
        {
            driver.Close();

        }
    }
}
