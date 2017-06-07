using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Blog.Unit.Tests.Models;
using OpenQA.Selenium;

namespace Blog.Unit.Tests.Pages.RegistrationPage
{
    public partial class RegistrationPage : BasePage
    {
        public RegistrationPage(IWebDriver driver) : base(driver)
        {
            this.PageUrl += "/Account/Register";
        }

        

        public void FillRegForm(User user)
        {
            this.Type(this.Email, user.Email);
            this.Type(this.FullName, user.FullName);
            this.Type(this.Password, user.Password);
            this.Type(this.ConfirmPassword, user.Password);
            this.RegisterButtonInForm.Click();
        }

    }
}
