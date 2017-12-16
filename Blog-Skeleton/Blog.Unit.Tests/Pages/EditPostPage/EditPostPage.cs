namespace Blog.Unit.Tests.Pages.EditPostPage
{
    using OpenQA.Selenium;

    public partial class EditPostPage : BasePage
    {
        public EditPostPage(IWebDriver driver) : base(driver)
        {
            this.PageUrl += "/Article"; // The URL is such in order to work with the BlogTestUtilites Method "LogInGoTo()"
        }

        public void EditTitleAndSubmit(string title)
        {
            this.Type(this.EditFieldTitle, title);
            this.EditArticleButton.Click();
        }
        public void EditContentAndSubmit(string content)
        {
            this.Type(this.EditFieldContent, content);
            this.EditArticleButton.Click();
        }
        public void EditTitleAndContentAndSubmit(string title, string content)
        {
            this.Type(this.EditFieldTitle, title);
            this.Type(this.EditFieldContent, content);
            this.EditArticleButton.Click();
        }
        
        public void EditAndCancel(string title, string content)
        {
            this.Type(this.EditFieldTitle, title);
            this.Type(this.EditFieldContent, content);
            this.CancelButton.Click();
        }

        public void GoToEditArticle (string title)
        {
            for (int i = 0; i < this.ArticlesByTag.Count; i++)
            {
                if (ArticlesByTag[i].Text.Contains(title))
                {
                    this.ArticlesByTag[i].Click();
                    this.EditButton.Click();
                }

            }
        }
        public void CreateArticleToEdit (string title, string content)
        {
      
                
        }
    }
}
