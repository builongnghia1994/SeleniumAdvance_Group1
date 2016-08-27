using System;
using System.Collections.Generic;
using SeleniumAdvance_Group2.Common;
using SeleniumAdvance_Group2.PageObject.General;
using OpenQA.Selenium;
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

        public bool VerifyCreatedPagePresent(string page1, string page2, string page3)
        {
            ClickControl("page list");

            int numberResult = 0;
            int numberOption = CountItems("option in select page list");

            List<string> lstCompare = new List<string>();
            lstCompare.Add(page1);
            lstCompare.Add(page2);
            lstCompare.Add(page3);
            int numberCompare = lstCompare.Count;
           
            for (int j = 0; j < numberCompare; j++)
            {
                for (int i = 1; i <= numberOption; i++)
                {
                    string optionSelectPage = "//select[@id='cbbPages']/option[" + i + "]";
                   
                    if (GetText(By.XPath(optionSelectPage)).Equals(lstCompare[j]))
                    {
                        numberResult++;
                        break;
                    }
                }
            }

            if (numberResult >= numberCompare)
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

            IWebElement folderElement = FindElementFromPage("folder textbox");

            Actions builder = new Actions(Constant.WebDriver);
            builder.DoubleClick(folderElement).Build().Perform();

            //cannot get property Text of this control so we get Text by using Copy value of this textbox (Ctrl-A, Ctrl-C)
            folderElement.SendKeys(OpenQA.Selenium.Keys.Control + "a");
            folderElement.SendKeys(OpenQA.Selenium.Keys.Control + "c");
            string actual = Clipboard.GetText();

            //cannot click OK button since property Displayed=false, so we use SendKey
            SendKeys.SendWait("{ESC}");

            //remove character '/' at the beginning of folder
            actual = actual.Substring(1);

            VerifyText(expected, actual);
        }
    }
}
