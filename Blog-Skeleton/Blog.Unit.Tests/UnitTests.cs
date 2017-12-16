namespace Blog.Unit.Tests
{
    using Pages.ChangePasswordPage;
    using Pages.DeletePostPage;
    using Pages.EditPostPage;
    using Pages.HomePage;
    using Utility;
    using Pages.CreatePostPage;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using System;
    using Models;
    using Pages.RegistrationPage;

    [TestFixture]
    public class UnitTests
    {
        public IWebDriver Driver;
        private readonly DataInput _dataInput = new DataInput();


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

            BlogTestUtilities.LogInGoTo(createArticle, _dataInput.TestUser);
           
            createArticle.AsserterArticlePageLoad("Create Article"); 
         }

        [Test]
        [Author("Kristin Krastev")]
        public void CreateArticleWithoutTitle()
        {
            CreatePostPage createArticle = new CreatePostPage(this.Driver);

            BlogTestUtilities.LogInGoTo(createArticle, _dataInput.TestUser);
            createArticle.FillAndSubmit(String.Empty, "Content for TestTitle_01");

            createArticle.AsserterArticleError("The Title field is required.");

        }

        [Test]
        [Author("Kristin Krastev")]
        public void CreateArticleWithoutContent()
        {
            CreatePostPage createArticle = new CreatePostPage(this.Driver);

            BlogTestUtilities.LogInGoTo(createArticle, _dataInput.TestUser);
            createArticle.FillAndSubmit("TestTitle_01", String.Empty);

            createArticle.AsserterArticleError("The Content field is required.");
        }

        [Test]
        [Author("Kristin Krastev")]
        public void CreateArticleCancel()
        {
            CreatePostPage createArticle = new CreatePostPage(this.Driver);

            BlogTestUtilities.LogInGoTo(createArticle, _dataInput.TestUser);
            createArticle.FillAndCancel("TestTitle_Cancel", "Content for TestTitle_01");

            createArticle.AsserterArticleCancel("TestTitle_Cancel");
        }

        [Test]
        [Author("Kristin Krastev")]
        public void CreateArticleCreate()
        {
            CreatePostPage createArticle = new CreatePostPage(this.Driver);

            BlogTestUtilities.LogInGoTo(createArticle, _dataInput.TestUser);
            createArticle.FillAndSubmit("TestTitle_01", "Content for TestTitle_01");

            createArticle.AsserterArticleExist("TestTitle_01");
        }

        [Test]
        [Author("Kristin Krastev")]
        public void EditPageLoad()
        {
            EditPostPage editArticle = new EditPostPage(this.Driver);

            BlogTestUtilities.LogInGoTo(editArticle, _dataInput.TestUser);
            BlogTestUtilities.CreateArticleToEdit(this.Driver, "TestTitle_03", "Content for TestTitle_03");
            editArticle.GoToEditArticle("TestTitle_03");

            editArticle.AsserterEditArticlePageLoad("Edit Article");
        }
        [Test]
        [Author("Kristin Krastev")]
        public void EditPageTitle()
        {
            EditPostPage editArticle = new EditPostPage(this.Driver);

            BlogTestUtilities.LogInGoTo(editArticle, _dataInput.TestUser);
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

            BlogTestUtilities.LogInGoTo(editArticle, _dataInput.TestUser);
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

            BlogTestUtilities.LogInGoTo(editArticle, _dataInput.TestUser);
            BlogTestUtilities.CreateArticleToEdit(this.Driver, "TestTitle_User1", "Content for TestTitle_User1");
            editArticle.LinkLogOff.Click();
            BlogTestUtilities.LogInGoTo(editArticle, _dataInput.TestUser3);
            editArticle.GoToEditArticle("TestTitle_User1");
          

            editArticle.AsserterEditArticleEditWithDifferentUserError("HTTP Error 403.0 - Forbidden");

        }
        [Test]
        [Author("Kristin Krastev")]
        public void EditPageCancel()
        {
            EditPostPage editArticle = new EditPostPage(this.Driver);

            BlogTestUtilities.LogInGoTo(editArticle, _dataInput.TestUser);
            BlogTestUtilities.CreateArticleToEdit(this.Driver, "TestTitle_06", "Content for TestTItele_06");
            editArticle.GoToEditArticle("TestTitle_06");
            editArticle.EditAndCancel("Cancel Title", "Cancel Content");

            editArticle.AsserterEditArticleCancel("Cancel Title");

        }
        [Test]
        [Author("Zlatyo Uzunov")]
        public void ChangePassword()
        {
            //Arrange
            ChangePasswordPage page = new ChangePasswordPage(Driver);
            var user = _dataInput.ChangeUser;

            //Act
            BlogTestUtilities.LogInGoTo(page, user);
            page.FillAndSubmit(user);
            page.LogOff();

            //Assert
            page.AssertLoggedIn(user);
        }




        [Test]
        [Author("Zlatyo Uzunov")]
        public void ChangePasswordWeak()
        {
            //Arrange
            ChangePasswordPage page = new ChangePasswordPage(Driver);
            var user = _dataInput.WeakUser;

            //Act
            BlogTestUtilities.LogInGoTo(page, user);
            page.FillAndSubmit(user);
            page.LogOff();

            //Assert
            page.AssertNotLoggedIn(user);
        }

        [Test]
        [Author("Zlatyo Uzunov")]
        public void ChangePasswordWrong()
        {

            //Arrange
            ChangePasswordPage page = new ChangePasswordPage(this.Driver);
            var user = _dataInput.WrongUser;

            //Act
            BlogTestUtilities.LogInGoTo(page, user);
            page.FillAllAndSubmit(user);
            
            //Assert
            page.AssertNotMatchMessage();
        }

        [Test]
        [Property("Registration Page Tests", 1)]
        [Author("ST")]
        public void RegistrateWithValidUserAndPass()
        {
            RegistrationPage page = new RegistrationPage(this.Driver);
            string userMail = "gogo"+DateTime.Now.Ticks+"@gmail.com";
            User user = new User(_dataInput.TestUser.FullName, userMail , _dataInput.TestUser.Password);

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
            User user = new User(_dataInput.TestUser.FullName, "Gogo" + DateTime.Now.Ticks + "@gmail.com", "");

            page.NavigateTo();
            page.FillRegForm(user);

            page.AssertRegistrationWithoutPass("The Password field is required.");

        }

        [Test]
        [Author("Zlatyo Uzunov")]
        public void DeleteOwnArticle()
        {
            //Arrange
            var user = _dataInput.TestUser;
            var article = _dataInput.TestArticle;
            BlogTestUtilities.CreateArticle(this.Driver, user, article);
            DeletePostPage page = new DeletePostPage(this.Driver, user, article);

            //Act
            page.NavigateTo();
            page.ButtonDelete.Click();

            //Assert
            page.AssertArticleNotExists(article);

            
        }
    }
}
