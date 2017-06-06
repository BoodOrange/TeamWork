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
        public static void LogoAsserter(this HomePage page, string text)
        {
            Assert.AreEqual(text, page.LinkLogo.Text);
        }
    }
}
