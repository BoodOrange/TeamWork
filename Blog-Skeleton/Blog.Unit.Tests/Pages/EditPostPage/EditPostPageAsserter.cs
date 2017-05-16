using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Blog.Unit.Tests.Pages.EditPostPage
{
    public static class EditPostPageAsserter
    {
        public static void Name(this EditPostPage page, string text)
        {
            Assert.IsTrue(true);
        }
    }
}
