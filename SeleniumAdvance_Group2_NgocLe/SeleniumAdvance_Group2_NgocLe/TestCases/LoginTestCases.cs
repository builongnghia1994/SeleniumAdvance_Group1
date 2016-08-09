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
        private string invalidusername = "abc";
        private string invalidpass = "abc";


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
        public void DA_LOGIN_TC002_Verify_that_user_fails_to_login_with_incorrect_credentials()
        {
            loginPage = OpenURL(Constant.DashboardURL);
            loginPage.LoginWithInvalidUsernameAndPassword(invalidusername, invalidpass);
            //vp
            loginPage.VerifyDashboardErrorMessageLogin(Constant.MsgDashboardErrorLogin);
        }

    }
}
