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
        public void CreateArticlePageLoad()
        {
           
            CreatePostPage createArticle = new CreatePostPage(this.Driver);

            BlogTestUtilities.LogInGoTo(createArticle,"TestEmail_01@test.com", "Testpassword_1");
            createArticle.FillAndSubmit("TestTitle_01", "Content for TestTitle_01");
           
            Assert.AreEqual("TestTitle_01\r\nContent for TestTitle_01\r\n--author", createArticle.Articles.Last().Text);
            
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

            // if changed set the password again (not breaking other tests)
            if (status != null)
            {
                page.NavigateTo();
                page.FillAndSubmit("Testpassword_2", "Testpassword_1");
            }

            Assert.NotNull(status);

        }

        [Test]
        public void ChangePasswordWeak()
        {

            ChangePasswordPage page = new ChangePasswordPage(this.Driver);

            BlogTestUtilities.LogInGoTo(page, "TestEmail_01@test.com", "Testpassword_1");
            page.FillAndSubmit("Testpassword_1", "1");
            page.LogOff();
            BlogTestUtilities.LogInGoTo(page, "TestEmail_01@test.com", "1");

            var status = this.Driver.Manage().Cookies.GetCookieNamed(".AspNet.ApplicationCookie");

            //if changed set the password again (not breaking other tests)
            if (status != null)
            {
                page.NavigateTo();
                page.FillAndSubmit("1", "Testpassword_1");
            }

            Assert.Null(status);

        }
    }
}
