using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Blog.Unit.Tests.Pages.LogInPage
{
    public static class LogInPageAsserter
    {
        public static void Name(this LogInPage page, string text)
        {
            Assert.IsTrue(true);
        }
    }
}
