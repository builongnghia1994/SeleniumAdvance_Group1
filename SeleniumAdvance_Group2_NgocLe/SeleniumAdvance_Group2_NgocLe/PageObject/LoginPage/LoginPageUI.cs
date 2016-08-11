using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumAdvance_Group2.PageObject.GeneralPage;
using SeleniumAdvance_Group2.Common;


namespace SeleniumAdvance_Group2.PageObject.LoginPage
{
    class LoginPageUI : GeneralPageActions
    {
        public static readonly By ddlRespository = By.Id("repository");
        public static readonly By txtUserName = By.Id("username");
        public static readonly By txtPassWord = By.Id("password");
        public static readonly By btnLogin = By.XPath("//div[@id='content']//div[@class='btn-login']");

        private static IWebElement ddlRespository1, txtUserName1, txtPassWord1, btnLogin1;
        public LoginPageUI()
        {
            Dictionary<string, string>[] iDictionary = ReadXMlFile(Constant.XMLPath + Constant.XMLLoginPage);

            ddlRespository1 = FindElementFromXML("ddlRespository", iDictionary);
            txtUserName1 = FindElementFromXML("txtUserName", iDictionary);
            txtPassWord1 = FindElementFromXML("txtPassWord", iDictionary);
            btnLogin1 = FindElementFromXML("btnLogin", iDictionary);

        }

        public IWebElement DdlRepository
        {
            get { return ddlRespository1; }
        }

        public IWebElement TxtUserName
        {
            get { return txtUserName1; }
        }

        public IWebElement TxtPassWord
        {
            get { return txtPassWord1; }
        }

        public IWebElement BtnLogin
        {
            get { return btnLogin1; }
        }
    }

}
