using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumAdvance_Group2.Common;
using SeleniumAdvance_Group2.PageObject.LoginPage;
using SeleniumAdvance_Group2.PageObject.GeneralPage;

namespace SeleniumAdvance_Group2.TestCases
{
    [TestClass]
    public class LoginTestCases : TestBases
    {
        LoginPageActions loginPageActions;
              

        [TestMethod]
        public void DA_LOGIN_TC001_Verify_that_user_can_login_specific_repository_successfully_with_correct_credentials()
        {
            GeneralPageActions generalPageActions;
            loginPageActions = new LoginPageActions();

            generalPageActions = loginPageActions.LoginSuccessfully(Constant.Respos_SampleRepository, Constant.Username_thi, Constant.Password);
            //VP
            generalPageActions.VerifyWelComeUserDisplayed(Constant.Username_thi);
            loginPageActions = generalPageActions.LogOut();
        }

        [TestMethod]
        public void DA_LOGIN_TC002_Verify_that_user_fails_to_login_with_incorrect_credentials()
        {
            loginPageActions = new LoginPageActions();
            loginPageActions.Login(Constant.Respos_SampleRepository, "abc", "abc");
            //vp
            loginPageActions.VerifyDashboardErrorMessageLogin(Constant.MsgDashboardErrorLogin);
        }

        [TestMethod]
        public void DA_LOGIN_TC003_Verify_that_user_fails_to_login_with_correct_username_and_incorrect_password()
        {
            loginPageActions = new LoginPageActions();
            loginPageActions.Login(Constant.Respos_SampleRepository,Constant.Username_thi, "abc");
            //vp
            loginPageActions.VerifyDashboardErrorMessageLogin(Constant.MsgDashboardErrorLogin);
        }

        [TestMethod]
        public void DA_LOGIN_TC004_Verify_that_user_login_different_repositories_successfully_after_logging_out_current_repository()
        {
            GeneralPageActions generalPageActions;

            loginPageActions = new LoginPageActions();
            generalPageActions = loginPageActions.LoginSuccessfully(Constant.Respos_SampleRepository, Constant.Username_thi, Constant.Password);
            loginPageActions = generalPageActions.LogOut();
            generalPageActions = loginPageActions.LoginSuccessfully(Constant.Respos_TestRepository, Constant.Username_thi, Constant.Password);
            //VP
            generalPageActions.VerifyWelComeUserDisplayed(Constant.Username_thi);
            loginPageActions = generalPageActions.LogOut();
        }
    }
}
