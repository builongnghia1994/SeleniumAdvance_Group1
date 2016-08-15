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
            IWebElement element = FindElement("item type list");
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

        #endregion
    }
}
