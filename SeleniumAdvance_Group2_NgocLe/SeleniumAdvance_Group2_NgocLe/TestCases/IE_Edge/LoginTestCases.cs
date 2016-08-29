using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumAdvance_Group2.Common;
using SeleniumAdvance_Group2.PageObject.General;

namespace SeleniumAdvance_Group2.TestCases.IE_Edge
{
    [TestClass]
    public class LoginTestCases : TestBases
    {         
        [TestMethod]
        public void IE_Edge_DA_LOGIN_TC004_Verify_that_user_login_different_repositories_successfully_after_logging_out_current_repository()
        {
            GeneralPage generalPage;
          
            generalPage = loginPage.LoginDashBoard(Constant.Respos_SampleRepository, Constant.UsernameAdmin, Constant.PasswordAdmin);
            loginPage = generalPage.LogOut();
            generalPage = loginPage.LoginDashBoard(Constant.Respos_TestRepository, Constant.UsernameAdmin, Constant.PasswordAdmin);
           
            generalPage.VerifyWelComeUserDisplayed(Constant.UsernameAdmin);
            loginPage = generalPage.LogOut();
        }
    }
}