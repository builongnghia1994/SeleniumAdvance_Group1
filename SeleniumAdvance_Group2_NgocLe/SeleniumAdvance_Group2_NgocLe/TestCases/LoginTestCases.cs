using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumAdvance_Group2.Common;
using SeleniumAdvance_Group2.PageObject.Login;
using SeleniumAdvance_Group2.PageObject.General;

namespace SeleniumAdvance_Group2.TestCases
{
    [TestClass]
    public class LoginTestCases : TestBases
    {
        LoginPage loginPage;
              

        [TestMethod]
        public void DA_LOGIN_TC001_Verify_that_user_can_login_specific_repository_successfully_with_correct_credentials()
        {
            GeneralPage generalPage;
            loginPage = new LoginPage();

            generalPage = loginPage.LoginSuccessfully(Constant.Respos_SampleRepository, Constant.Username_thi, Constant.Password);
            //VP
            generalPage.VerifyWelComeUserDisplayed(Constant.Username_thi);
            loginPage = generalPage.LogOut();
        }

        [TestMethod]
        public void DA_LOGIN_TC002_Verify_that_user_fails_to_login_with_incorrect_credentials()
        {
            loginPage = new LoginPage();
            loginPage.Login(Constant.Respos_SampleRepository, "abc", "abc");
            //vp
            loginPage.VerifyDashboardErrorMessageLogin(Constant.MsgDashboardErrorLogin);
        }

        [TestMethod]
        public void DA_LOGIN_TC003_Verify_that_user_fails_to_login_with_correct_username_and_incorrect_password()
        {
            loginPage = new LoginPage();
            loginPage.Login(Constant.Respos_SampleRepository,Constant.Username_thi, "abc");
            //vp
            loginPage.VerifyDashboardErrorMessageLogin(Constant.MsgDashboardErrorLogin);
        }

        [TestMethod]
        public void DA_LOGIN_TC004_Verify_that_user_login_different_repositories_successfully_after_logging_out_current_repository()
        {
            GeneralPage generalPage;

            loginPage = new LoginPage();
            generalPage = loginPage.LoginSuccessfully(Constant.Respos_SampleRepository, Constant.Username_thi, Constant.Password);
            loginPage = generalPage.LogOut();
            generalPage = loginPage.LoginSuccessfully(Constant.Respos_TestRepository, Constant.Username_thi, Constant.Password);
            //VP
            generalPage.VerifyWelComeUserDisplayed(Constant.Username_thi);
            loginPage = generalPage.LogOut();
        }
    }
}
