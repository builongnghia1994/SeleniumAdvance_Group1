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
        public void DA_PANEL_TC029()
        {
            loginPageUI = OpenURL1(Constant.DashboardURL);
            generalPageUI = loginPageActions.Login1(Constant.Respository, Constant.userTrang, Constant.passTrang);
            newPanelPageUI = generalPageActions.GotoPanelPage();
            newPanelPageActions.ClickOK();
            newPanelPageActions.VerifyTextInAlertPopup(Constant.MsgRequiredFieldPanel);
            generalPageActions.LogOut();
        }
    }
}
