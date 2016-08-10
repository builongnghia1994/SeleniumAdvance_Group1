using SeleniumAdvance_Group2.PageObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Edge;
using SeleniumAdvance_Group2.Common;
using System;
using System.Configuration;
using System.Configuration.Assemblies;

namespace SeleniumAdvance_Group2.TestCases
{
    [TestClass]
    public class TestBases : CommonActions
    {
        #region Create pageobject
        public GeneralPage generalPage;
        public LoginPage1 loginPage;
        public DataProfilePage dataProfilePage;
        public PanelManagerPage panelManagerPage;
        public PanelPage panelPage;
        public NewPage newpage;
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

        [TestCleanup]
        public void TestCleanupMethods()
        {
            Constant.WebDriver.Manage().Cookies.DeleteAllCookies();
        }

    }
}

