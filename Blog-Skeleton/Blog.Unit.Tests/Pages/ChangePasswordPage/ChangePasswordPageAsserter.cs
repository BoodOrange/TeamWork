namespace Blog.Unit.Tests.Pages.ChangePasswordPage
{
    using Models;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using Utility;

    public static class ChangePasswordPageAsserter
    {
        private const string MessagePasswordsDoNotMatch = 
            "The new password and confirmation password do not match.";

        public static void AssertLoggedIn(this ChangePasswordPage page, User user)
        {
            var status = LogInGetStatus(page, user);

            Assert.NotNull(status);
        }

        public static void AssertNotLoggedIn(this ChangePasswordPage page, User user)
        {
            var status = LogInGetStatus(page, user);

            Assert.Null(status);
        }

        private static Cookie LogInGetStatus(ChangePasswordPage page, User user)
        {
            BlogTestUtilities.LogInGoTo(page, user);

            var status = page.Driver.Manage().Cookies.GetCookieNamed(".AspNet.ApplicationCookie");

            // if changed set the password again (not breaking other tests)
            if (status != null)
            {
                page.NavigateTo();
                page.FillAndSubmit(user);
            }
            return status;
        }

        public static void AssertNotMatchMessage(this ChangePasswordPage page)
        {
            Assert.AreEqual(MessagePasswordsDoNotMatch, page.AlertPasswordsDoNotMatch.Text);
        }
    }
}
