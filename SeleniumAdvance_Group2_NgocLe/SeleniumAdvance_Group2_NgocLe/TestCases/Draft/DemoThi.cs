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
       

        [TestMethod]

       public void Demo_Thi()
        {
            loginPageActions = new LoginPageActions();
            generalPageActions = loginPageActions.LoginSuccessfully(Constant.Respos_SampleRepository, Constant.Username_thi, Constant.Password);
            generalPageActions.DeleteAllPages();        
        }
    }
} 
