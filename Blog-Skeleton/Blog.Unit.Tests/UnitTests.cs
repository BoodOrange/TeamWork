using Blog.Unit.Tests.Pages.CreatePostPage;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using Blog.Unit.Tests.Models;
using Blog.Unit.Tests.Pages.RegistrationPage;


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
        public User TestUser2 { get; set; } = new User(
            fullname: "Full Name",
            email: "TestEmail_02@test.com",
            password: "Testpassword_2",
            newPassword: "Testpassword_2"
            );
        public User TestUser3 { get; set; } = new User(
            fullname: "Full Name",
            email: "TestEmail_03@test.com",
            password: "Testpassword_3",
            newPassword: "Testpassword_3"
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

        public Article TestArticle { get; set; } = new Article(
            title: "Lorem ipsum dolor sit",
            content: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi ac pretium velit. Morbi laoreet mauris ac est congue, quis iaculis."
            );


        [SetUp]
        public void initiate()
        {
            this.Driver = BrowserHost.Instance.Application.Browser;
        }

        [Test]
        [Author("ST")]
        public void CheckSiteLoad()
        
        {
            //Arrange
            HomePage home = new HomePage(this.Driver);

            //Act
            home.NavigateTo();

            //Assert
            home.LogoAsserter("SOFTUNI BLOG");
            
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
            BlogTestUtilities.CreateArticleToEdit(this.Driver, "TestTitle_03", "Content for TestTitle_03");
            editArticle.GoToEditArticle("TestTitle_03");

            editArticle.AsserterEditArticlePageLoad("Edit Article");
        }
        [Test]
        [Author("Kristin Krastev")]
        public void EditPageTitle()
        {
            EditPostPage editArticle = new EditPostPage(this.Driver);

            BlogTestUtilities.LogInGoTo(editArticle, this.TestUser);
            BlogTestUtilities.CreateArticleToEdit(this.Driver, "TestTitle_04", "Content for TestTItele_04");
            editArticle.GoToEditArticle("TestTitle_04");
            editArticle.EditTitleAndSubmit("NewTestTitle_04");

            editArticle.AsserterArticleExist("NewTestTitle_04");
        }
        [Test]
        [Author("Kristin Krastev")]
        public void EditPageContent()
        {
            EditPostPage editArticle = new EditPostPage(this.Driver);

            BlogTestUtilities.LogInGoTo(editArticle, TestUser);
            BlogTestUtilities.CreateArticleToEdit(this.Driver, "TestTitle_05", "Content for TestTItele_05");
            editArticle.GoToEditArticle("TestTitle_05");
            editArticle.EditContentAndSubmit("New Content for TestTitle_05");

            editArticle.AsserterArticleExist("NewTestTitle_05");
        }
        [Test]
        [Author("Kristin Krastev")]
        public void EditPageWithDifferentUser()
        {
            EditPostPage editArticle = new EditPostPage(this.Driver);

            BlogTestUtilities.LogInGoTo(editArticle, TestUser);
            BlogTestUtilities.CreateArticleToEdit(this.Driver, "TestTitle_User1", "Content for TestTitle_User1");
            editArticle.LinkLogOff.Click();
            BlogTestUtilities.LogInGoTo(editArticle, TestUser3);
            editArticle.GoToEditArticle("TestTitle_User1");
          

            editArticle.AsserterEditArticleEditWithDifferentUserError("HTTP Error 403.0 - Forbidden");

        }
        [Test]
        [Author("Kristin Krastev")]
        public void EditPageCancel()
        {
            EditPostPage editArticle = new EditPostPage(this.Driver);

            BlogTestUtilities.LogInGoTo(editArticle, TestUser);
            BlogTestUtilities.CreateArticleToEdit(this.Driver, "TestTitle_06", "Content for TestTItele_06");
            editArticle.GoToEditArticle("TestTitle_06");
            editArticle.EditAndCancel("Cancel Title", "Cancel Content");

            editArticle.AsserterEditArticleCancel("Cancel Title");

        }
        [Test]
        [Author("Zlatyo Uzunov")]
        public void ChangePassword()
        {

            ChangePasswordPage page = new ChangePasswordPage(this.Driver);
            var user = this.ChangeUser;

            BlogTestUtilities.LogInGoTo(page, user);
            page.FillAndSubmit(user);

            page.LogOff();
            BlogTestUtilities.LogInGoTo(page, user);

            var status = this.Driver.Manage().Cookies.GetCookieNamed(".AspNet.ApplicationCookie");

            // if changed set the password again (not breaking other tests)
            if (status != null)
            {
                page.NavigateTo();
                page.FillAndSubmit(user);
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
            page.FillAndSubmit(user);

            page.LogOff();
            BlogTestUtilities.LogInGoTo(page, user);

            var status = this.Driver.Manage().Cookies.GetCookieNamed(".AspNet.ApplicationCookie");

            //if changed set the password again (not breaking other tests)
            if (status != null)
            {
                page.NavigateTo();
                page.FillAndSubmit(user);
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
        [Property("Registration Page Tests", 1)]
        [Author("ST")]
        public void RegistrateWithValidUserAndPass()
        {
            RegistrationPage page = new RegistrationPage(this.Driver);
            string userMail = "gogo"+DateTime.Now.Ticks+"@gmail.com";
            User user = new User(this.TestUser.FullName, userMail , this.TestUser.Password);

            page.NavigateTo();
            page.FillRegForm(user);

            page.AssertIfRegistrationIsOk("Hello " + userMail + "!");
            
        }

        [Test]
        [Property("Registration Page Tests", 1)]
        [Author("ST")]
        public void RegistrateWithInvalidUserMail()
        {
            RegistrationPage page = new RegistrationPage(this.Driver);
            User user = new User("Test User", "Gogo@gmail", "123456");

            page.NavigateTo();
            page.FillRegForm(user);

            page.AssertIfRegistrationWithWrongMail("The Email field is not a valid e-mail address.");

        }

        [Test]
        [Property("Registration Page Tests", 1)]
        [Author("ST")]
        public void RegistrateWithoutFullName()
        {
            RegistrationPage page = new RegistrationPage(this.Driver);
            User user = new User("", "Gogo" + DateTime.Now.Ticks + "@gmail.com", "123456");

            page.NavigateTo();
            page.FillRegForm(user);

            page.AssertRegistrationWithoutFullName("The Full Name field is required.");

        }

        [Test]
        [Property("Registration Page Tests", 1)]
        [Author("ST")]
        public void RegistrateWithoutPassword()
        {
            RegistrationPage page = new RegistrationPage(this.Driver);
            User user = new User(TestUser.FullName, "Gogo" + DateTime.Now.Ticks + "@gmail.com", "");

            page.NavigateTo();
            page.FillRegForm(user);

            page.AssertRegistrationWithoutPass("The Password field is required.");

        }

        [Test]
        [Author("Zlatyo Uzunov")]
        public void DeleteOwnArticle()
        {
            var user = this.TestUser;
            var article = this.TestArticle;

            BlogTestUtilities.CreateArticle(this.Driver, user, article);

            DeletePostPage page = new DeletePostPage(this.Driver, user, article);
            page.NavigateTo();
            page.ButtonDelete.Click();

            Assert.IsFalse(
                BlogTestUtilities.CheckArticleExistsByTitle(page, article)
                );

            
        }
    }
}
