using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumAdvance_Group2.Common;
using SeleniumAdvance_Group2.PageObject.General;
using SeleniumAdvance_Group2.PageObject.Panel;

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
            newPanelPage = choosePanelPage.GoToNewPanelPage();
            newPanelPage.AddNewPanel(displayName, series);
            PanelConfigurationPage panelConfiguration = new PanelConfigurationPage();
            panelConfiguration.CreatePanelConfiguration(null, null, "");
            VerifyTextFromAlertAndAccept(Constant.MsgInvalidFolder_Panel);

        }

    }
}
