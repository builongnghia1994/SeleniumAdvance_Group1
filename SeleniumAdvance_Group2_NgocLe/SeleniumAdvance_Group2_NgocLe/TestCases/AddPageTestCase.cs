using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumAdvance_Group2.Common;
using System.Threading;
using SeleniumAdvance_Group2.PageObject.LoginPage;
using SeleniumAdvance_Group2.PageObject.GeneralPage;
using SeleniumAdvance_Group2.PageObject.MainPage.NewPage;
using SeleniumAdvance_Group2.PageObject.MainPage.EditPage;

namespace SeleniumAdvance_Group2.TestCases
{
    [TestClass]
    public class AddPageTestCase : TestBases
    {
        LoginPageActions loginPageActions;
        GeneralPageActions generalPageActions;
        NewPageActions newPageActions;

       
        [TestMethod]
        public void DA_MP_TC012_Verify_that_user_can_add_additional_pages_besides_Overview_page_successfully()
        {
            loginPageActions = new LoginPageActions();
            generalPageActions = loginPageActions.LoginSuccessfully(Constant.Respos_SampleRepository, Constant.Username_thi, Constant.Password);
            newPageActions = generalPageActions.GotoNewPage();
            generalPageActions = newPageActions.CreadNewPage(Constant.statuspublic, Constant.pagename1, Constant.defaultValue, Constant.defaultValue, Constant.defaultValue);
            //vp  
            generalPageActions.VerifyPageDisplayedBesideAnotherPage(Constant.itemdisplayafter, Constant.pagename1);            
            loginPageActions = generalPageActions.LogOut();

        }

        [TestMethod]
        public void DA_MP_TC025_Verify_that_page_listing_is_correct_when_edit_Display_After_field()
        {
            EditPageActions editPageActions;

            loginPageActions = new LoginPageActions();
            generalPageActions = loginPageActions.LoginSuccessfully(Constant.Respos_SampleRepository, Constant.Username_thi, Constant.Password);

            //add page1
            newPageActions = generalPageActions.GotoNewPage();
            generalPageActions = newPageActions.CreadNewPage(Constant.statuspublic, Constant.pagename1, Constant.defaultValue, Constant.defaultValue, Constant.defaultValue);
            //add page2

            Thread.Sleep(500);
            newPageActions = generalPageActions.GotoNewPage();
            generalPageActions = newPageActions.CreadNewPage(Constant.statuspublic, Constant.pagename2, Constant.defaultValue, Constant.defaultValue, Constant.defaultValue);
            Thread.Sleep(500);
            editPageActions = generalPageActions.GotoEditPage(Constant.pagename1);
            generalPageActions = editPageActions.EditPage(Constant.statuspublic, Constant.pagename1, Constant.defaultValue, Constant.itemdisplayafter, Constant.defaultValue);
            //vp
            generalPageActions.VerifyPageDisplayedBesideAnotherPage(Constant.itemdisplayafter, Constant.pagename1);
            loginPageActions = generalPageActions.LogOut();
        } 

    }
}
