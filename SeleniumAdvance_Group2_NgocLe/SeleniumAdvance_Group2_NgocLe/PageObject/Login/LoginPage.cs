using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumAdvance_Group2.PageObject.General;
using SeleniumAdvance_Group2.Common;
using System.Threading;

namespace SeleniumAdvance_Group2.PageObject.Login
{
    public class LoginPage : GeneralPage
    {
        public LoginPage()
        {
            Constant.LoginDictionary = ReadXML();
        }

        public GeneralPage LoginDashBoard(string respository, string username, string password)
        {
            Thread.Sleep(500); //sleep to wait login page is loaded to login
            Login(respository, username, password);
            return new GeneralPage();
        }

        public void  Login(string respository, string username, string password)
        {
            SelectItemByDropdownList("repository list", respository);
            TypeValue("username textbox", username);
            TypeValue("password textbox", password);
            ClickControl("login button");
           
        }


        

        public void VerifyDashboardErrorMessageLogin(string expectederromessage)
        {
            VerifyText(expectederromessage, GetTextFromAlertPopup());
            AcceptAlert();
        }
    }
}

