using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumAdvance_Group2.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumAdvance_Group2.PageObject.LoginPage;
using SeleniumAdvance_Group2.PageObject.GeneralPage;
using SeleniumAdvance_Group2.PageObject.DataProfilePage;
using SeleniumAdvance_Group2.PageObject.PanelPage.NewPanelPage;


namespace SeleniumAdvance_Group2.TestCases
{
    [TestClass]
    public class PanelTestCases : TestBases
    {
        [TestMethod]
        public void DA_PANEL_TC029_Verify_that_user_is_unable_to_create_new_panel_when_required_field_is_not_filled()
        {
            loginPageUI = OpenURL1(Constant.DashboardURL);
            generalPageUI = loginPageActions.Login1(Constant.Respository, Constant.Username_trang, Constant.Password);
            newPanelPageUI = generalPageActions.GotoPanelPage();
            newPanelPageActions.ClickOK();
            newPanelPageActions.VerifyTextInAlertPopup(Constant.MsgRequiredFieldPanel);
            generalPageActions.LogOut();
        }
    }
}
