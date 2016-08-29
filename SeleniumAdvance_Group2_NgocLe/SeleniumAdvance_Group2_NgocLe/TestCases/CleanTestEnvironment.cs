using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumAdvance_Group2.PageObject.General;
using SeleniumAdvance_Group2.Common;
using SeleniumAdvance_Group2.PageObject.Panel;
using SeleniumAdvance_Group2.PageObject.DataProfile;

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
            DataProfileManagerPage dataProfileManagerPage;

            generalPage = loginPage.LoginDashBoard(Constant.Respos_SampleRepository, Constant.UsernameAdmin, Constant.PasswordAdmin);

            generalPage.DeleteAllPages();

            panelManagerPage = generalPage.GotoPanelManagerPage();
            panelManagerPage.DeleteAllPanel();

            dataProfileManagerPage = panelManagerPage.GotoDataProfileManagerPage();
            dataProfileManagerPage.DeleteAllDataProfile();

            dataProfileManagerPage.LogOut();
        }
    }
}