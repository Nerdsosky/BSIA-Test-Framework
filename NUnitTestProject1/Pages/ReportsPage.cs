using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;

namespace NUnitTestProject1.Pages
{
    public class ReportsPage
    {
        private IWebDriver driver;

        public ReportsPage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
