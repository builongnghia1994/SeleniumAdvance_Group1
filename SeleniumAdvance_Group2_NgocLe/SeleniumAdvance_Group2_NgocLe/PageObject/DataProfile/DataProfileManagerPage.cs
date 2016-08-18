using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumAdvance_Group2.PageObject.General;
using SeleniumAdvance_Group2.Common;
using System.Threading;

namespace SeleniumAdvance_Group2.PageObject.DataProfile
{
    public class DataProfileManagerPage : GeneralPage
    {
        public DataProfileManagerPage()
        {
            Constant.DataProfileDictionary = ReadXML();
        }

        #region GotoPage methods
        public NewDataProfilePage GotoNewDataProfilePage()
        {
            Thread.Sleep(500);
            ClickControl("add new link");
            return new NewDataProfilePage();
        }

        public EditDataProfilePage GotoEditDataProfilePage(string profile)
        {
            Thread.Sleep(500);
            ClickControl(By.XPath("//td/a[contains(.,'" + profile + "')]"));
            return new EditDataProfilePage();
        }

        #endregion

        public string[] GetActualPreDataPRofile()
        {
            Thread.Sleep(500);
            int numberOfrow = CountItems("data profile table");
            List<string> tableValues = new List<string>();
            for (int i = 2; i < numberOfrow; i++)
            {
                string row = "//table[@class='GridView']//tr[" + i + "]/td[2]";
                tableValues.Add(FindElement(By.XPath(row)).Text);
            }
            return tableValues.ToArray();
        }

        #region Verify methods

        public void VerifyPreDataProfile(string[] expectedValues, string[] actualValues)
        {
            if (expectedValues.Length > actualValues.Length)
            {
                Assert.Fail("The actual results are less than the expected results");
            }
            else
            {
                for (int i = 0; i < expectedValues.Length; i++)
                {
                    Assert.IsTrue(actualValues.Contains(expectedValues[i]), "The '" + expectedValues[i] + "' does not exist in actual results");
                }
            }
        }

        public void VerifyDataProfileInAlphabeticalOrder()
        {
            bool alphabetical = true;
            string errorMessage = string.Empty;
            string[] listPreSetDataProfile = GetActualPreDataPRofile();
            for (int i = 0; i < listPreSetDataProfile.Length - 1; i++)
            {
                if (StringComparer.OrdinalIgnoreCase.Compare(listPreSetDataProfile[i], listPreSetDataProfile[i + 1]) > 0)
                {
                    alphabetical = false;
                    errorMessage = "The '" + listPreSetDataProfile[i] + "' and the '" + listPreSetDataProfile[i + 1] + "' do not display in alphabet";
                    break;
                }
            }
            Assert.IsTrue(alphabetical, errorMessage);
        }
        #endregion
    }
}
