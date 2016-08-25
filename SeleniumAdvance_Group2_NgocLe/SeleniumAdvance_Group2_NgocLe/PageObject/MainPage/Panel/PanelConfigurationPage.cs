﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumAdvance_Group2.Common;
using SeleniumAdvance_Group2.PageObject.General;
using SeleniumAdvance_Group2.PageObject.Panel;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Interactions;
using System.Windows.Forms;

namespace SeleniumAdvance_Group2.PageObject.MainPage.Panel
{
    public class PanelConfigurationPage : GeneralPage
    {
        public PanelConfigurationPage()
        {
            if (Constant.PanelConfigurationDictionary == null)
                Constant.PanelConfigurationDictionary = ReadXML();
        }

        public GeneralPage CreatePanelConfiguration(string page, string height, string folder)
        {
            if (page != null)
                SelectItemByDropdownList("page list", page);
            if (height != null)
                TypeValue("height textbox", height);
            if (folder != null)
                TypeValue("folder textbox", folder);
            ClickControl("ok button");
            return new GeneralPage();
        }


        public bool VerifyAllPagesAreListedCorrectlyUnderTheSelectPage(string a, string b, string c)
        {
            ClickControl("page list");


            int numberresult = 0;
            int numberOption = CountItems("option in select page list");
            Console.WriteLine(numberOption);
            List<string> lstCompare = new List<string>();
            lstCompare.Add(a);
            lstCompare.Add(b);
            lstCompare.Add(c);
            int numbercompare = lstCompare.Count;
            Console.WriteLine(numbercompare);

            for (int j = 0; j < numbercompare; j++)
            {
                for (int i = 1; i <= numberOption; i++)
                {
                    string optionSelectPage = "//select[@id='cbbPages']/option[" + i + "]";
                    Console.WriteLine(GetText(By.XPath(optionSelectPage)));

                    if (GetText(By.XPath(optionSelectPage)).Equals(lstCompare[j]))
                    {
                        numberresult++;
                        break;
                    }
                }
            }

            if (numberresult >= 3)
            {
                ClickControl("ok button");
                return true;

            }
            else
            {
                ClickControl("ok button");
                return false;
            }
        }


        public SelectFolderPage GotoSelectFolderPage()
        {
            ClickControl("open folder button");
            return new SelectFolderPage();
        }

        public void VerifySelectedFolder(string expected)
        {
            WaitForPageLoad();
            IWebElement folderElement = FindElementFor49("folder textbox");
            Actions builder = new Actions(Constant.WebDriver);


            builder.DoubleClick(folderElement).Build().Perform();
            folderElement.SendKeys(OpenQA.Selenium.Keys.Control + "a");
            folderElement.SendKeys(OpenQA.Selenium.Keys.Control + "c");
            string actual = Clipboard.GetText();
            actual = actual.Substring(1);
            VerifyText(expected, actual);
        }

    }
}
