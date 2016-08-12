       using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumAdvance_Group2.Common;
using SeleniumAdvance_Group2.PageObject.LoginPage;
using SeleniumAdvance_Group2.PageObject.GeneralPage;

namespace SeleniumAdvance_Group2.PageObject.LoginPage
{
    public class LoginPageActions:GeneralPageActions
    {
        
        public GeneralPageActions LoginSuccessfully(string respository, string username, string password)
        {
            Login(respository, username, password);
            return new GeneralPageActions();
        }

        //public GeneralPageUI Login1(string respository, string username, string password)
        //{
        //    SelectItemByDropdownList(LoginPageUI.ddlRespository1, respository);
        //    TypeValue(LoginPageUI.txtUserName1, username);
        //    TypeValue(LoginPageUI.txtPassWord1, password);
        //    ClickControl(LoginPageUI.btnLogin1);
        //    return new GeneralPageUI();
        //}

        public void Login(string respository, string username, string password)
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

