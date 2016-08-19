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
using System.Threading;

namespace SeleniumAdvance_Group2.TestCases
{
    [TestClass]
    public class PanelTestCases : TestBases
    {
        GeneralPage generalPage;
        NewPanelPage newPanelPage;

        [TestMethod]
        public void DA_PANEL_TC029_Verify_that_user_is_unable_to_create_new_panel_when_required_field_is_not_filled()
        {
            generalPage = loginPage.LoginDashBoard(Constant.Respos_SampleRepository, Constant.Username_trang, Constant.Password);
            newPanelPage = generalPage.GotoPanelPage();
            newPanelPage.ClickOK();
            newPanelPage.VerifyTextInAlertPopup(Constant.MsgRequiredFieldPanel);
            generalPage.LogOut();
        }
        [TestMethod]
        public void DA_PANEL_TC030_Verify_that_no_special_character_except_at_sign_character_is_allowed_to_be_inputted_into_Display_Name_field()
        {
            string specialCharacterPanel = "panel" + Constant.timesystem + "#$%";
            string atsignPanel = "panel" + Constant.timesystem + "@";
            string series = "  Name";
            PanelManagerPage panelManagerPage = new PanelManagerPage();
            generalPage = loginPage.LoginDashBoard(Constant.Respos_SampleRepository, Constant.Username_trang, Constant.Password);
            newPanelPage = generalPage.GotoPanelPage();
            newPanelPage.AddNewPanel(specialCharacterPanel, series);
            newPanelPage.VerifyTextInAlertPopup(Constant.MsgInvalidPanelDisplayName);
            newPanelPage = panelManagerPage.GoToPanelPage();
            newPanelPage.AddNewPanel(atsignPanel, series);
            panelManagerPage.VerifyPanelDisplayed(atsignPanel);
            generalPage.LogOut();
        }

        [TestMethod]
        public void DA_PANEL_TC045_Verify_that_Folder_field_is_not_allowed_to_be_empty()
        {
            string displayName = "panel" + Constant.timesystem ;
            string series = "  Name";
            generalPage = loginPage.LoginDashBoard(Constant.Respos_SampleRepository, Constant.Username_trang, Constant.Password);
            generalPage = generalPage.CreateNewPageFromGeneralPage(Constant.statusPublic, Constant.pageName2, Constant.defaultValue, Constant.defaultValue, Constant.defaultValue);
            ChoosePanelPage choosePanelPage = generalPage.GotoChoosePanelPage();
            newPanelPage = choosePanelPage.GotoNewPanelPage();
            newPanelPage.AddNewPanel(displayName, series);
            PanelConfigurationPage panelConfiguration = new PanelConfigurationPage();
            panelConfiguration.CreatePanelConfiguration(null, null, "");
            VerifyTextFromAlertAndAccept(Constant.MsgInvalidFolder_Panel);

        }


        [TestMethod]
        public void DA_PANEL_TC042_Verify_that_all_pages_are_listed_correctly_under_the_Select_page_dropped_down_menu_of_Pane_Configuration_form()
        {
         
            generalPage = loginPage.LoginDashBoard(Constant.Respos_SampleRepository, Constant.Username_trang, Constant.Password);
            //add page1
            NewPage newPage = new NewPage();
            newPage = generalPage.GotoNewPage();
            generalPage = newPage.CreateNewPage(Constant.statusPublic, "thi1" + Constant.timesystem, Constant.defaultValue, Constant.defaultValue, Constant.defaultValue);
            //add page2
            newPage = generalPage.GotoNewPage();
            generalPage = newPage.CreateNewPage(Constant.statusPublic, "thi2" + Constant.timesystem, Constant.defaultValue, Constant.defaultValue, Constant.defaultValue);
            //add page 3
            newPage = generalPage.GotoNewPage();
            generalPage = newPage.CreateNewPage(Constant.statusPublic, "thi3" + Constant.timesystem, Constant.defaultValue, Constant.defaultValue, Constant.defaultValue);

            ChoosePanelPage choosePanelPage = new ChoosePanelPage();
            choosePanelPage = generalPage.GotoChoosePanelPage();

            PanelConfigurationPage panelConfigurationPage = new PanelConfigurationPage();
            panelConfigurationPage = choosePanelPage.GotoConfigurationPage();

            //vp          
            panelConfigurationPage.VerifyAllPagesAreListedCorrectlyUnderTheSelectPage("thi1" + Constant.timesystem, "thi2" + Constant.timesystem, "thi3" + Constant.timeout);
            
        }


        [TestMethod]
        public void DA_PANEL_TC049_Verify_that_all_folder_paths_of_corresponding_item_type_are_correct_in_Select_Folder_form() 
        {
            string series = "  Name";
            generalPage = loginPage.LoginDashBoard(Constant.Respos_SampleRepository, Constant.Username_trang, Constant.Password);
            //add page1
            NewPage newPage = new NewPage();
            newPage = generalPage.GotoNewPage();
            generalPage = newPage.CreateNewPage(Constant.statusPublic, "thi1" + Constant.timesystem, Constant.defaultValue, Constant.defaultValue, Constant.defaultValue);

            ChoosePanelPage choosePanelPage = new ChoosePanelPage();
            choosePanelPage = generalPage.GotoChoosePanelPage();

            NewPanelPage newPanelPage = new NewPanelPage();
            newPanelPage = choosePanelPage.GotoNewPanelPage();

            PanelConfigurationPage panelConfigurationPage = new PanelConfigurationPage();
            panelConfigurationPage = newPanelPage.GotoPanelConfigurationPageByAddNewPanel("test" + Constant.timesystem,series);

            SelectFolderPage selectFolderPage = new SelectFolderPage();
            selectFolderPage = panelConfigurationPage.GotoSelectFolderPage();

        }
    }
}
