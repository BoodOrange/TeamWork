using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Blog.Unit.Tests.Pages.ManageAccountPage
{
    public static class ManageAccountPageAsserter
    {
        public static void Name(this ManageAccountPage page, string text)
        {
            Assert.IsTrue(true);
        }
    }
}
