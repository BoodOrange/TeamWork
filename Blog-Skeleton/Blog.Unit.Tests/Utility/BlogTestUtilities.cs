namespace Blog.Unit.Tests.Utility
{
    using Models;
    using OpenQA.Selenium;
    using Pages;
    using Pages.CreatePostPage;
    using Pages.DeletePostPage;
    using Pages.HomePage;
    using Pages.LogInPage;


    public static class BlogTestUtilities
    {
        public static void LogInGoTo(BasePage page, User user)
        {
            LogInPage logIn = new LogInPage(page.Driver);
            logIn.NavigateToWithReturnUrl(page.PageUrl);
            logIn.FillAndLogIn(user.Email, user.Password);
        }

        public static void SetArticleIdByTitle(BasePage page, string title)
        {
            var homepage = new HomePage(page.Driver);

            string id = homepage.GetArticleIdByTitle(title);

            page.PageUrl += id;
        }

        public static bool CheckArticleExistsByTitle(BasePage page, Article article)
        {
            var homepage = new HomePage(page.Driver);

            string id = homepage.GetArticleIdByTitle(article.Title);

            return id != "";
        }

        public static void CreateArticle(IWebDriver driver, User user, Article article)
        {
            var createPage = new CreatePostPage(driver);

            LogInGoTo(createPage, user);
            createPage.FillAndSubmit(article.Title,article.Content);
        }
        public static void CreateArticleToEdit(IWebDriver driver, string title, string content)
        {
            var createPage = new CreatePostPage(driver);

            //*[@id="logoutForm"]/ul/li[1]/a
            createPage.CreateButtonFromHome.Click();
            createPage.FillAndSubmit(title, content);
        }
    }
}
