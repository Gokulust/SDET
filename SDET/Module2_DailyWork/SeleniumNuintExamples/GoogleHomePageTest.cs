using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNuintExamples
{
    [TestFixture]
    internal class GoogleHomePageTest:CoreCodes
    {
        [Ignore("other")]
        [Test]
        [Order(0)]
        public void TitleTest()
        {
            Thread.Sleep(1000);
            string title = driver.Title;
            Assert.AreEqual("Google", title);
            Console.WriteLine("title Length:", title);
            Console.WriteLine("Title test-pass");

        }
        [Ignore("other")]
        [Test]
        [Order(10)]
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
        [Ignore("other")]
        [Test]
        public void AllLinksStatusTest()
        {
            List<IWebElement> allLinks = driver.FindElements(By.TagName("a")).ToList();
            foreach(var link in allLinks)
            {
                string url=link.GetAttribute("href");
                if(url==null)
                {
                    Console.WriteLine("URL is null");
                    continue;
                }
                else
                {
                    bool isWorking =CheckLinkStatus(url);
                    if(isWorking)
                    {
                        Console.WriteLine(url + "is working");
                    }
                    else
                    {
                        Console.WriteLine(url + "is Not Working");
                    }
                }
            }
        }

    }
}
