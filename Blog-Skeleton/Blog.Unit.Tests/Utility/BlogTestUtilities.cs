namespace Blog.Unit.Tests.Utility
{
    using Models;
    using OpenQA.Selenium;
    using Pages;
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

        public static bool CheckArticleExistsByTitle(BasePage page, string title)
        {
            var homepage = new HomePage(page.Driver);

            string id = homepage.GetArticleIdByTitle(title);

            return id != "";
        }
    }
}
