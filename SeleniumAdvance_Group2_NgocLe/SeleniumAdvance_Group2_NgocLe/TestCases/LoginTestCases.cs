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
          
            loginpage= OpenURL(Constant.DashboardURL);
            generalpage= loginpage.Login("thi.nguyen","1");
            loginpage = generalpage.Logoutupdage();
            
        }


    }
}
