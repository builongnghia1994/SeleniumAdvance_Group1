using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumAdvance_Group2.Common;

namespace SeleniumAdvance_Group2.TestCases
{
    [TestClass]
    public class LoginTestCases : TestBases
    {
       private string username = "thi.nguyen";
        private string pass = "1";

        [TestMethod]
        public void DA_LOGIN_TC001_Verify_that_user_can_login_specific_repository_successfully_with_correct_credentials()
        {

            loginPage = OpenURL(Constant.DashboardURL);
            generalPage = loginPage.Login(username, pass);
            //VP
            generalPage.VerifyWelComeUser(username);
            loginPage = generalPage.LogOut();

        }

        [TestMethod]
        public void DA_MP_TC012_Verify_that_user_can_add_additional_pages_besides_Overview_page_successfully()

        {
            loginPage = OpenURL(Constant.DashboardURL);
            generalPage = loginPage.Login(username, pass);
            generalPage.ChoseItemGlobalSetting("addpage");
        }

    }
}
