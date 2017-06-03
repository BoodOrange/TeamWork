using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Unit.Tests.Pages.LogInPage
{
    using OpenQA.Selenium;

    public partial class LogInPage
    {
        public IWebElement LinkLogin => this.Driver
            .FindElement(By.Id("loginLink"));

        public IWebElement FieldEmail => this.Driver
            .FindElement(By.Id("Email"));

        public IWebElement FieldPassword => this.Driver
            .FindElement(By.Id("Password"));

        public IWebElement ButtonLogIn => this.Driver
            .FindElement(By.XPath("/html/body/div[2]/div/div/form/div[4]/div/input"));
    }
}
