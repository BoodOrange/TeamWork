namespace Blog.Unit.Tests.Pages.DeletePostPage
{
    using Models;
    using NUnit.Framework;
    using Utility;

    public static class DeletePostPageAsserter
    {
        public static void AssertArticleNotExists(this DeletePostPage page, Article article)
        {
            Assert.IsFalse(
                BlogTestUtilities.CheckArticleExistsByTitle(page, article)
            );
        }
    }
}
