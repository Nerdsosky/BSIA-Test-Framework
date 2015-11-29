using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using System.IO;

namespace NUnitTestProject1.Pages
{
    public class CreatePage
    {
        private IWebDriver driver;

        public CreatePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Bus Information
        By busDropdown = By.Id("MainContent_ddl_bus");
        By seasonDropdown = By.Id("MainContent_ddl_season");
        By inspectionDateTextbox = By.Id("MainContent_txt_inspectionDate");
        By getBusInfoButton = By.Id("MainContent_btn_getBus");

        //Create Inspection
        By odometerTextbox = By.Id("MainContent_txt_odometer");
        By tagTextbox = By.Id("MainContent_txt_tag");
        By createdByTextbox = By.Id("MainContent_txt_createdBy");
        By upadteByTextbox = By.Id("MainContent_txt_updatedBy");


        public IList<IWebElement> GetGroupInputElements(int groupNumber)
        {
            driver.FindElement(By.PartialLinkText("Group " + groupNumber)).Click();

            IList<IWebElement> inputChildElements = new List<IWebElement>();
            IWebElement group = driver.FindElement(By.Id("div_" + (groupNumber - 1)));
            IList<IWebElement> groupChildElements = group.FindElements(By.XPath(".//*"));

            foreach(IWebElement item in groupChildElements)
            {
                if(item.TagName.Equals("input") || item.TagName.Equals("select")){
                    inputChildElements.Add(item);                   
                 }
             }
            

            return inputChildElements;
        }


        public CreatePage SelectBus(string busNumber)
        {
            SelectElement select = new SelectElement(driver.FindElement(busDropdown));
            select.SelectByText(busNumber);
            return this;
        }

        public CreatePage SelectSeason(string season)
        {
            SelectElement select = new SelectElement(driver.FindElement(seasonDropdown));
            select.SelectByText(season);
            return this;
        }

        public CreatePage ClickGetBusInfo()
        {
            driver.FindElement(getBusInfoButton).Click();
            return this;
        }

    }
}
