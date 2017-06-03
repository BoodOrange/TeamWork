namespace Blog.Unit.Tests.Pages.ChangePasswordPage
{
    using OpenQA.Selenium;

    public partial class ChangePasswordPage
    {
        public IWebElement FieldCurrentPassword => this.Driver
            .FindElement(By.Id("OldPassword"));

        public IWebElement FieldNewPassword => this.Driver
            .FindElement(By.Id("NewPassword"));

        public IWebElement FieldConfirmPassword => this.Driver
            .FindElement(By.Id("ConfirmPassword"));

        public IWebElement ButtonChangePassword => this.Driver
            .FindElement(By.XPath("/html/body/div[2]/div/div/form/div[5]/div/input"));

        public IWebElement AlertPasswordsDoNotMatch => this.Driver
            .FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]/ul/li"));
    }
}
