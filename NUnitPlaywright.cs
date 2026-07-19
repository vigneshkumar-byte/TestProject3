using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace TestProject3
{
    class NUnitPlaywright 
    {
        [Test]
        public async Task Test1()
        {
            using var playwright = await Playwright.CreateAsync();

            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            });
            var page = await browser.NewPageAsync();
            await page.GotoAsync("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
            await page.GetByPlaceholder("Username").FillAsync("Admin");
            

        }
    }
}
