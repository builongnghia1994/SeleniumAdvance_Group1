﻿using OpenQA.Selenium;
using SeleniumAdvance_Group2.Common;
using SeleniumAdvance_Group2.PageObject.General;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace SeleniumAdvance_Group2.PageObject.Panel
{
    public class NewPanelPage : GeneralPage
    {

        public NewPanelPage()
        {
            if (Constant.NewPanelDictionary == null)
                Constant.NewPanelDictionary = ReadXML();
        }

        public void ClickOK()
        {
            
            ClickControl("ok button");

        }
        public void VerifyTextInAlertPopup(string expectedString)
        {
            string alertText = GetTextFromAlertPopup();
            AcceptAlert();
            ClickControl("cancel button");
            VerifyText(expectedString, alertText);
            //dua verify cuoi cung la de truong hop fail van co the close alert va click Cancel-> log out duoc
        }

        public void AddNewPanel(string displayName, string series)
        {
            TypeValue("display name textbox", displayName);
            SelectItemByDropdownList("series list", series);
            ClickControl("ok button");
        }
    }
}
