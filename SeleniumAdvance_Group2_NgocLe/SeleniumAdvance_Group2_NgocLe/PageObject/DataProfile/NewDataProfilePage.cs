using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumAdvance_Group2.PageObject.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumAdvance_Group2.Common;
using System.Threading;

namespace SeleniumAdvance_Group2.PageObject.DataProfile
{
    public class NewDataProfilePage : GeneralPage
    {
        public NewDataProfilePage()
        {
            if (Constant.NewDataProfileDictionary == null)
                Constant.NewDataProfileDictionary = ReadXML();
        }
        public string[] GetItemTypeValues()
        {
            List<string> itemTypeValues = new List<string>();
            IWebElement element = FindElementFromPage("item type list");
            IList<IWebElement> lists = element.FindElements(By.TagName("option"));
            foreach (IWebElement ele in lists)
            {
                itemTypeValues.Add(ele.Text);
            }
            return itemTypeValues.ToArray();
        }

        #region Verify Methods
        public void VerifyDropdownlistDisplayByPriority(string[] expectedValues, string[] actualValues)
        {
            Console.WriteLine(expectedValues.Length + "======" + actualValues.Length);
            if (expectedValues.Length == actualValues.Length)
            {
                for (int i = 0; i < expectedValues.Length; i++)
                {
                    VerifyText(expectedValues[i], actualValues[i]);
                }
            }
            else
            {
                Assert.Fail("Length between actual results and expected results do not match with each other.");
            }
        }

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
