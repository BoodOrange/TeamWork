using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Blog.Unit.Tests.Pages
{
    public abstract partial class BasePage
    {
        public readonly string BaseUrl;
        public string PageUrl;
        public bool Logged;

        protected BasePage(IWebDriver driver)
        {
            this.Driver = driver;
            this.Wait = new WebDriverWait(this.Driver, TimeSpan.FromSeconds(30));
            this.BaseUrl = "http://localhost:60634";
            this.PageUrl = "";
            this.Logged = false;
        }

        public void NavigateTo()
        {
            Driver.Navigate().GoToUrl(this.BaseUrl + this.PageUrl);
        }

        public void Type(IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }

        public void LogOff()
        {
            this.LinkLogOff.Click();
        }

        public IWebDriver Driver { get; }

        public WebDriverWait Wait { get; }
    }
}
