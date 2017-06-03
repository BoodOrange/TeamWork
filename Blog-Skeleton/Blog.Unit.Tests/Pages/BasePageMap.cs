namespace Blog.Unit.Tests.Pages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OpenQA.Selenium;


    public partial class BasePage
    {
        public IWebElement LinkLogo => Driver
            .FindElement(
                By.XPath("/html/body/div[1]/div/div[1]/a")
            );

        public IWebElement LinkLogin => Driver
            .FindElement(
                By.Id("loginLink")
            );

        public IWebElement LinkLogOff => Driver
            .FindElement(
                By.LinkText("Log off")
            );

        public IWebElement LinkCreate => Driver
            .FindElement(
                By.LinkText("Create")
            );

        public IWebElement LinkManage => Driver
            .FindElement(
                By.XPath("//*[@title=\"Manage\"]")
            );
    }
}
