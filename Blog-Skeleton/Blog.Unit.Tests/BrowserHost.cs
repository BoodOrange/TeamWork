using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using TestStack.Seleno;
using TestStack.Seleno.Configuration;

namespace Blog.Unit.Tests
{
    public static class BrowserHost
    {
        public static readonly SelenoHost Instance = new SelenoHost();
        public static readonly string RootUrl = @"http://localhost:60634/Article/List"; 
         static BrowserHost()
        {
            Instance.Run("Blog", 60634); // Runing for FireFox
            //Instance.Run("Blog", 60634, w => w.WithRemoteWebDriver(() => new ChromeDriver())); // Runing for chrome 
                                    
        }
    }
}
