using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;
using TestProject3.Driver;
using TestProject3.PageObjects;

namespace TestProject3
{
    public class Class1
    {
        [Test]
        public async Task Test()
        {
            using var playwright=await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            });
            var page = await browser.NewPageAsync();
            LoginPage lp=new LoginPage(page);
            await lp.Login("test", "test");
            Console.WriteLine("vigneshkumar");
        }
    }
}
