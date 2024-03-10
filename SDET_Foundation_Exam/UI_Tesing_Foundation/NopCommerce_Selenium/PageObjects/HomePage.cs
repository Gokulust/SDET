﻿using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NopCommerce_Selenium.PageObjects
{
    internal class HomePage
    {
        IWebDriver driver;
        public HomePage(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How=How.LinkText,Using = "Computers")]
        private IWebElement ComputersLink { get; set; }

        public CategoryPage ClickOnComputerLink()
        {
            ComputersLink.Click();
            return new CategoryPage(driver);
        }
    }
}
