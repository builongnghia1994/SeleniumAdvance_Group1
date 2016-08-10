using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumAdvance_Group2.Common;

namespace SeleniumAdvance_Group2.TestCases
{
    [TestClass]
    public class AddPageTestCase:TestBases
    {
        private string validusername = "thi.nguyen";
        private string validpass = "1";       
        private string statuspublic = "public";
        private string pagename = "test"+ Constant.timesystem;
        private string specificitemdisplayafter = "Overview";
        private string respository_SampleRepository = "SampleRepository";
        [TestMethod]
        public void DA_MP_TC012_Verify_that_user_can_add_additional_pages_besides_Overview_page_successfully()
        {
            loginPageActions = OpenURL(Constant.DashboardURL);
            generalPage = loginPageActions.Login(respository_SampleRepository,validusername, validpass);
            newpage = generalPage.GotoNewPage();     
            newpage.CreadNewPage(statuspublic, pagename, Constant.defaultValue, Constant.defaultValue, Constant.defaultValue);
            //vp
            newpage.VerifyNameOfNewPageDisplayedBesidesSpecificItemDisplayAfter(specificitemdisplayafter, pagename);
        }

       
    }
}
