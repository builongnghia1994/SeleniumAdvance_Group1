using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumAdvance_Group2.Common;
using SeleniumAdvance_Group2.PageObject.GeneralPage;
using SeleniumAdvance_Group2.PageObject.DataProfilePage.DataProfileManagerPage;
using SeleniumAdvance_Group2.PageObject.LoginPage;
using SeleniumAdvance_Group2.PageObject.MainPage.NewPage;
using SeleniumAdvance_Group2.PageObject.PanelPage.PanelManagerPage;
using SeleniumAdvance_Group2.PageObject.PanelPage.NewPanelPage;
using SeleniumAdvance_Group2.PageObject.MainPage.EditPage;
using SeleniumAdvance_Group2.PageObject.DataProfilePage.NewDataProfilePage;

namespace SeleniumAdvance_Group2.TestCases
{
    [TestClass]
    public class TestBases : CommonActions
    {
        #region Create pageobject
        public GeneralPageActions generalPageActions = new GeneralPageActions();
        public GeneralPageUI generalPageUI;
        public LoginPageActions loginPageActions = new LoginPageActions();
        public LoginPageUI loginPageUI;
        public DataProfileManagerPageActions dataProfileManagerPageActions = new DataProfileManagerPageActions();
        public NewDataProfileActions newDataProfileActions;
        public PanelManagerPageActions panelManagerPageActions;
        public NewPanelPageActions newPanelPageActions=new NewPanelPageActions();
        public NewPanelPageUI newPanelPageUI;
        public NewPageActions newPageActions;
        public EditPageActions editPageActions;

        #endregion

        public TestContext TestContext { get; set; }

        [AssemblyInitialize]
        public static void AssemblyInitializeMeThod(TestContext testContext)
        {
            OpenBrowser(Constant.Browser);
        }

        [AssemblyCleanup]
        public static void AssemblyCleanupMethod()
        {
            Constant.WebDriver.Quit();
        }

        [TestInitialize]
        public void TestInitializeMethods()
        {
            OpenURL(Constant.DashboardURL);
        }
        [TestCleanup]
        public void TestCleanupMethods()
        {
            Constant.WebDriver.Manage().Cookies.DeleteAllCookies();
        }

    }
}

