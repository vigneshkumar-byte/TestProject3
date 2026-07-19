using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;
using TestProject3.Config;

namespace TestProject3.Driver
{
    public class PlaywrightDriver_Intializer : IPlaywrightDriver_Intializer
    {
        public const float DEFAULT_TIMEOUT = 30f;
        public async Task<IBrowser> GetChromeDriverAsync(TestSettings testSettings)
        {
            var options = GetParameters(testSettings.Args, testSettings.timeout, testSettings.Headless);
            options.Channel = "chrome";
            return await GetBrowserAsync(DriverType.Chromium, options);
        }
        public async Task<IBrowser> GetFireFoxDriverAsync(TestSettings testSettings)
        {
            var options = GetParameters(testSettings.Args, testSettings.timeout, testSettings.Headless);
            options.Channel = "firefox";
            return await GetBrowserAsync(DriverType.Firefox, options);
        }
        public async Task<IBrowser> GetWebKitDriverAsync(TestSettings testSettings)
        {
            var options = GetParameters(testSettings.Args, testSettings.timeout, testSettings.Headless);
            options.Channel = "";
            return await GetBrowserAsync(DriverType.WebKit, options);
        }
        public async Task<IBrowser> GetChromiumDriverAsync(TestSettings testSettings)
        {
            var options = GetParameters(testSettings.Args, testSettings.timeout, testSettings.Headless);
            options.Channel = "chromium";
            return await GetBrowserAsync(DriverType.Chromium, options);
        }
        public async Task<IBrowser> GetEdgeDriverAsync(TestSettings testSettings)
        {
            var options = GetParameters(testSettings.Args, testSettings.timeout, testSettings.Headless);
            options.Channel = "msedge";
            return await GetBrowserAsync(DriverType.Chromium, options);
        }
        private async Task<IBrowser> GetBrowserAsync(DriverType driverType, BrowserTypeLaunchOptions options)
        {
            var playwright = await Playwright.CreateAsync();
            return await playwright[driverType.ToString().ToLower()].LaunchAsync(options);
        }
        private BrowserTypeLaunchOptions GetParameters(string[]? args, float? timeout = DEFAULT_TIMEOUT, bool? headless = true)
        {
            return new BrowserTypeLaunchOptions
            {
                Args = args,
                Timeout = ToMilliseconds(timeout),
                Headless = headless,
            };
        }
        private static float? ToMilliseconds(float? seconds)
        {
            return seconds * 1000;
        }
    }
}
