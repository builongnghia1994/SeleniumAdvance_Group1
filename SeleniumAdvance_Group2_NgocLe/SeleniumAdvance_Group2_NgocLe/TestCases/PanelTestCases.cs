using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumAdvance_Group2.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumAdvance_Group2.TestCases
{
    [TestClass]
    public class PanelTestCases : TestBases
    {
        [TestMethod]
        public void DA_PANEL_TC029()
        {

            loginPage = OpenURL(Constant.DashboardURL);
            generalPage = loginPage.Login(Constant.Respository, Constant.userTrang, Constant.passTrang);
            panelPage = generalPage.GotoPanelPage();
            ClickControl(panelPage.BtnOK);
            //  VerifyText(Constant.MsgRequiredFieldPanel, GetTextFromAlertPopup());
            // ClickControl(panelPage.BtnCancel);
            panelPage.VerifyTextInAlertPopup();
            //  generalPage.GotoPage("Trang/Trang1/Trang2");
        }
    }
}
