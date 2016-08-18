using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumAdvance_Group2.Common;
using SeleniumAdvance_Group2.PageObject.Login;
using System;

namespace SeleniumAdvance_Group2.TestCases
{
    [TestClass]
    public class TestBases : CommonActions
    {
        public LoginPage loginPage;

        public TestContext TestContext { get; set; }

        [AssemblyInitialize]
        public static void AssemblyInitializeMeThod(TestContext testContext)
        {
            OpenBrowser(Constant.Browser);
        }

        //[AssemblyCleanup]
        //public static void AssemblyCleanupMethod()
        //{
        //    Constant.WebDriver.Quit();
        //}

        [TestInitialize]
        public void TestInitializeMethods()
        {
            try
            {
                string url = Constant.WebDriver.Url;
            }
            catch (Exception e)
            {
                OpenBrowser(Constant.Browser);
            }

            loginPage = OpenURL(Constant.DashboardURL);
        }

        //[TestCleanup]
        //public void TestCleanupMethods()
        //{
        //    Constant.WebDriver.Manage().Cookies.DeleteAllCookies();
        //    if (TestContext.CurrentTestOutcome.ToString() == "Failed")
        //    {
        //        Constant.WebDriver.Quit();
        //    }
        //}

    }
}

