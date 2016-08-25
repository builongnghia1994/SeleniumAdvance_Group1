using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumAdvance_Group2.Common;
using SeleniumAdvance_Group2.PageObject.General;
using SeleniumAdvance_Group2.PageObject.Panel;
using SeleniumAdvance_Group2.PageObject.MainPage;
using SeleniumAdvance_Group2.PageObject.MainPage.Panel;
using System.Threading;

namespace SeleniumAdvance_Group2.TestCases
{
    [TestClass]
    public class PanelTestCases : TestBases
    {
        GeneralPage generalPage;
        NewPanelPage newPanelPage;
        PanelManagerPage panelManagerPage;
        NewPage newPage;
        ChoosePanelPage choosePanelPage;
        PanelConfigurationPage panelConfigurationPage;

        [TestMethod]
        public void DA_PANEL_TC029_Verify_that_user_is_unable_to_create_new_panel_when_required_field_is_not_filled()
        {
            generalPage = loginPage.LoginDashBoard(Constant.Respos_SampleRepository, Constant.Username_trang, Constant.Password);
            newPanelPage = generalPage.GotoPanelPage();
            newPanelPage.ClickOK();

            //vp
            newPanelPage.VerifyTextInAlertPopup(Constant.MsgRequiredFieldPanel);

            //post-condition
            generalPage.LogOut();
        }

        [TestMethod]
        public void DA_PANEL_TC030_Verify_that_no_special_character_except_at_sign_character_is_allowed_to_be_inputted_into_Display_Name_field()
        {
            string specialCharacterPanel = "panel" + Constant.timesystem + "#$%";
            string atsignPanel = "panel" + Constant.timesystem + "@";
            string series = "  Name";
            panelManagerPage = new PanelManagerPage();

            generalPage = loginPage.LoginDashBoard(Constant.Respos_SampleRepository, Constant.Username_trang, Constant.Password);
            newPanelPage = generalPage.GotoPanelPage();
            newPanelPage.AddNewPanel(specialCharacterPanel, series);
            //vp
            newPanelPage.VerifyTextInAlertPopup(Constant.MsgInvalidPanelDisplayName);

            newPanelPage = panelManagerPage.GoToPanelPage();
            newPanelPage.AddNewPanel(atsignPanel, series);
            //vp
            panelManagerPage.VerifyPanelDisplayed(atsignPanel);

            //post-condition
            generalPage.LogOut();
        }

        [TestMethod]
        public void DA_PANEL_TC042_Verify_that_all_pages_are_listed_correctly_under_the_Select_page_dropped_down_menu_of_Pane_Configuration_form()
        {
            string page1 = "thi1" + Constant.timesystem;
            string page2 = "thi2" + Constant.timesystem;
            string page3 = "thi3" + Constant.timesystem;

            generalPage = loginPage.LoginDashBoard(Constant.Respos_SampleRepository, Constant.Username_trang, Constant.Password);
            //add page1
            newPage = generalPage.GotoNewPage();
            generalPage = newPage.CreateNewPage(Constant.statusPublic, page1, Constant.defaultValue, Constant.defaultValue, Constant.defaultValue, 0);
            //add page2
            newPage = generalPage.GotoNewPage();
            generalPage = newPage.CreateNewPage(Constant.statusPublic, page2, Constant.defaultValue, Constant.defaultValue, Constant.defaultValue, 0);
            //add page 3
            newPage = generalPage.GotoNewPage();
            generalPage = newPage.CreateNewPage(Constant.statusPublic, page3, Constant.defaultValue, Constant.defaultValue, Constant.defaultValue, 0);

            choosePanelPage = generalPage.GotoChoosePanelPage();
            panelConfigurationPage = choosePanelPage.GotoConfigurationPage();

            //vp          
            panelConfigurationPage.VerifyAllPagesAreListedCorrectlyUnderTheSelectPage(page1, page2, page3);

            //post-condition: delete created pages and log out
            WaitForPageLoad();
            generalPage.DeletePageConfirmed(page1);
            generalPage.DeletePageConfirmed(page2);
            generalPage.DeletePageConfirmed(page3);
            generalPage.LogOut();
        }

        [TestMethod]
        public void DA_PANEL_TC049_Verify_that_all_folder_paths_of_corresponding_item_type_are_correct_in_Select_Folder_form()
        {
            string pageName = "thi1" + Constant.timesystem;
            string series = "  Name";
            string folderPath = "Car Rental - Mobile/Actions/Car";
            NewPanelForPage newPanelForPage;
            SelectFolderPage selectFolderPage;

            generalPage = loginPage.LoginDashBoard(Constant.Respos_SampleRepository, Constant.Username_trang, Constant.Password);

            newPage = generalPage.GotoNewPage();
            generalPage = newPage.CreateNewPage(Constant.statusPublic, pageName, Constant.defaultValue, Constant.defaultValue, Constant.defaultValue, 0);

            choosePanelPage = generalPage.GotoChoosePanelPage();
            newPanelForPage = choosePanelPage.GotoNewPanelPage();
            panelConfigurationPage = newPanelForPage.GotoPanelConfigurationPageByAddNewPanel("test" + Constant.timesystem, series);
            selectFolderPage = panelConfigurationPage.GotoSelectFolderPage();
            panelConfigurationPage = selectFolderPage.GotoPanelConfigurationPageAfterSelectFolder(folderPath);

            //vp
            panelConfigurationPage.VerifySelectedFolder(folderPath);

            //post-condition: delete created page and log out
            generalPage.DeletePageConfirmed(pageName);
            generalPage.LogOut();

        }
    }
}
