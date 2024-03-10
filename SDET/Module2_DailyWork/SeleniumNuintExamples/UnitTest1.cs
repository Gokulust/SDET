using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace SeleniumNuintExamples
{
    public class Tests
    {
        IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Url = "https://www.google.com";
        }

        [Test]
        public void CheckForTitle()
        {
            
            Thread.Sleep(2000);
            string title=driver.Title;
            Assert.AreEqual("Google", title);
          
        }
      

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}