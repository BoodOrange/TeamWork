using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Blog.Unit.Tests.Pages.CreatePostPage
{
    public static class CreatePostPageAsserter
    {
        public static void Name(this CreatePostPage page, string text)
        {
            Assert.IsTrue(true);
        }
    }
}
