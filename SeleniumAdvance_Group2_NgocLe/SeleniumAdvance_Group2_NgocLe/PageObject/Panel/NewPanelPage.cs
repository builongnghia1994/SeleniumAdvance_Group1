using OpenQA.Selenium;
using SeleniumAdvance_Group2.Common;
using SeleniumAdvance_Group2.PageObject.General;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SeleniumAdvance_Group2.PageObject.Panel
{
    public class NewPanelPage : GeneralPage
    {

        public NewPanelPage()
        {
            Constant.NewPanelDictionary = ReadXML();
        }

        public void ClickOK()
        {
            ClickControl("ok button");

        }
        public void VerifyTextInAlertPopup(string expectedString)
        {
            VerifyText(expectedString, GetTextFromAlertPopup());
            AcceptAlert();
            ClickControl("cancel button");
        }
    }
}
