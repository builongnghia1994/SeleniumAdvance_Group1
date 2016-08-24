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
