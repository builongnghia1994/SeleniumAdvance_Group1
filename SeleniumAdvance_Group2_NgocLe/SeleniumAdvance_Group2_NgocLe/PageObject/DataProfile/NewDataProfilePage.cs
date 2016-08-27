using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using SeleniumAdvance_Group2.PageObject.General;
using SeleniumAdvance_Group2.Common;

namespace SeleniumAdvance_Group2.PageObject.DataProfile
{
    public class NewDataProfilePage : GeneralPage
    {
        public NewDataProfilePage()
        {
            if (Constant.NewDataProfileDictionary == null)
                Constant.NewDataProfileDictionary = ReadXML();
        }
        
        #region Verify Methods
     
        public void EnterValueGeneralSetting(string name, string itemType, string relatedData)
        {
            TypeValue("data profile name", name);
            SelectItemByDropdownList("item type list", itemType);
            SelectItemByDropdownList("related data list", relatedData);
        }

        public DataProfileManagerPage AddADataProfile(string name, string itemType, string relatedData)
        {
            EnterValueGeneralSetting(name, itemType, relatedData);
            ClickControl("finish button");
            return new DataProfileManagerPage();
        }

        public void NavigateToSortField(string name, string itemType, string relatedData)
        {
            EnterValueGeneralSetting(name, itemType, relatedData);
            ClickControl("next button");
            WaitForPageLoad();
            ClickControl("next button");
        }

        public void AddASortField(string sortValue)
        {
            SelectItemByDropdownList("field dropdown list in SortFields", sortValue);
            ClickControl("add level button");
        }

        public void MoveLevelOfSortFieldlUp(string field)
        {
            string locator = "//span[text()='" + field + "']/../..//button[@title='Move up']";
            ClickControl(By.XPath(locator));
        }

        public void MoveLevelOfSortFieldDown(string field)
        {
            string locator = "//span[text()='" + field + "']/../..//button[@title='Move down']";
            ClickControl(By.XPath(locator));
        }

        public void VerifyMoveLevel(string expected, string actual)
        {
            Assert.AreEqual(expected, actual);
        }

        public string GetValueSortBy()
        {
            string locator = "//span[text()='Sort by:']//..//span[2]";
            return GetText(By.XPath(locator));
        }

        public string GetValueThenBy()
        {
            string locator = "//span[text()='Then by:']//..//span[2]";
            return GetText(By.XPath(locator));
        }
        #endregion
    }
}
