using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Blog.Unit.Tests.Pages
{
    public class BasePage
    {
        public BasePage(IWebDriver driver)
        {
            this.Driver = driver;
            this.Wait = new WebDriverWait(this.Driver, TimeSpan.FromSeconds(30));
        }

        public IWebDriver Driver { get; }

        public WebDriverWait Wait { get; }
    }
}
