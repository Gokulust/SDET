// See https://aka.ms/new-console-template for more information
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using OpenQA.Selenium.DevTools.V117.WebAuthn;
using NUnit.Framework;
using SeleniumExample;

GHPTests gHPTests=new GHPTests();
AmazonTests amazonTests=new AmazonTests();
List<string> list = new List<string>();
//list.Add("Edge");
list.Add("Chrome");
foreach (var item in list)
{
    switch (item)
    {
        case "Edge":
            amazonTests.InitializeEdgeDriver(); 
            break;
        case "Chrome":
            amazonTests.InitializeChromeDriver();
            break;
    }
    try
    {
        // gHPTests.TitleTest();
        //gHPTests.PageSourceTest();
        //gHPTests.GSTest();
        //gHPTests.GmaiLinkTest();
        //gHPTests.ImagesLinkTest();
        //gHPTests.LocalizationTest();
        //gHPTests.GAppYoyubeTest();
        //amazonTests.TitleTest(); 
        //amazonTests.LogoClickedTest();
        //amazonTests.SearchProductTest();
        // amazonTests.SignInAccListTest();
        amazonTests.SearchAndFilterProductByBrandTest();


    }
    catch (AssertionException)
    {
        Console.WriteLine("Fail");
    }
    catch(NoSuchElementException ex)
    {
        Console.WriteLine(ex.Message);
    }
    amazonTests.Destruct();

}
