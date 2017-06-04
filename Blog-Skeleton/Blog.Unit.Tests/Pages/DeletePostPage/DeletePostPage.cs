namespace Blog.Unit.Tests.Pages.DeletePostPage
{
    using Models;
    using OpenQA.Selenium;
    using Utility;

    public partial class DeletePostPage : BasePage
    {
        public DeletePostPage(IWebDriver driver, User user, string title) : base(driver)
        {
            PageUrl = "/Article";

            BlogTestUtilities.LogInGoTo(this,user);

            this.GoToDeleteArticle(title);

        }

        public void GoToDeleteArticle(string title)
        {
            for (int i = 0; i < this.ArticlesByTag.Count; i++)
            {
                if (ArticlesByTag[i].Text.Contains(title))
                {
                    this.ArticlesByTag[i].Click();
                    this.ButtonDelete.Click();
                }

            }
        }
    }
}
