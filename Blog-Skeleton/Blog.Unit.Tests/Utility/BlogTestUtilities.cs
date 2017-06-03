namespace Blog.Unit.Tests.Utility
{
    using Pages;
    using Pages.LogInPage;


    public static class BlogTestUtilities
    {
        public static void LogInGoTo(BasePage page, string email, string password)
        {
            LogInPage logIn = new LogInPage(page.Driver);
            logIn.NavigateToWithReturnUrl(page.PageUrl);
            logIn.FillAndLogIn(email, password);
        }
    }
}
