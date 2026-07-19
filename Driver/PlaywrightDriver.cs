using Microsoft.Playwright;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using TestProject3.Config;

namespace TestProject3.Driver
{
    public class PlaywrightDriver
    {
        private readonly AsyncTask<IBrowser> _browser;
        private readonly AsyncTask<IBrowserContext> _browserContext;
        private readonly TestSettings _testSettings;
        private readonly AsyncTask<IPage> _page;
        private readonly IPlaywrightDriver_Intializer _playwrightDriver_Intializer;
        public PlaywrightDriver(TestSettings testSettings, IPlaywrightDriver_Intializer playwrightDriver_Intializer)
        {
            this._testSettings = testSettings;
            _browser = new AsyncTask<IBrowser>(InitializePlaywrightAsync);
            _browserContext = new AsyncTask<IBrowserContext>(CreateBrowserContext);
            _page = new AsyncTask<IPage>(CreatePageAsync);

            _playwrightDriver_Intializer = playwrightDriver_Intializer;
        }
        public Task<IPage> Page=>_page.Value;
        public Task<IBrowser> Browser=>_browser.Value;
        public Task<IBrowserContext> BrowserContext=>_browserContext.Value;

        public async Task<IBrowser> InitializePlaywrightAsync()
        {
            return _testSettings.DriverType switch
            {
                 DriverType.Chromium=>await _playwrightDriver_Intializer.GetChromiumDriverAsync(_testSettings),
                //DriverType.Chrome => await playwrightDriver["chrome"].LaunchAsync(browserOpt),
                // DriverType.Edge => await playwrightDriver["msedge"].LaunchAsync(browserOpt),
                DriverType.Firefox =>  await _playwrightDriver_Intializer.GetFireFoxDriverAsync(_testSettings),
                _ => await _playwrightDriver_Intializer.GetChromiumDriverAsync(_testSettings),
            };


        }
        private async Task<IBrowserContext> CreateBrowserContext()
        {
            return await  (await _browser).NewContextAsync();
        }
        private async Task<IPage> CreatePageAsync()
        {
            return await (await _browserContext).NewPageAsync();
        }
    

        

    }
}
