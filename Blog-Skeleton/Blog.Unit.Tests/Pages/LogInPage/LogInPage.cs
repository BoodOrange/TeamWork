using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Blog.Unit.Tests.Pages.LogInPage
{
    using System.Web;

    public partial class LogInPage : BasePage
    {
        public LogInPage(IWebDriver driver) : base(driver)
        {
            this.PageUrl += "/Account/Login";
        }

        public void NavigateToWithReturnUrl(string destination)
        {
            Driver
                .Navigate()
                .GoToUrl($"{this.BaseUrl}{this.PageUrl}?ReturnUrl={destination}");
        }

        public void FillAndLogIn(string email, string password)
        {
            this.Type(this.FieldEmail, email);
            this.Type(this.FieldPassword, password);
            this.ButtonLogIn.Click();
        }
    }
}
