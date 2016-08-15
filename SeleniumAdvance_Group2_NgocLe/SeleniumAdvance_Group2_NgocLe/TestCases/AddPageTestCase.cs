using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumAdvance_Group2.Common;
using System.Threading;
using SeleniumAdvance_Group2.PageObject.Login;
using SeleniumAdvance_Group2.PageObject.General;
using SeleniumAdvance_Group2.PageObject.MainPage;

namespace SeleniumAdvance_Group2.TestCases
{
    [TestClass]
    public class AddPageTestCase : TestBases
    {
        GeneralPage generalPage;
        NewPage newPage;


        [TestMethod]
        public void DA_MP_TC012_Verify_that_user_can_add_additional_pages_besides_Overview_page_successfully()
        {
         
            generalPage = loginPage.LoginSuccessfully(Constant.Respos_SampleRepository, Constant.Username_thi, Constant.Password);
            newPage = generalPage.GotoNewPage();
            generalPage = newPage.CreateNewPage(Constant.statuspublic, Constant.pagename1, Constant.defaultValue, Constant.defaultValue, Constant.defaultValue);
            //vp  
            generalPage.VerifyPageDisplayedBesideAnotherPage(Constant.itemdisplayafter, Constant.pagename1);
            loginPage = generalPage.LogOut();

        }

        [TestMethod]
        public void DA_MP_TC025_Verify_that_page_listing_is_correct_when_edit_Display_After_field()
        {
            EditPage editPage;
           
            generalPage = loginPage.LoginSuccessfully(Constant.Respos_SampleRepository, Constant.Username_thi, Constant.Password);

            //add page1
            newPage = generalPage.GotoNewPage();
            generalPage = newPage.CreateNewPage(Constant.statuspublic, Constant.pagename1, Constant.defaultValue, Constant.defaultValue, Constant.defaultValue);
            //add page2

            Thread.Sleep(500);
            newPage = generalPage.GotoNewPage();
            generalPage = newPage.CreateNewPage(Constant.statuspublic, Constant.pagename2, Constant.defaultValue, Constant.defaultValue, Constant.defaultValue);
            Thread.Sleep(500);
            editPage = generalPage.GotoEditPage(Constant.pagename1);
            generalPage = editPage.EditAPage(Constant.statuspublic, Constant.pagename1, Constant.defaultValue, Constant.itemdisplayafter, Constant.defaultValue);
            //vp
            generalPage.VerifyPageDisplayedBesideAnotherPage(Constant.itemdisplayafter, Constant.pagename1);
            loginPage = generalPage.LogOut();
        }

    }
}
