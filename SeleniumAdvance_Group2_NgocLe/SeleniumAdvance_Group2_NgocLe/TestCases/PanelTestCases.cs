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
        [TestMethod]
        public void DA_PANEL_TC029_Verify_that_user_is_unable_to_create_new_panel_when_required_field_is_not_filled()
        {
            NewPanelPage newPanelPage ;
            GeneralPage generalPage = new GeneralPage();
            generalPage = loginPage.LoginSuccessfully(Constant.Respos_SampleRepository, Constant.Username_trang, Constant.Password);
            newPanelPage = generalPage.GotoPanelPage();
            newPanelPage.ClickOK();
            newPanelPage.VerifyTextInAlertPopup(Constant.MsgRequiredFieldPanel);
            generalPage.LogOut();
        }
    }
}
