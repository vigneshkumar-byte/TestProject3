using Microsoft.Playwright;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using System.Threading.Channels;
using TestProject3.Config;
using TestProject3.Driver;
using static TestProject3.Config.TestSettings;

namespace TestProject3
{
    public class Tests
    {
        private PlaywrightDriver_Intializer _playwrightDriver_Intializer;
        private PlaywrightDriver _driver;
        [SetUp]
        public void Setup()
        {
            TestSettings testSettings = new TestSettings
            {
               
                Headless = false,
                DriverType = DriverType.Firefox


            };


            _playwrightDriver_Intializer = new PlaywrightDriver_Intializer();

             _driver = new PlaywrightDriver(testSettings, _playwrightDriver_Intializer);
            
            
        }
        [Test]
        public async Task Test2()
        {
           var page= await _driver.Page;
            await page.GotoAsync("http://eaapp.somee.com/");
            await page.ClickAsync("text=Login");

        }
        [Test]
        public async Task Test3()
        {
            var page = await _driver.Page;
            await page.GotoAsync("http://eaapp.somee.com/");
            await page.ClickAsync("text=Login");
            await page.GetByText("User Name").FillAsync("admin");
            await page.GetByLabel("Password").FillAsync("password");


        }
        [TearDown]
        public async Task TearDown()
        {
            var browser= await _driver.Browser;
            await browser.CloseAsync();
           await  browser.DisposeAsync();
        }


    }
}
