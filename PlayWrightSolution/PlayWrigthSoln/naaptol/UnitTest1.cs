using Microsoft.Playwright.NUnit;

namespace naaptol
{
    [TestFixture]
    public class Tests:PageTest
    {
        [SetUp]
        public async Task Setup()
        {
            Console.WriteLine("Opened Browser");
            await Page.GotoAsync("http://naaptol.com/");
            Console.WriteLine("eaapp.somee home page loaded");
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}