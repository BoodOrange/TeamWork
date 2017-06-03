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
    using Pages.ChangePasswordPage;
    using Pages.HomePage;
    using Utility;

    [TestFixture]
    public class UnitTests
    {
        public IWebDriver Driver;


        [SetUp]
        public void initiate()
        {
            this.Driver = BrowserHost.Instance.Application.Browser;
        }

        [Test]
        public void CheckSiteLoad()
        {
            //Arrange
            HomePage home = new HomePage(this.Driver);

            //Act
            home.NavigateTo();

            //Assert
            Assert.AreEqual("SOFTUNI BLOG", home.LinkLogo.Text);
        }

        [Test]
        [Author("Kristin Krastev")]
        public void CreateArticlePageLoad()
        {
            CreatePostPage createArticle = new CreatePostPage(this.Driver);

            BlogTestUtilities.LogInGoTo(createArticle,"TestEmail_01@test.com", "Testpassword_1");
           
            createArticle.AsserterArticlePageLoad("Create Article"); 
         }
        [Test]
        [Author("Kristin Krastev")]
        public void CreateArticleWithoutTitle()
        {
            CreatePostPage createArticle = new CreatePostPage(this.Driver);

            BlogTestUtilities.LogInGoTo(createArticle, "TestEmail_01@test.com", "Testpassword_1");
            createArticle.FillAndSubmit(String.Empty, "Content for TestTitle_01");

            createArticle.AsserterArticleError("The Title field is required.");

        }

        [Test]
        [Author("Kristin Krastev")]
        public void CreateArticleWithoutContent()
        {
            CreatePostPage createArticle = new CreatePostPage(this.Driver);

            BlogTestUtilities.LogInGoTo(createArticle, "TestEmail_01@test.com", "Testpassword_1");
            createArticle.FillAndSubmit("TestTitle_01", String.Empty);

            createArticle.AsserterArticleError("The Content field is required.");
        }

        [Test]
        [Author("Kristin Krastev")]
        public void CreateArticleCancel()
        {
            CreatePostPage createArticle = new CreatePostPage(this.Driver);

            BlogTestUtilities.LogInGoTo(createArticle, "TestEmail_01@test.com", "Testpassword_1");
            createArticle.FillAndCancel("TestTitle_Cancel", "Content for TestTitle_01");

            createArticle.AsserterArticleCancel("TestTitle_Cancel");
        }

        [Test]
        [Author("Kristin Krastev")]
        public void CreateArticleCreate()
        {
            CreatePostPage createArticle = new CreatePostPage(this.Driver);

            BlogTestUtilities.LogInGoTo(createArticle, "TestEmail_01@test.com", "Testpassword_1");
            createArticle.FillAndSubmit("TestTitle_01", "Content for TestTitle_01");

            createArticle.AsserterArticleExist("TestTitle_01");
        }
        [Test]
        public void ChangePassword()
        {

            ChangePasswordPage page = new ChangePasswordPage(this.Driver);

            BlogTestUtilities.LogInGoTo(page, "TestEmail_01@test.com", "Testpassword_1");
            page.FillAndSubmit("Testpassword_1", "Testpassword_2");
            page.LogOff();
            BlogTestUtilities.LogInGoTo(page, "TestEmail_01@test.com", "Testpassword_2");

            var status = this.Driver.Manage().Cookies.GetCookieNamed(".AspNet.ApplicationCookie");

            Assert.NotNull(status);

            //set the password again (not breaking other tests)
            page.NavigateTo();
            page.FillAndSubmit("Testpassword_2", "Testpassword_1");



        }
    }
}
