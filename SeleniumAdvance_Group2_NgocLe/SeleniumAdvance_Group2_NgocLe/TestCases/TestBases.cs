using Fenton.Selenium.SuperDriver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;
using SeleniumAdvance_Group2.Common;
using SeleniumAdvance_Group2.PageObject.General;
using SeleniumAdvance_Group2.PageObject.Login;
using System;
using OpenQA.Selenium;
using System.Collections.Generic;
using OpenQA.Selenium.Firefox;

namespace SeleniumAdvance_Group2.TestCases
{
    [TestClass]
    public class TestBases : CommonActions
    {
        public LoginPage loginPage;

        public TestContext TestContext { get; set; }

        private static void RunBrowser()
        {
            switch (Constant.RunType.ToLower())
            {
                case "local":
                    OpenBrowser(Constant.Browser);
                    break;
                case "parallel":
                    Constant.WebDriver = new SuperWebDriver();
                    break;
                case "grid":
                    OpenBrowserGrid(Constant.Browser);
                    break;
                default:
                    Console.WriteLine(String.Format("Run type '{0}' is not recognized. Spawning default Firefox browser.", Constant.RunType));
                    OpenBrowser(Constant.Browser);
                    break;
            }
        }

        [AssemblyInitialize]
        public static void AssemblyInitializeMeThod(TestContext testContext)
        {
            RunBrowser();
        }

        [AssemblyCleanup]
        public static void AssemblyCleanupMethod()
        {
            Constant.WebDriver.Quit();
        }

        [TestInitialize]
        public void TestInitializeMethods()
        {
            try
            {
                string url = Constant.WebDriver.Url;
            }
            catch (Exception)
            {
                RunBrowser();     
            }

            loginPage = OpenURL(Constant.DashboardURL);
        }

        [TestCleanup]
        public void TestCleanupMethods()
        {
            Constant.WebDriver.Manage().Cookies.DeleteAllCookies();
            if (TestContext.CurrentTestOutcome.ToString() == "Failed")
            {
                Constant.WebDriver.Quit();
            }
        }
    }
}

