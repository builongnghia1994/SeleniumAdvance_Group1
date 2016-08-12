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

        private string validusername = "thi.nguyen";
        private string validpass = "1";
        private string statuspublic = "public";
        private string pagename1 = "page1" + Constant.timesystem;
        private string pagename2 = "page2" + Constant.timesystem;
        private string specificitemdisplayafter = "Overview";
        private string respository_SampleRepository = "SampleRepository";
        [TestMethod]
        public void DA_MP_TC012_Verify_that_user_can_add_additional_pages_besides_Overview_page_successfully()
        {
            loginPageActions = new LoginPageActions();
            generalPageActions = loginPageActions.Login(respository_SampleRepository, validusername, validpass);
            newPageActions = generalPageActions.GotoNewPage();
            generalPageActions = newPageActions.CreadNewPage(statuspublic, pagename1, Constant.defaultValue, Constant.defaultValue, Constant.defaultValue);
            //vp  
            generalPageActions.VerifyPageDisplayedBesideAnotherPage(specificitemdisplayafter, pagename1);            
            loginPageActions = generalPageActions.LogOut();

        }

        [TestMethod]
        public void DA_MP_TC025_Verify_that_page_listing_is_correct_when_edit_Display_After_field()
        {
            EditPageActions editPageActions;

            loginPageActions = new LoginPageActions();
            generalPageActions = loginPageActions.Login(respository_SampleRepository, validusername, validpass);

            //add page1
            newPageActions = generalPageActions.GotoNewPage();
            generalPageActions = newPageActions.CreadNewPage(statuspublic, pagename1, Constant.defaultValue, Constant.defaultValue, Constant.defaultValue);
            //add page2

            Thread.Sleep(500);
            newPageActions = generalPageActions.GotoNewPage();
            generalPageActions = newPageActions.CreadNewPage(statuspublic, pagename2, Constant.defaultValue, Constant.defaultValue, Constant.defaultValue);
            Thread.Sleep(500);
            editPageActions = generalPageActions.GotoEditPage(pagename1);
            generalPageActions = editPageActions.EditPage(statuspublic, pagename1, Constant.defaultValue, specificitemdisplayafter, Constant.defaultValue);
            //vp
            generalPageActions.VerifyPageDisplayedBesideAnotherPage(specificitemdisplayafter, pagename1);
            loginPageActions = generalPageActions.LogOut();
        } 

    }
}
