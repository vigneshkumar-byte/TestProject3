using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject3.PageObjects
{
    public class LoginPage
    {
        public  readonly IPage _page;
        public LoginPage(IPage page)
        {
            _page = page;
        }
        private ILocator Username = _page.GetByPlaceholder("Enter Username");
        private ILocator Password = _page.GetByPlaceholder("Enter Password");
        private ILocator LogInButton = _page.GetByTestId("login-button");
        public async Task Login(string un,string pw)
        {
            await Username.FillAsync(un);
            await Password.FillAsync(pw);
            await LogInButton.ClickAsync();


        }

    }
}
