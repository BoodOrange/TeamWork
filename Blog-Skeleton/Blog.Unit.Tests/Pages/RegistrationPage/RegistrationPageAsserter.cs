using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Blog.Unit.Tests.Pages.RegistrationPage
{
    public static class RegistrationPageAsserter
    {
        public static void AssertIfRegistrationIsOk(this RegistrationPage page, string text)
        {
            Assert.AreEqual(text, page.RegisteredUserElement.Text);

        }

        public static void AssertIfRegistrationWithWrongMail(this RegistrationPage page, string text)
        {
            Assert.AreEqual(text, page.WrongUserMaliField.Text);

        }

        public static void AssertRegistrationWithoutFullName(this RegistrationPage page, string text)
        {
            Assert.AreEqual(text, page.WrongUserMaliField.Text);

        }

        public static void AssertRegistrationWithoutPass(this RegistrationPage page, string text)
        {
            Assert.AreEqual(text, page.WrongUserMaliField.Text);

        }
    }
}
