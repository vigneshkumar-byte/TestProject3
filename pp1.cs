using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject3
{
    class pp1 
    {
        [Test]
        public async Task Test1()
        {
           using var playwright=await Playwright.CreateAsync();

            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            });
            var page=await browser.NewPageAsync();
            await page.GotoAsync("https://commitquality.com/login");
            await page.GetByPlaceholder("Enter Username").FillAsync("test");
            await page.GetByPlaceholder("Enter Password").FillAsync("test");
            await page.GetByTestId("login-button").ClickAsync();



        }
    }
}
