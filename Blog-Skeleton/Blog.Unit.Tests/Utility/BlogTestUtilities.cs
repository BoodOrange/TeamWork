namespace Blog.Unit.Tests.Utility
{
    using Models;
    using Pages;
    using Pages.LogInPage;


    public static class BlogTestUtilities
    {
        public static void LogInGoTo(BasePage page, User user)
        {
            LogInPage logIn = new LogInPage(page.Driver);
            logIn.NavigateToWithReturnUrl(page.PageUrl);
            logIn.FillAndLogIn(user.Email, user.Password);
        }

    }
}
