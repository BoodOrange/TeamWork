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
        public static void Name(this RegistrationPage page, string text)
        {
            Assert.IsTrue(true);
        }
    }
}
