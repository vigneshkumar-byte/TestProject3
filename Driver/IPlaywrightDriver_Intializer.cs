using Microsoft.Playwright;
using TestProject3.Config;

namespace TestProject3.Driver
{
    public interface IPlaywrightDriver_Intializer
    {
        Task<IBrowser> GetChromeDriverAsync(TestSettings testSettings);
        Task<IBrowser> GetChromiumDriverAsync(TestSettings testSettings);
        Task<IBrowser> GetEdgeDriverAsync(TestSettings testSettings);
        Task<IBrowser> GetFireFoxDriverAsync(TestSettings testSettings);
        Task<IBrowser> GetWebKitDriverAsync(TestSettings testSettings);
    }
}