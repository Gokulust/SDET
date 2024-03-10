// See https://aka.ms/new-console-template for more information
using Assignment_14_11_2023;
using NUnit.Framework;
AmazonTests amazonTests = new AmazonTests();
Tests test= new Tests();
try
{
 
    //amazonTests.InitializeChromeDriver();
    //amazonTests.TitleTest();
    test.InitializeChromeDriver();
    test.GoToYahoo();
    test.BackToGoogle();
    test.GoToYahoo();
    test.BackToGoogle();
    test.SearchResultForDiwali();
   

}
catch(AssertionException)
{
    Console.WriteLine("Fail");
}
//amazonTests.Destruct();
test.Refresh();
test.Destruct();
