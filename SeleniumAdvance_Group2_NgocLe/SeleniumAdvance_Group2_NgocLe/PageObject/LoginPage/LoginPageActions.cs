﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumAdvance_Group2.Common;
using SeleniumAdvance_Group2.PageObject.LoginPage;
using SeleniumAdvance_Group2.PageObject.GeneralPage;

namespace SeleniumAdvance_Group2.PageObject.LoginPage
{
    public class LoginPageActions : GeneralPageActions
    {
        public GeneralPageActions Login(string respository, string username, string password)
        {
            SelectItemByDropdownList(LoginPageUI.ddlRespository, respository);
            TypeValue(LoginPageUI.txtUserName, username);
            TypeValue(LoginPageUI.txtPassWord, password);
            ClickControl(LoginPageUI.btnLogin);
            return new GeneralPageActions();
        }

        public void LoginWithInvalidUsernameAndPassword(string respository, string username, string password)
        {
            SelectItemByDropdownList(LoginPageUI.ddlRespository, respository);
            TypeValue(LoginPageUI.txtUserName, username);
            TypeValue(LoginPageUI.txtPassWord, password);
            ClickControl(LoginPageUI.btnLogin);
        }

        public void VerifyDashboardErrorMessageLogin(string expectederromessage)
        {
            VerifyText(expectederromessage, GetTextFromAlertPopup());
        }
    }
}
