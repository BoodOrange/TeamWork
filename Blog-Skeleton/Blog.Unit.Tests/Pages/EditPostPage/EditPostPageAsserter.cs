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
        public static void AsserterEditArticlePageLoad(this EditPostPage page, string text)
        {
            Assert.AreEqual(text, page.EditArticleHeader.Text);
        }
        public static void AsserterArticleExist(this EditPostPage page, string text)
        {
            for (int i = 0; i < page.Articles.Count; i++)
            {
                if (page.Articles[i].Text.Contains(text))
                {
                    Assert.IsTrue(page.Articles[i].Text.Contains(text));
                    break;//Stops after the first Hit
                }

            }
        }
    }
}
