namespace Blog.Unit.Tests.Pages.ChangePasswordPage
{
    using OpenQA.Selenium;

    public partial class ChangePasswordPage : BasePage
    {
        public ChangePasswordPage(IWebDriver driver) : base(driver)
        {
            this.PageUrl += "/Manage/ChangePassword";
        }

        public void Fill(string oldPass, string newPass)
        {
            this.Type(FieldCurrentPassword, oldPass);
            this.Type(this.FieldNewPassword, newPass);
            this.Type(this.FieldConfirmPassword, newPass);
        }

        public void FillAndSubmit(string oldPass, string newPass)
        {
            this.Fill(oldPass,newPass);
            this.ButtonChangePassword.Click();
        }
    }
}
