using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumAdvance_Group2.PageObject.General;
using SeleniumAdvance_Group2.Common;

namespace SeleniumAdvance_Group2.PageObject.DataProfile
{
    public class DataProfileManagerPage : GeneralPage
    {
        public DataProfileManagerPage()
        {
            if (Constant.DataProfileDictionary == null)
                Constant.DataProfileDictionary = ReadXML();
        }

        #region GotoPage methods
        public NewDataProfilePage GotoNewDataProfilePage()
        {
            if (Constant.Browser.Equals("ie"))
            {
                ClickControlByJS("add new link");
            }else
            {
                ClickControl("add new link");
            }
            return new NewDataProfilePage();
        }

        public EditDataProfilePage GotoEditDataProfilePage(string profile)
        {
            ClickControl(By.XPath("//td/a[contains(.,'" + profile + "')]"));
            return new EditDataProfilePage();
        }

        #endregion

        public string[] GetActualPreDataProfile()
        {
            int numberOfrow = CountItems("data profile table");
            List<string> tableValues = new List<string>();
            string row = string.Empty;

            for (int i = 2; i <= numberOfrow; i++)
            {
                row = "//table[@class='GridView']//tr[" + i + "]/td[2]";
                if (DoesControlExist(By.XPath(row)))
                {
                    tableValues.Add(FindElement(By.XPath(row)).Text);
                }
            }
            return tableValues.ToArray();
        }

        public void DeleteAllDataProfile()
        {
            if (DoesControlExist("check all checkbox"))
            {
                ClickControl("check all checkbox");
                ClickControl("delete link");
                AcceptAlert();
            }
        }

        #region Verify methods

        public void VerifyPreDataProfile(string[] expectedValues, string[] actualValues)
        {
            string errorMsg = string.Empty;
            bool contain = false;
            if (expectedValues.Length > actualValues.Length)
            {
                Assert.Fail("The actual results are less than the expected results");
            }
            else
            {
                for (int i = 0; i < expectedValues.Length; i++)
                {
                    contain = actualValues.Contains(expectedValues[i]);
                    if(contain == false)
                    {
                        errorMsg = "The '" + expectedValues[i] + "' does not exist in actual results";
                        break;
                    }
                }
                Assert.IsTrue(contain, errorMsg);
            }
        }

        public void VerifyDataProfileInAlphabeticalOrder()
        {
            bool alphabetical = true;
            string errorMessage = string.Empty;
            string[] listPreSetDataProfile = GetActualPreDataProfile();
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

        public void DeleteCreatedDataProfile(string nameOfDataProfile)
        {
            string createdPageXpath = "//td[contains(.,'"+ nameOfDataProfile + "')]/../td/a[text()='Delete']";
            ClickControl(By.XPath(createdPageXpath));
            AcceptAlert();
        }

        #endregion
    }
}
