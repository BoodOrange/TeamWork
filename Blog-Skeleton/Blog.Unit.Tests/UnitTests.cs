using Blog.Unit.Tests.Pages.CreatePostPage;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Blog.Unit.Tests
{
    [TestFixture]
    public class UnitTests
    {
        public IWebDriver driver;


        [SetUp]
        public void initiate()
        {
            this.driver = BrowserHost.Instance.Application.Browser;
        }
        [Test]
        public void CheckSiteLoad()
        {
            IWebDriver driver = BrowserHost.Instance.Application.Browser;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

            driver.Navigate().GoToUrl("http://localhost:60634/Article/List");

            var logo = wait.Until(w => w.FindElement(By.XPath("/html/body/div[1]/div/div[1]/a")));

            Assert.AreEqual("SOFTUNI BLOG", logo.Text);
        }

        [Test]
        public void CreateArticlePageLoad()
        {
           
            CreatePostPage createArticle = new CreatePostPage(this.driver);

            createArticle.NavigetTo();
            createArticle.Create_logIn.Click();
            createArticle.Create_logIn_Email.SendKeys("TestEmail_01@test.com");
            createArticle.Create_logIn_Password.SendKeys("Testpassword_1");
            createArticle.Create_logIn_LogInButton.Click();
            createArticle.Create_CreateFromHome_Button.Click();
            createArticle.Create_Title.SendKeys("TestTitle_01");
            createArticle.Create_Content.SendKeys("Content for TestTitle_01");
            createArticle.Create_CreateArticleButton.Click();
           
            Assert.AreEqual("TestTitle_01\r\nContent for TestTitle_01\r\n--author", createArticle.Articles[3].Text);
            
         }
    }
}
