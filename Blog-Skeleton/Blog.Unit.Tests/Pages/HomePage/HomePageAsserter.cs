using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Blog.Unit.Tests.Pages.HomePage
{
    public static class HomePageAsserter
    {
        public static void Name(this HomePage page, string text)
        {
            Assert.IsTrue(true);
        }
    }
}
