﻿using SeleniumAdvance_Group2.PageObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Edge;
using SeleniumAdvance_Group2.Common;
using SeleniumAdvance_Group2.PageObject.GeneralPage;
using System;
using System.Configuration;
using System.Configuration.Assemblies;
using SeleniumAdvance_Group2.PageObject.DataProfilePage.DataProfileManagerPage;
using SeleniumAdvance_Group2.PageObject.LoginPage;
using SeleniumAdvance_Group2.PageObject.MainPage.NewPage;
using SeleniumAdvance_Group2.PageObject.PanelPage.PanelManagerPage;
using SeleniumAdvance_Group2.PageObject.PanelPage;

namespace SeleniumAdvance_Group2.TestCases
{
    [TestClass]
    public class TestBases : CommonActions
    {
        #region Create pageobject
        public GeneralPageActions generalPage;
        public LoginPageActions loginPageActions;
        public DataProfileManagerPageActions dataProfileManagerPageActions;
        public PanelManagerPageActions panelManagerPageActions;
        public PageObject.PanelPage.NewPanelPageActions newPanelPageActions;
        public NewPageActions newpage;
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

