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
        public CreatePostPage(IWebDriver driver) : base(driver)
        {
            this.PageUrl += "/Article/Create";
        }

        public void Fill(string title, string content)
        {
            this.Type(this.FieldTitle, title);
            this.Type(this.FieldContent, content);
        }

        public void FillAndSubmit(string title, string content)
        {
            this.Fill(title,content);
            this.ButtonCreateArticle.Click();
        }
        
        public void FillAndCancel(string title, string content)
        {
            this.Fill(title, content);
            this.ButtonCancel.Click();
        }
    }
}
