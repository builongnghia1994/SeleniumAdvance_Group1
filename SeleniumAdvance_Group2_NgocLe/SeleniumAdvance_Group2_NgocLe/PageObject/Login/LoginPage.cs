using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumAdvance_Group2.PageObject.General;
using SeleniumAdvance_Group2.Common;

namespace SeleniumAdvance_Group2.PageObject.Login
{
    public class LoginPage : GeneralPage
    {
        public LoginPage()
        {
            Constant.LoginDictionary = ReadXML();
        }

        public GeneralPage LoginSuccessfully(string respository, string username, string password)
        {
            Login(respository, username, password);
            return new GeneralPage();
        }

        public GeneralPage Login(string respository, string username, string password)
        {
            SelectItemByDropdownList("repository list", respository);
            TypeValue("username textbox", username);
            TypeValue("password textbox", password);
            ClickControl("login button");
            return new GeneralPage();
        }
        public GeneralPage LoginEdge(string respository, string username, string password)
        {
            SelectItemByDropdownList("repository list", respository);
            TypeValue("username textbox", username);
            TypeValue("password textbox", password);
            ClickControl("login button");

            return new GeneralPage();
        }
        //public void Login(string respository, string username, string password)
        //{
        //    SelectItemByDropdownList(LoginPageUI.ddlRespository, respository);
        //    TypeValue(LoginPageUI.txtUserName, username);
        //    TypeValue(LoginPageUI.txtPassWord, password);
        //    ClickControl(LoginPageUI.btnLogin);
        //}

        public void VerifyDashboardErrorMessageLogin(string expectederromessage)
        {
            VerifyText(expectederromessage, GetTextFromAlertPopup());
        }
    }
}

