namespace Blog.Unit.Tests.Pages.ChangePasswordPage
{
    using Models;
    using OpenQA.Selenium;

    public partial class ChangePasswordPage : BasePage
    {
        public ChangePasswordPage(IWebDriver driver) : base(driver)
        {
            this.PageUrl += "/Manage/ChangePassword";
        }

        public void Fill(string oldPass, string newPass, string confirmPass)
        {
            this.Type(FieldCurrentPassword, oldPass);
            this.Type(this.FieldNewPassword, newPass);
            this.Type(this.FieldConfirmPassword, confirmPass);
        }

        public void FillAndSubmitU(User user)
        {
            this.Fill(user.Password, user.PasswordNew, user.PasswordConfirm);
            this.ButtonChangePassword.Click();
            user.SwitchPasswords();
        }

        public void FillAllAndSubmit(User user)
        {
            this.Fill(user.Password, user.PasswordNew, user.PasswordConfirm);
            this.ButtonChangePassword.Click();
        }
    }
}
