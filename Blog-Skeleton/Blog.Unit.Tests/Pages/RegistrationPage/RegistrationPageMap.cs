using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Blog.Unit.Tests.Pages.RegistrationPage
{
    public partial class RegistrationPage
    {

        public IWebElement RegisterButton => this.Driver.FindElement(By.Id("registerLink"));

        public IWebElement Email => this.Driver.FindElement(By.Id("Email"));

        public IWebElement FullName => this.Driver.FindElement(By.Id("FullName"));

        public IWebElement Password => this.Driver.FindElement(By.Id("Password"));

        public IWebElement ConfirmPassword => this.Driver.FindElement(By.Id("ConfirmPassword"));

        public IWebElement RegisterButtonInForm => this.Driver.FindElement(
            By.XPath("//input[@class='btn btn-default']"));

        public IWebElement RegisteredUserElement => this.Driver.FindElement(By.XPath(".//*[@title='Manage']"));

        public IWebElement WrongUserMaliField => this.Driver.FindElement(
            By.XPath("html/body/div[2]/div/div/form/div[1]/ul/li"));

    }
}
