using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumAdvance_Group2.Common;

namespace SeleniumAdvance_Group2.TestCases
{
    [TestClass]
    public class LoginTestCases : TestBases
    {
       private string validusername = "administrator";
       private string validpass = "";
        private string invalidusername = "abc";
        private string invalidpass = "abc";


        [TestMethod]
        public void DA_LOGIN_TC001_Verify_that_user_can_login_specific_repository_successfully_with_correct_credentials()
        {

            loginPage = OpenURL(Constant.DashboardURL);
            generalPage = loginPage.Login(validusername, validpass);
            //VP
            generalPage.VerifyWelComeUser(validusername);
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

        [TestMethod]

        public void DA_LOGIN_TC003_Verify_that_user_fails_to_login_with_correct_username_and_incorrect_password()
        {
            loginPage = OpenURL(Constant.DashboardURL);
            loginPage.LoginWithInvalidUsernameAndPassword(validusername, invalidpass);
            //vp
            loginPage.VerifyDashboardErrorMessageLogin(Constant.MsgDashboardErrorLogin);
        }
    }
}
