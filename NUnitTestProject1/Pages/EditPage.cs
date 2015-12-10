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
    public class EditPage
    {
        private IWebDriver driver;

        public EditPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        By busDropdown = By.Id("MainContent_ddl_bus");
        By seasonDropdown = By.Id("MainContent_ddl_season");
        By getBusInfoButton = By.Id("MainContent_btn_getBus");

        By editInspectionButton = By.Id("MainContent_repeater_busInfo_btn_edit_inspection_0");
        By deleteInspectionButton = By.Id("MainContent_repeater_busInfo_btn_delete_inspection_0");
        By updateRepairButton = By.Id("MainContent_btn_repair_update");

        By odometerTextbox = By.Id("MainContent_txt_odometer");
        By tagTextbox = By.Id("MainContent_txt_tag");
        By updatedByTextbox = By.Id("MainContent_txt_updatedBy");
        By notesTextbox = By.Id("MainContent_ta_notes");

        By updateNotes;
        By updateRepairDate;

        public EditPage SelectBus(String busNumber)
        {
            SelectElement busSelect = new SelectElement(driver.FindElement(busDropdown));
            busSelect.SelectByText(busNumber);
            return this;
        }

        public EditPage SeasonSelect(String season)
        {
            SelectElement seasonSelect = new SelectElement(driver.FindElement(seasonDropdown));
            seasonSelect.SelectByText(season);
            return this;
        }

        public EditPage ClickGetBusInfo()
        {
            driver.FindElement(getBusInfoButton).Click();
            return this;
        }

        public EditPage ClickEditButton()
        {
            driver.FindElement(editInspectionButton).Click();
            return this;
        }

        public EditPage ClickDeleteButton()
        {
            driver.FindElement(deleteInspectionButton).Click();
            return this;
        }

        public EditPage ClickUpdateButton()
        {
            driver.FindElement(updateRepairButton).Click();
            return this;
        }

        public EditPage EnterOdometer(String odometer)
        {
            driver.FindElement(odometerTextbox).SendKeys(odometer);
            return this;
        }

        public EditPage EnterTag(String tag)
        {
            driver.FindElement(tagTextbox).SendKeys(tag);
            return this;
        }

        public EditPage EnterUpdatedBy(String name)
        {
            driver.FindElement(updatedByTextbox).SendKeys(name);
            return this;
        }

        public IList<IWebElement> GetGroupInputElements(int groupNumber)
        {
            driver.FindElement(By.PartialLinkText("Group " + groupNumber)).Click();

            IList<IWebElement> inputChildElements = new List<IWebElement>();
            IWebElement group = driver.FindElement(By.Id("div_" + (groupNumber - 1)));
            IList<IWebElement> groupChildElements = group.FindElements(By.XPath(".//*"));

            foreach (IWebElement item in groupChildElements)
            {
                if (item.TagName.Equals("input") || item.TagName.Equals("select"))
                {
                    inputChildElements.Add(item);
                }
            }


            return inputChildElements;
        }

        public EditPage UncheckFailedItem(int groupNumber)
        {
            Boolean uncheckedItem = false;
            IList<IWebElement> inputItems = this.GetGroupInputElements(groupNumber);
            foreach (IWebElement item in inputItems)
            {
                switch (item.GetAttribute("type"))
                {
                    case "checkbox":
                        if (item.GetAttribute("checked") != null) { 
                            item.Click();
                            uncheckedItem = true;
                        }
                        break;
                }

                if (uncheckedItem)
                {
                    break;
                }
            }

            return this;
        }

        public EditPage UpdateRepairItem(String itemNumber, String notes, String repairDate)
        {
            updateNotes = By.Id("MainContent_Repeater_repairs_txt_notes_" + itemNumber);
            driver.FindElement(updateNotes).Clear();
            driver.FindElement(updateNotes).SendKeys(notes);

            updateRepairDate = By.Id("MainContent_Repeater_repairs_txt_repairDate_" + itemNumber);
            driver.FindElement(updateRepairDate).Clear();
            driver.FindElement(updateRepairDate).SendKeys(repairDate);
            driver.FindElement(updateRepairButton).Click();
            return this;
        }

        public EditPage ClickUpdateRepair()
        {
            driver.FindElement(updateRepairButton).Click();
            return this;
        }
    }
}
