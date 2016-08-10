﻿using System;
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
       private string respository_SampleRepository = "SampleRepository";
       private string respository_TestRepository = "TestRepository";

        [TestMethod]
        public void DA_LOGIN_TC001_Verify_that_user_can_login_specific_repository_successfully_with_correct_credentials()
        {
            loginPageActions = OpenURL(Constant.DashboardURL);
            generalPage = loginPageActions.Login(respository_SampleRepository,validusername, validpass);
            //VP
            generalPage.VerifyWelComeUserDisplayed(validusername);
            loginPageActions = generalPage.LogOut();
        }

        [TestMethod]
        public void DA_LOGIN_TC002_Verify_that_user_fails_to_login_with_incorrect_credentials()
        {
            loginPageActions = OpenURL(Constant.DashboardURL);
            loginPageActions.LoginWithInvalidUsernameAndPassword(respository_SampleRepository,invalidusername, invalidpass);
            //vp
            loginPageActions.VerifyDashboardErrorMessageLogin(Constant.MsgDashboardErrorLogin);
        }

        [TestMethod]
        public void DA_LOGIN_TC003_Verify_that_user_fails_to_login_with_correct_username_and_incorrect_password()
        {
            loginPageActions = OpenURL(Constant.DashboardURL);
            loginPageActions.LoginWithInvalidUsernameAndPassword(respository_SampleRepository,validusername, invalidpass);
            //vp
            loginPageActions.VerifyDashboardErrorMessageLogin(Constant.MsgDashboardErrorLogin);
        }

        [TestMethod]
        public void DA_LOGIN_TC004_Verify_that_user_login_different_repositories_successfully_after_logging_out_current_repository()
        {
            loginPageActions = OpenURL(Constant.DashboardURL);
            generalPage = loginPageActions.Login(respository_SampleRepository,validusername, validpass);
            loginPageActions = generalPage.LogOut();
            generalPage = loginPageActions.Login(respository_TestRepository, validusername, validpass);
            //VP
            generalPage.VerifyWelComeUserDisplayed(validusername);
            loginPageActions = generalPage.LogOut();
        }
    }
}
