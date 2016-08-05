using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumAdvance_Group2.Common;

namespace SeleniumAdvance_Group2.TestCases
{
    [TestClass]
    public class LoginTestCases : TestBases
    {
        [TestMethod]
        public void DA_LOGIN_TC001_Verify_that_user_can_login_specific_repository_successfully_with_correct_credentials()
        {

            loginPage = OpenURL(Constant.DashboardURL);
            generalPage = loginPage.Login("thi.nguyen", "1");
            //VP
            generalPage.VerifyWelComeUser("thi.nguyen");
            loginPage = generalPage.LogOut();

        }


    }
}
