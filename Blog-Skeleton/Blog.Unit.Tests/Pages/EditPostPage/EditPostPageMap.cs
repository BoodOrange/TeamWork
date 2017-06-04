using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Unit.Tests.Pages.EditPostPage
{
    public partial class EditPostPage
    {
        public IWebElement EditFieldTitle => this.Driver.FindElement(By.Id("Title"));

        public IWebElement EditFieldContent => this.Driver.FindElement(By.Id("Content"));

        public List<IWebElement> Articles => this.Driver
            .FindElements(By.ClassName("col-sm-6"))
            .ToList();

        public IWebElement EditButton => this.Driver.FindElement(By.XPath("/html/body/div[2]/div/article/footer/a[1]"));


        public IWebElement CancelButton => this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[4]/div/a"));

        public IWebElement ArticleEditButton => this.Driver.FindElement(By.XPath("/html/body/div[2]/div/article/footer/a[1]"));

        public List<IWebElement> ArticlesByTag => this.Driver
            .FindElements(By.TagName("h2"))
            .ToList();
        public IWebElement EditArticleHeader => this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/h2"));

        public IWebElement EditArticleButton => this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[4]/div/input"));
    }
}
