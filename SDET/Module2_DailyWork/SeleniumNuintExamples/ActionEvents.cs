using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNuintExamples
{
    internal class ActionEvents:CoreCodes
    {
        [Test]
        public void HomeLinkTest()
        {
            IWebElement homelink = driver.FindElement(By.LinkText("Home"));

        }
        


    }
}
