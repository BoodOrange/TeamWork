using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Unit.Tests.Pages.ManageAccountPage
{
    using OpenQA.Selenium;

    public partial class ManageAccountPage
    {
        public IWebElement LinkChangePassword => Driver
            .FindElement(
                By.LinkText("Change your password")
            );
    }
}
