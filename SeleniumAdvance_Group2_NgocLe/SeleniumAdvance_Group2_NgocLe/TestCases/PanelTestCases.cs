using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumAdvance_Group2.Common;
using SeleniumAdvance_Group2.PageObject.General;
using SeleniumAdvance_Group2.PageObject.Panel;
using SeleniumAdvance_Group2.PageObject.MainPage;
using SeleniumAdvance_Group2.PageObject.MainPage.Panel;

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
          
            newPanelPage.VerifyTextInAlertPopup(Constant.MsgRequiredFieldPanel);

            //post-condition
            generalPage.LogOut();
        }

        [TestMethod]
        public void DA_PANEL_TC030_Verify_that_no_special_character_except_at_sign_character_is_allowed_to_be_inputted_into_Display_Name_field()
        {
            string specialCharacterPanel = "panel" + Constant.TimeSystem + "#$%";
            string atsignPanel = "panel" + Constant.TimeSystem + "@";
            panelManagerPage = new PanelManagerPage();

            generalPage = loginPage.LoginDashBoard(Constant.Respos_SampleRepository, Constant.Username_trang, Constant.Password);

            newPanelPage = generalPage.GotoPanelPage();
            newPanelPage.AddNewPanel(specialCharacterPanel, Constant.Series);
           
            newPanelPage.VerifyTextInAlertPopup(Constant.MsgInvalidPanelDisplayName);

            newPanelPage = panelManagerPage.GoToPanelPage();
            newPanelPage.AddNewPanel(atsignPanel, Constant.Series);

            panelManagerPage.VerifyPanelDisplayed(atsignPanel);

            //post-condition
            generalPage.LogOut();
        }

        [TestMethod]
        public void DA_PANEL_TC042_Verify_that_all_pages_are_listed_correctly_under_the_Select_page_dropped_down_menu_of_Pane_Configuration_form()
        {
            string page1 = "thi1" + Constant.TimeSystem;
            string page2 = "thi2" + Constant.TimeSystem;
            string page3 = "thi3" + Constant.TimeSystem;

            generalPage = loginPage.LoginDashBoard(Constant.Respos_SampleRepository, Constant.Username_trang, Constant.Password);

            //add page1
            newPage = generalPage.GotoNewPage();
            generalPage = newPage.CreateNewPage(Constant.StatusPublic, page1, Constant.DefaultValue, Constant.DefaultValue, Constant.DefaultValue, Constant.DefaultValue);

            //add page2
            newPage = generalPage.GotoNewPage();
            generalPage = newPage.CreateNewPage(Constant.StatusPublic, page2, Constant.DefaultValue, Constant.DefaultValue, Constant.DefaultValue, Constant.DefaultValue);

            //add page3
            newPage = generalPage.GotoNewPage();
            generalPage = newPage.CreateNewPage(Constant.StatusPublic, page3, Constant.DefaultValue, Constant.DefaultValue, Constant.DefaultValue, Constant.DefaultValue);

            choosePanelPage = generalPage.GotoChoosePanelPage();

            panelConfigurationPage = choosePanelPage.GotoConfigurationPage();
                     
            panelConfigurationPage.VerifyCreatedPagePresent(page1, page2, page3);

            //post-condition: delete created pages and log out
            WaitForPageLoad();
            generalPage.DeletePage(page1);

            generalPage.DeletePage(page2);

            generalPage.DeletePage(page3);

            generalPage.LogOut();
        }

        [TestMethod]
        public void DA_PANEL_TC049_Verify_that_all_folder_paths_of_corresponding_item_type_are_correct_in_Select_Folder_form()
        {
            string pageName = "thi1" + Constant.TimeSystem;
            string displayName = "test" + Constant.TimeSystem;
            string folderPath = "Car Rental - Mobile/Actions/Car";
            NewPanelForPage newPanelForPage;
            SelectFolderPage selectFolderPage;

            generalPage = loginPage.LoginDashBoard(Constant.Respos_SampleRepository, Constant.Username_trang, Constant.Password);

            newPage = generalPage.GotoNewPage();
            generalPage = newPage.CreateNewPage(Constant.StatusPublic, pageName, Constant.DefaultValue, Constant.DefaultValue, Constant.DefaultValue, Constant.DefaultValue);

            choosePanelPage = generalPage.GotoChoosePanelPage();

            newPanelForPage = choosePanelPage.GotoNewPanelPage();

            panelConfigurationPage = newPanelForPage.GotoPanelConfigurationPageByAddNewPanel(displayName, Constant.Series);

            selectFolderPage = panelConfigurationPage.GotoSelectFolderPage();

            panelConfigurationPage = selectFolderPage.SelectFolder(folderPath);
            
            panelConfigurationPage.VerifySelectedFolder(folderPath);

            //post-condition: delete created page and log out
            generalPage.DeletePage(pageName);

            generalPage.LogOut();
        }

        
    }
}
