using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Unit.Tests.Pages.CreatePostPage
{
    public partial class CreatePostPage
    {
        public IWebElement FieldTitle => this.Driver.FindElement(By.Id("Title"));

        public IWebElement FieldContent => this.Driver.FindElement(By.Id("Content"));

        public IWebElement ButtonCancel => this.Driver
            .FindElement(By.XPath("/html/body/div[2]/div/div/form/div[4]/div/a"));

        public IWebElement ButtonCreateArticle => this.Driver
            .FindElement(
                By.XPath("/html/body/div[2]/div/div/form/div[4]/div/input")
            );

        public IWebElement Create_CreateFromHome_Button => this.Driver
            .FindElement(
            By.XPath("//*[@id=\"logoutForm\"]/ul/li[1]/a")
            );

        public IWebElement Create_CreateArticle_Header => this.Driver
            .FindElement(
            By.XPath("/html/body/div[2]/div/div/h2")
            );

        public List<IWebElement> Articles => this.Driver
            .FindElements(By.ClassName("col-sm-6"))
            .ToList();
        public IWebElement CreateArticleError => this.Driver
            .FindElement(
                By.XPath("/html/body/div[2]/div/div/form/div[1]/ul/li")
            );
        public IWebElement CreateButtonFromHome => this.Driver
            .FindElement(
                By.XPath("//*[@id=\"logoutForm\"]/ul/li[1]/a")
            );
    }
}
