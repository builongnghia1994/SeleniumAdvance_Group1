using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumAdvance_Group2.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAdvance_Group2.PageObject
{
    public class DataProfilePage: GeneralPage
    {
        private By tblDataProfile = By.XPath("//table[@class='GridView']/tbody/tr");
        #region Methods

        public string[] GetActualPreDataPRofile()
        {
            List<string> tableValues = new List<string>();
            for (int i = 2; i < GetTableRow(tblDataProfile); i++)
            {
                string row ="//table[@class='GridView']//tr["+i+"]//a[text()='Edit']";
                if (!DoesControlExist(By.XPath(row)))
                {
                    tableValues.Add(FindElement(By.XPath("//table[@class='GridView']//tr[" +i+ "]/td[2]")).Text);
                }
            }
            return tableValues.ToArray();
        }

        

        public void VerifyPreDataProfile(string[] expectedValues, string[] actualValues)
        {
            for (int i = 0; i < actualValues.Length; i++)
            {
                Console.WriteLine(expectedValues[i]+"\n"+actualValues[i]);
                Assert.AreEqual(expectedValues[i], actualValues[i]);
            }

        }

        #endregion
    }
}
