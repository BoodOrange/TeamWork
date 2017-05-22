using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Unit.Tests.Pages.CreatePostPage
{
    public partial class CreatePostPage
    {
        public IWebElement Create_Title
        {
            get
            {
                return this.Driver.FindElement(By.Id("Title"));
            }
        }

        public IWebElement Create_Content
        {
            get
            {
                return this.Driver.FindElement(By.Id("Content"));
            }
        }
        public IWebElement Create_CancelButton
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[4]/div/a"));
            }
        }

        public IWebElement Create_CreateArticleButton
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[4]/div/input"));
            }
        }
        public IWebElement Create_CreateFromHome_Button
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li[1]/a"));
            }
        }
        public IWebElement Create_CreateArticle_Header
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/h2"));
            }
        }

        public IWebElement Create_logIn
        {
            get
            {
                return this.Driver.FindElement(By.Id("loginLink"));
            }
        }
        public IWebElement Create_logIn_Email
        {
            get
            {
                return this.Driver.FindElement(By.Id("Email"));
            }
        }
        public IWebElement Create_logIn_Password
        {
            get
            {
                return this.Driver.FindElement(By.Id("Password"));
            }
        }
        public IWebElement Create_logIn_LogInButton
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[4]/div/input"));
            }
        }
        public List<IWebElement> Articles
        {
            get
            {
                return this.Driver.FindElements(By.ClassName("col-sm-6")).ToList();
            }
        }
    }
}
