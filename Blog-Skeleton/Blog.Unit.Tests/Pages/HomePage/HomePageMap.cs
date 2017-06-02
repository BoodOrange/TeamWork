using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Unit.Tests.Pages.HomePage
{
    using OpenQA.Selenium;


    public partial class HomePage
    {
        public IWebElement Logo => Driver
            .FindElement(
                By.XPath("/html/body/div[1]/div/div[1]/a")
            );
    }
}
