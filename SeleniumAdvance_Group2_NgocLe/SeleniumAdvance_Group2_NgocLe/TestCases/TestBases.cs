using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
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
           //Constant.WebDriver = new RemoteWebDriver(new Uri("http://192.168.189.235:4444/wd/hub"), DesiredCapabilities.Firefox());

            //String Node = "http://192.168.189.235:4444/wd/hub";
            //DesiredCapabilities capability = DesiredCapabilities.Firefox();           
            //Constant.WebDriver = new RemoteWebDriver(new Uri(Node), capability);
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
                OpenBrowser(Constant.Browser);
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

