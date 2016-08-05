using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumAdvance_Group2.Common;

namespace SeleniumAdvance_Group2.TestCases
{
    [TestClass]
    public class DemoThi:TestBases
    {

        private string username = "thi.nguyen";
        private string pass = "1";

        private string status = "public";
        private string pagename = "Thiaddpage1";

        [TestMethod]
       
        public void DA_MP_TC012_Verify_that_user_can_add_additional_pages_besides_Overview_page_successfully()

        {
            loginPage = OpenURL(Constant.DashboardURL);
            generalPage = loginPage.Login(username, pass);
            newpage = generalPage.GotoNewPage();
            newpage.CreadNewPage(status, pagename);
        }
    }
}
