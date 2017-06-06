namespace Blog.Unit.Tests.Pages.HomePage
{
    using System.Collections.Generic;
    using System.Linq;
    using OpenQA.Selenium;

    public partial class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
            this.PageUrl = "/Article/List";
        }

        public string GetArticleIdByTitle(string title)
        {
            IEnumerable<IWebElement> articleLinks = this.Driver
                .FindElements(By.TagName("a"))
                .Where(x => x.Text == title);

            string articleId = "";

            if (articleLinks.Any())
            {
                articleId = articleLinks.Select(x => x.GetAttribute("href"))
                    .FirstOrDefault()
                    .Split('/')
                    .Last();
            }

            return articleId;
        }
    }
}
