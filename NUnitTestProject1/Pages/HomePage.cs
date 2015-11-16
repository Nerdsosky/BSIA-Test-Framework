﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using NUnitTestProject1.Pages;

namespace NUnitTestProject1.Pages
{
    public class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        By learnMoreCreateInspection = By.CssSelector("[href*='Create.aspx']");
        By learnMoreEditInspection = By.CssSelector("[href*='Edit.aspx']");
        By learnMoreReports = By.CssSelector("[href*='Reports.aspx']");

        public CreatePage ClickLearnMoreCreateReports()
        {
            driver.FindElement(learnMoreCreateInspection).Click();

            return new CreatePage(driver);
        }

        public EditPage ClickLearnMoreEditReports()
        {
            driver.FindElement(learnMoreEditInspection).Click();

            return new EditPage(driver);
        }

        public ReportsPage ClickLearnMoreReports()
        {
            driver.FindElement(learnMoreReports).Click();

            return new ReportsPage(driver);
        }

    }
}
