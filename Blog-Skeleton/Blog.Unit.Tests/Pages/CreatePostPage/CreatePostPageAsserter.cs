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
        public static void AsserterArticleExist(this CreatePostPage page, string text)
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

        public static void AsserterArticleError(this CreatePostPage page, string text)
        {
            //The Title field is required.
            Assert.AreEqual(text, page.CreateArticleError.Text);
        }

        public static void AsserterArticleCancel(this CreatePostPage page, string text)
        {
            for (int i = 0; i < page.Articles.Count; i++)
            {
                if (!page.Articles[i].Text.Contains(text))
                {
                    Assert.IsFalse(page.Articles[i].Text.Contains(text));
                }

            }

        }
        public static void AsserterArticlePageLoad(this CreatePostPage page, string text)
        {
            Assert.AreEqual(text, page.Create_CreateArticle_Header.Text);
        }

    }
}
