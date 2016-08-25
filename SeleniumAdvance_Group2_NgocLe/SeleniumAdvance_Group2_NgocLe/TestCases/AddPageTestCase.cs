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
         
            generalPage = loginPage.LoginDashBoard(Constant.Respos_SampleRepository, Constant.Username_thi, Constant.Password);

            newPage = generalPage.GotoNewPage();
            
            generalPage = newPage.CreateNewPage(Constant.statusPublic, Constant.pageName, Constant.defaultValue, Constant.defaultValue, Constant.defaultValue,0);
            //vp  
            generalPage.VerifyPageDisplayedBesideAnotherPage(Constant.itemDisplayAfter, Constant.pageName);

            loginPage = generalPage.LogOut();

        }

        [TestMethod]
        public void DA_MP_TC017_user_can_remove_any_main_parent_page_without_children_and_except_Overview_page()
        {

            string parentPage = Constant.timesystem;
            string childPage = Constant.timesystem + "1";
            generalPage = loginPage.LoginDashBoard(Constant.Respos_SampleRepository, Constant.Username_ngoc, Constant.Password);

            newPage = generalPage.GotoNewPage();
            generalPage = newPage.CreateNewPage(Constant.statusPublic, parentPage, Constant.defaultValue, Constant.defaultValue, Constant.defaultValue, 0);

            newPage = generalPage.GotoNewPage();
            generalPage = newPage.CreateNewPage(Constant.statusPublic, childPage, parentPage, Constant.defaultValue, Constant.defaultValue, 0);


            generalPage.DeletePage(Constant.timesystem);
            //vp1
            generalPage.VerifyAlertMessage(Constant.MsgDeletePage);
            generalPage.AcceptAlert();
            //vp2
            generalPage.VerifyAlertMessage("Cannot delete page '" + parentPage + "' since it has child page(s).");
            generalPage.AcceptAlert();

            generalPage.DeletePage(parentPage + "/" + childPage);
            //vp3
            generalPage.VerifyAlertMessage(Constant.MsgDeletePage);
            generalPage.AcceptAlert();
            //vp4
            generalPage.VerifyPageNotExist(parentPage + "/" + childPage);

            generalPage.DeletePage(parentPage);
            //vp5
            generalPage.VerifyAlertMessage(Constant.MsgDeletePage);
            generalPage.AcceptAlert();
            //vp6
            generalPage.VerifyPageNotExist(parentPage);

            generalPage.GotoPage("Overview");

            //vp7
            generalPage.VerifyControlNotExistInGlobalSetting("Delete");

            //post-condition
            generalPage.LogOut();
        }


        [TestMethod]
        public void DA_MP_TC025_Verify_that_page_listing_is_correct_when_edit_Display_After_field()
        {
            EditPage editPage;           
            generalPage = loginPage.LoginDashBoard(Constant.Respos_SampleRepository, Constant.Username_thi, Constant.Password);

            //add page1
            newPage = generalPage.GotoNewPage();
            generalPage = newPage.CreateNewPage(Constant.statusPublic, Constant.pageName1, Constant.defaultValue, Constant.defaultValue, Constant.defaultValue,0);
            //add page2
           
            newPage = generalPage.GotoNewPage();
            generalPage = newPage.CreateNewPage(Constant.statusPublic, Constant.pageName2, Constant.defaultValue, Constant.defaultValue, Constant.defaultValue,0);
           
            editPage = generalPage.GotoEditPage(Constant.pageName1);
            generalPage = editPage.EditAPage(Constant.statusPublic, Constant.pageName1, Constant.defaultValue, Constant.itemDisplayAfter, Constant.defaultValue);
            //vp        
            generalPage.VerifyPageDisplayedBesideAnotherPage(Constant.itemDisplayAfter, Constant.pageName1);
                      
            loginPage = generalPage.LogOut();
        }

    }
}
