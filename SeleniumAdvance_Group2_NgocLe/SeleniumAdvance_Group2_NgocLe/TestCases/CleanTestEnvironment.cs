using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumAdvance_Group2.PageObject.General;
using SeleniumAdvance_Group2.Common;
using SeleniumAdvance_Group2.PageObject.Panel;

namespace SeleniumAdvance_Group2.TestCases
{
    [TestClass]
    public class CleanTestEnvironment : TestBases
    {
        [TestMethod]
        public void CleanEnvironment()
        {
            GeneralPage generalPage;
            PanelManagerPage panelManagerPage;

            generalPage = loginPage.LoginDashBoard(Constant.Respos_SampleRepository, Constant.Username_trang, Constant.Password);

            generalPage.DeleteAllPages();

            panelManagerPage = generalPage.GotoPanelManagerPage();
            generalPage = panelManagerPage.DeleteAllPanel();

            generalPage.LogOut();
        }
    }
}
