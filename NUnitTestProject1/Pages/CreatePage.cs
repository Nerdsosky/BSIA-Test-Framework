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
        By notesTextbox = By.Id("MainContent_ta_notes");

        //Acknowledgements
        By inspectionReviewedCheckbox = By.Id("MainContent_cb_agree_inspector");
        By inspectionAgreedCheckbox = By.Id("MainContent_cb_agree_contractor");
        By inspectorSignatureTextbox = By.Id("ctl00$MainContent$txt_sig_inspector");
        By contractorSignatureFirstName = By.Id("ctl00$MainContent$txt_sig_contractor_first");
        By contractorSignatureLastName = By.Id("ctl00$MainContent$txt_sig_contractor_last");
        By submitInspectionButton = By.Id("MainContent_btn_createInspection");


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

        public CreatePage FillOutInspection(int groupNumber)
        {
            IList<IWebElement> inputItems = this.GetGroupInputElements(groupNumber);
            foreach (IWebElement item in inputItems)
            {
                if (item.TagName.Equals("select"))
                {
                    SelectElement select = new SelectElement(item);
                    select.SelectByText("Major");
                }

                switch (item.GetAttribute("type"))
                {
                    case "checkbox":
                        item.Click();
                        break;
                    case "text":
                        item.SendKeys("Testing");
                        break;
                }
            }

            return this;
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

        public CreatePage SignInspectionInspector(String name)
        {
            driver.FindElement(inspectionReviewedCheckbox).Click();
            driver.FindElement(inspectorSignatureTextbox).SendKeys(name);
            return this;
        }

        public CreatePage SignInspectionContractor(String firstName, String lastName)
        {
            driver.FindElement(inspectionAgreedCheckbox).Click();
            driver.FindElement(contractorSignatureFirstName).SendKeys(firstName);
            driver.FindElement(contractorSignatureLastName).SendKeys(lastName);
            return this;
        }

        public CreatePage EnterOdometer(String odometer)
        {
            driver.FindElement(odometerTextbox).SendKeys(odometer);
            return this;
        }

        public CreatePage EnterTag(String tag)
        {
            driver.FindElement(tagTextbox).SendKeys(tag);
            return this;
        }

        public CreatePage EnterCreatedBy(String creator)
        {
            driver.FindElement(createdByTextbox).SendKeys(creator);
            return this;
        }

        public CreatePage EnterNotes(String notes)
        {
            driver.FindElement(notesTextbox).SendKeys(notes);
            return this;
        }

        public CreatePage SubmitInspection()
        {
            driver.FindElement(submitInspectionButton).Click();
            return this;
        }

    }
}
