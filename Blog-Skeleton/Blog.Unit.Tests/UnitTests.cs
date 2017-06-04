using Blog.Unit.Tests.Pages.CreatePostPage;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using Blog.Unit.Tests.Models;


namespace Blog.Unit.Tests
{
    using Pages.ChangePasswordPage;
    using Pages.DeletePostPage;
    using Pages.EditPostPage;
    using Pages.HomePage;
    using Utility;

    [TestFixture]
    public class UnitTests
    {
        public IWebDriver Driver;

        public User TestUser { get; set; } = new User(
            fullname: "Full Name", 
            email: "TestEmail_01@test.com", 
            password: "Testpassword_1", 
            newPassword: "Testpassword_1"
            );

        public User ChangeUser { get; set; } = new User(
            fullname: "Full Name", 
            email: "TestEmail_01@test.com", 
            password: "Testpassword_1", 
            newPassword: "Testpassword_2", 
            confirmPassword: "Testpassword_2"
            );

        public User WrongUser { get; set; } = new User(
            fullname: "Full Name",
            email: "TestEmail_01@test.com",
            password: "Testpassword_1",
            newPassword: "Testpassword_2",
            confirmPassword: "Testpassword_3"
        );

        public User WeakUser { get; set; } = new User(
            fullname: "Full Name",
            email: "TestEmail_01@test.com",
            password: "Testpassword_1",
            newPassword: "1",
            confirmPassword: "1"
        );


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

            BlogTestUtilities.LogInGoTo(createArticle, this.TestUser);
           
            createArticle.AsserterArticlePageLoad("Create Article"); 
         }

        [Test]
        [Author("Kristin Krastev")]
        public void CreateArticleWithoutTitle()
        {
            CreatePostPage createArticle = new CreatePostPage(this.Driver);

            BlogTestUtilities.LogInGoTo(createArticle, this.TestUser);
            createArticle.FillAndSubmit(String.Empty, "Content for TestTitle_01");

            createArticle.AsserterArticleError("The Title field is required.");

        }

        [Test]
        [Author("Kristin Krastev")]
        public void CreateArticleWithoutContent()
        {
            CreatePostPage createArticle = new CreatePostPage(this.Driver);

            BlogTestUtilities.LogInGoTo(createArticle, this.TestUser);
            createArticle.FillAndSubmit("TestTitle_01", String.Empty);

            createArticle.AsserterArticleError("The Content field is required.");
        }

        [Test]
        [Author("Kristin Krastev")]
        public void CreateArticleCancel()
        {
            CreatePostPage createArticle = new CreatePostPage(this.Driver);

            BlogTestUtilities.LogInGoTo(createArticle, this.TestUser);
            createArticle.FillAndCancel("TestTitle_Cancel", "Content for TestTitle_01");

            createArticle.AsserterArticleCancel("TestTitle_Cancel");
        }

        [Test]
        [Author("Kristin Krastev")]
        public void CreateArticleCreate()
        {
            CreatePostPage createArticle = new CreatePostPage(this.Driver);

            BlogTestUtilities.LogInGoTo(createArticle, this.TestUser);
            createArticle.FillAndSubmit("TestTitle_01", "Content for TestTitle_01");

            createArticle.AsserterArticleExist("TestTitle_01");
        }

        [Test]
        [Author("Kristin Krastev")]
        public void EditPageLoad()
        {
            EditPostPage editArticle = new EditPostPage(this.Driver);

            BlogTestUtilities.LogInGoTo(editArticle, this.TestUser);
            editArticle.GoToEditArticle("TestTitle_01");

            editArticle.AsserterEditArticlePageLoad("Edit Article");
            //editArticle.EditContentAndSubmit("New Content for TestTitle_01");

        }
        [Test]
        [Author("Kristin Krastev")]
        public void EditPageTitle()
        {
            EditPostPage editArticle = new EditPostPage(this.Driver);

            BlogTestUtilities.LogInGoTo(editArticle, this.TestUser);
            editArticle.GoToEditArticle("TestTitle_01");
            editArticle.EditTitleAndSubmit("NewTestTitle_01");

            editArticle.AsserterArticleExist("NewTestTitle_01");
        }
        [Test]
        [Author("Kristin Krastev")]
        public void EditPageContent()
        {
            EditPostPage editArticle = new EditPostPage(this.Driver);

            BlogTestUtilities.LogInGoTo(editArticle, TestUser);
            editArticle.GoToEditArticle("TestTitle_01");
            editArticle.EditContentAndSubmit("New Content for TestTitle_01");

            editArticle.AsserterArticleExist("NewTestTitle_01");
        }

        [Test]
        [Author("Zlatyo Uzunov")]
        public void ChangePassword()
        {

            ChangePasswordPage page = new ChangePasswordPage(this.Driver);
            var user = this.ChangeUser;

            BlogTestUtilities.LogInGoTo(page, user);
            page.FillAndSubmitU(user);

            page.LogOff();
            BlogTestUtilities.LogInGoTo(page, user);

            var status = this.Driver.Manage().Cookies.GetCookieNamed(".AspNet.ApplicationCookie");

            // if changed set the password again (not breaking other tests)
            if (status != null)
            {
                page.NavigateTo();
                page.FillAndSubmitU(user);
            }

            Assert.NotNull(status);

        }

        [Test]
        [Author("Zlatyo Uzunov")]
        public void ChangePasswordWeak()
        {

            ChangePasswordPage page = new ChangePasswordPage(this.Driver);

            var user = this.WeakUser;

            // Login with regular user
            BlogTestUtilities.LogInGoTo(page, user);

            // Change password for user
            page.FillAndSubmitU(user);

            page.LogOff();
            BlogTestUtilities.LogInGoTo(page, user);

            var status = this.Driver.Manage().Cookies.GetCookieNamed(".AspNet.ApplicationCookie");

            //if changed set the password again (not breaking other tests)
            if (status != null)
            {
                page.NavigateTo();
                page.FillAndSubmitU(user);
            }

            Assert.Null(status);
        }

        [Test]
        [Author("Zlatyo Uzunov")]
        public void ChangePasswordWrong()
        {

            ChangePasswordPage page = new ChangePasswordPage(this.Driver);

            var user = this.WrongUser;

            BlogTestUtilities.LogInGoTo(page, user);
            page.FillAllAndSubmit(user);
            
            Assert.AreEqual("The new password and confirmation password do not match.",page.AlertPasswordsDoNotMatch.Text);
        }

        [Test]
        [Author("Zlatyo Uzunov")]
        public void DeleteOwnArticle()
        {
            var user = this.TestUser;

            DeletePostPage page = new DeletePostPage(this.Driver, user,"NewTestTitle_01");

            
        }
    }
}
