using Microsoft.Playwright;
using System.Runtime.InteropServices;

namespace ConsoleAppPJ
{
    internal class Program
    {
        static async void Main(string[] args)
        {
            //playwrite startup
            using var playwright = await Playwright.CreateAsync();

            //Launch browser
            await using var browser =await playwright.Chromium.LaunchAsync();

            //page instance 
            var context =await browser.NewContextAsync();
            var page=await context.NewPageAsync();

            Console.WriteLine("Opened Browser");
            await page.GotoAsync("https://www.google.com");
            Console.WriteLine("Page Loaded");

            await page.GetByTitle("Search").FillAsync("hp laptop");
            Console.WriteLine("typed");
            await page.GetByRole("button").ClickAsync();
            Console.WriteLine("clicked");

            await page.Get
        }

    }
}