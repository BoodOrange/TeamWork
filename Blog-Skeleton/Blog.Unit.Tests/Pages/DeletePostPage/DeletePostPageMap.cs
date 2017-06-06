namespace Blog.Unit.Tests.Pages.DeletePostPage
{
    using OpenQA.Selenium;

    public partial class DeletePostPage
    {
        public IWebElement ButtonDelete => this.Driver
            .FindElement(By.XPath("/html/body/div[2]/div/div/form/div[3]/div/input"));

        public IWebElement ButtonCancel => this.Driver
            .FindElement(By.XPath("/html/body/div[2]/div/div/form/div[3]/div/a"));
    }
}
