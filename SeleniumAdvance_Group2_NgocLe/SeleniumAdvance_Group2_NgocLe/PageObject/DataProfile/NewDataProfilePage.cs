using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumAdvance_Group2.PageObject.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumAdvance_Group2.Common;

namespace SeleniumAdvance_Group2.PageObject.DataProfile
{
    public class NewDataProfilePage : GeneralPage
    {
        public NewDataProfilePage()
        {
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

        public DataProfileManagerPage AddADataProfile(string name, string itemType, string relatedData)
        {
            TypeValue("data profile name", name);
            SelectItemByDropdownList("item type list", itemType);
            ClickControl("finish button");
            return new DataProfileManagerPage();
        }


        public void VerifyPageDisplayCorrectlyWithLeftNavigation()
        {
            ClickControl("general setting tab");
            VerifyTextFromControl("General Settings", "header of tab");
            ClickControl("display fields tab");
            VerifyTextFromControl("Display Fields", "header of tab");
            ClickControl("sort fields tab");
            VerifyTextFromControl("Sort Fields", "header of tab");
            ClickControl("filter fields tab");
            VerifyTextFromControl("Filter Fields", "header of tab");
            ClickControl("statistic fields tab");
            VerifyTextFromControl("Statistic Fields", "header of tab");
        }

        #endregion
    }
}
