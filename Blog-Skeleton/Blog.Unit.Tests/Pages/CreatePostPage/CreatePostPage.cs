using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Blog.Unit.Tests.Pages.CreatePostPage
{
    public partial class CreatePostPage : BasePage
    {
        private string url_Create = "http://localhost:60634/Article/Create";
        public CreatePostPage(IWebDriver driver) : base(driver)
        {
        }

       public void NavigetTo()
        {
            this.Driver.Navigate().GoToUrl(this.url_Create);
        }
        public void LogIn()
        {

        }
        private void Type(IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }
    }
}
