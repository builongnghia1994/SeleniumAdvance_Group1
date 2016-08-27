using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumAdvance_Group2.Common;
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

            generalPage = newPage.CreateNewPage(Constant.DefaultValue, Constant.TimeSystem, Constant.DefaultValue, Constant.DefaultValue, Constant.DefaultValue, Constant.DefaultValue);
           
            generalPage.VerifyPageDisplayedBesideAnotherPage(Constant.Overview, Constant.TimeSystem);

            //post-condition
            generalPage.DeletePage(Constant.PageName);
            generalPage.LogOut();
        }

        [TestMethod]
        public void DA_MP_TC014_Verify_that_Public_pages_can_be_visible_and_accessed_by_all_users()
        {
            generalPage = loginPage.LoginDashBoard(Constant.Respos_SampleRepository, Constant.Username_ngoc, Constant.Password);

            newPage = generalPage.GotoNewPage();
            generalPage = newPage.CreateNewPage(Constant.StatusPublic, Constant.TimeSystem, Constant.DefaultValue, Constant.DefaultValue, Constant.DefaultValue, Constant.DefaultValue);

            loginPage = generalPage.LogOut();
            generalPage = loginPage.LoginDashBoard(Constant.Respos_SampleRepository, Constant.Username_thi, Constant.Password);

            generalPage.VerifyPageNameDisplay(Constant.TimeSystem);

            //post-condition: Log in  as creator page account and delete newly added page
            loginPage = generalPage.LogOut();
            generalPage = loginPage.LoginDashBoard(Constant.Respos_SampleRepository, Constant.Username_ngoc, Constant.Password);
            generalPage.DeletePage(Constant.TimeSystem);
            generalPage.LogOut();
        }

        [TestMethod]
        public void DA_MP_TC017_Verify_that_user_can_remove_any_main_parent_page_without_children_and_except_Overview_page()
        {
            string parentPage = Constant.TimeSystem;
            string childPage = Constant.TimeSystem + "1";

            generalPage = loginPage.LoginDashBoard(Constant.Respos_SampleRepository, Constant.Username_ngoc, Constant.Password);

            newPage = generalPage.GotoNewPage();
            generalPage = newPage.CreateNewPage(Constant.StatusPublic, parentPage, Constant.DefaultValue, Constant.DefaultValue, Constant.DefaultValue, Constant.DefaultValue);

            newPage = generalPage.GotoNewPage();
            generalPage = newPage.CreateNewPage(Constant.StatusPublic, childPage, parentPage, Constant.DefaultValue, Constant.DefaultValue, Constant.DefaultValue);


            generalPage.SelectDeletePage(parentPage);
            
            generalPage.VerifyAlertMessage(Constant.MsgDeletePage);
            generalPage.AcceptAlert();
            
            generalPage.VerifyAlertMessage("Cannot delete page '" + parentPage + "' since it has child page(s).");
            generalPage.AcceptAlert();

            generalPage.SelectDeletePage(parentPage + "/" + childPage);           
            generalPage.VerifyAlertMessage(Constant.MsgDeletePage);
            generalPage.AcceptAlert();

           
            generalPage.VerifyPageNotExist(parentPage + "/" + childPage);

            generalPage.SelectDeletePage(parentPage);

            generalPage.VerifyAlertMessage(Constant.MsgDeletePage);
            generalPage.AcceptAlert();
            
            generalPage.VerifyPageNotExist(parentPage);

            generalPage.GotoPage(Constant.Overview);
            
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
            generalPage = newPage.CreateNewPage(Constant.StatusPublic, Constant.PageName1, Constant.DefaultValue, Constant.DefaultValue, Constant.DefaultValue, Constant.DefaultValue);
            //add page2
            newPage = generalPage.GotoNewPage();
            generalPage = newPage.CreateNewPage(Constant.StatusPublic, Constant.PageName2, Constant.DefaultValue, Constant.DefaultValue, Constant.DefaultValue, Constant.DefaultValue);

            editPage = generalPage.GotoEditPage(Constant.PageName1);
            generalPage = editPage.EditAPage(Constant.DefaultValue, Constant.PageName1, Constant.DefaultValue, Constant.Overview, Constant.DefaultValue,Constant.DefaultValue);
                                
            generalPage.VerifyPageDisplayedBesideAnotherPage(Constant.Overview, Constant.PageName1);

            //post-condition
            generalPage.DeletePage(Constant.PageName1);
            generalPage.DeletePage(Constant.PageName2);
            loginPage = generalPage.LogOut();
        }
    }
}
