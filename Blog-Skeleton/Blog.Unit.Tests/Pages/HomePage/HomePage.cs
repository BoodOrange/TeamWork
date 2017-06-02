using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Blog.Unit.Tests.Pages.HomePage
{
    public partial class HomePage : BasePage
    {
        private string url = "http://localhost:60634/";

        public HomePage(IWebDriver driver) : base(driver)
        {

        }

        public void NavigateTo()
        {
            Driver.Navigate().GoToUrl(this.url);
        }
    }
}
