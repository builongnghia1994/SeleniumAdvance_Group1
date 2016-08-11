using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumAdvance_Group2.Common;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumAdvance_Group2.PageObject.DataProfilePage.DataProfileManagerPage;
using SeleniumAdvance_Group2.PageObject.GeneralPage;

namespace SeleniumAdvance_Group2.PageObject.DataProfilePage.DataProfileManagerPage
{
    public class DataProfileManagerPageActions : GeneralPageActions
    {
        public string[] GetActualPreDataPRofile()
        {
            List<string> tableValues = new List<string>();
            for (int i = 2; i < CountItems(DataProfileManagerPageUI.tblDataProfile); i++)
            {
                string row = "//table[@class='GridView']//tr[" + i + "]//a[text()='Edit']";
                if (!DoesControlExist(By.XPath(row)))
                {
                    tableValues.Add(FindElement(By.XPath("//table[@class='GridView']//tr[" + i + "]/td[2]")).Text);
                }
            }
            return tableValues.ToArray();
        }

        public void VerifyPreDataProfile(string[] expectedValues, string[] actualValues)
        {
            for (int i = 0; i < actualValues.Length; i++)
            {
                Console.WriteLine(expectedValues[i] + "\n" + actualValues[i]);
                VerifyText(expectedValues[i], actualValues[i]);
            }
        }

        public void VerifyPreDataProfileInAlphabeticalOrder()
        {
            bool alphabetical = true;
            string[] listPreSetDataProfile = GetActualPreDataPRofile();
            for (int i = 0; i < listPreSetDataProfile.Length - 1; i++)
            {
                if (StringComparer.Ordinal.Compare(listPreSetDataProfile[i], listPreSetDataProfile[i + 1]) > 0)
                {
                    alphabetical = false;
                    break;
                }
            }

            Assert.IsTrue(alphabetical);
        }
    }
}
