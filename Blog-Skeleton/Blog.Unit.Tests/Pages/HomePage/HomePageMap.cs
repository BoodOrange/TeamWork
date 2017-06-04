namespace Blog.Unit.Tests.Pages.HomePage
{
    using System.Collections.Generic;
    using System.Linq;
    using OpenQA.Selenium;


    public partial class HomePage
    {
        public List<IWebElement> ArticlesByTag => this.Driver
            .FindElements(By.TagName("h2"))
            .ToList();

        public List<IWebElement> ArticlesByLinkText => this.Driver
            .FindElements(By.TagName("h2"))
            .ToList();
    }
}
