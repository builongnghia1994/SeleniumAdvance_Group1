using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumAdvance_Group2.Common;
using SeleniumAdvance_Group2.PageObject.LoginPage;
using SeleniumAdvance_Group2.PageObject.GeneralPage;

namespace SeleniumAdvance_Group2.TestCases
{
    [TestClass]
    public class DemoThi : TestBases
    {
        LoginPageActions loginPageActions;
        GeneralPageActions generalPageActions;
        private string username = "thi.nguyen";
        private string pass = "1";
        //private string statuspublic = "public";
        //private string pagename = "Thiaddpage3";

        [TestMethod]

       public void Demo_Thi()
        {
            loginPageActions = new LoginPageActions();
            generalPageActions = loginPageActions.Login(Constant.Respository, username, pass);
            generalPageActions.DeleteAllPages();        
        }
    }
} 
