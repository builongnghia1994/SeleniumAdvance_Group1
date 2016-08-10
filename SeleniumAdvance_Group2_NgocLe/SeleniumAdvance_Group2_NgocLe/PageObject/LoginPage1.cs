using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumAdvance_Group2.Common;
using OpenQA.Selenium;


namespace SeleniumAdvance_Group2.PageObject
{
    public class LoginPage:GeneralPage
    {
        public readonly By ddlRespository = By.Id("repository");
        public readonly By txtUserName = By.Id("username");
        public readonly By txtPassWord = By.Id("password");
        public readonly By btnLogin = By.XPath("//div[@id='content']//div[@class='btn-login']");


        public GeneralPage Login(string respository,string username, string password)
        {
            SelectItemByDropdownList(ddlRespository, respository);
            TypeValue(txtUserName, username);
            TypeValue(txtPassWord, password);
            ClickControl(btnLogin);
            return new GeneralPage();
        }

        public void LoginWithInvalidUsernameAndPassword(string respository,string username, string password)
        {
            SelectItemByDropdownList(ddlRespository, respository);
            TypeValue(txtUserName, username);
            TypeValue(txtPassWord, password);
            ClickControl(btnLogin);
        }

        public void VerifyDashboardErrorMessageLogin(string expectederromessage)
        {
            VerifyText(expectederromessage, GetTextFromAlertPopup());
        }
    }

    
}
