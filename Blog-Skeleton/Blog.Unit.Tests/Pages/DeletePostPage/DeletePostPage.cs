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

            PageUrl += "/Delete/";
            BlogTestUtilities.SetArticleIdByTitle(this,title);

        }
    }
}
