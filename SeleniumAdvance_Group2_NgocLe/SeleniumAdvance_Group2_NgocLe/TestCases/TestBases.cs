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
    public class TestBases : CommonActions
    {
        #region Create pageobject
        public GeneralPage generalPage;
        public LoginPage loginPage;
        public DataProfilePage dataProfilePage;
        public PanelManagerPage panelManagerPage;
        public PanelPage panelPage;
        public NewPage newpage;
        #endregion

        #region TestInitialize
        [TestInitialize]
        public void TestInitializeMeThod()
        {
            OpenBrowser(Constant.Browser);
        }
        #endregion

        //#region TestCleanup
        //[TestCleanup]
        //public void TestCleanupMethods()
        //{

        //    CloseBrowser();
        //}
        //#endregion


    }
}

