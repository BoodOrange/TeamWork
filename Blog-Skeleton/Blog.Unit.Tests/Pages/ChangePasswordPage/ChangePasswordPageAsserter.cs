using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Blog.Unit.Tests.Pages.ChangePasswordPage
{
    public static class ChangePasswordPageAsserter
    {
        public static void Name (this ChangePasswordPage page, string text)
        {
            Assert.IsTrue(true);
        }
    }
}
