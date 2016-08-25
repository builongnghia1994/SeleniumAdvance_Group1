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
            //DesiredCapabilities capabilities = DesiredCapabilities.Chrome();
            //capabilities.SetCapability(CapabilityType.Version, "51");
            //capabilities.SetCapability(CapabilityType.Platform, new Platform(PlatformType.Windows));
         //   Constant.WebDriver = new RemoteWebDriver(new Uri("http://192.168.190.114:4444/wd/hub"), DesiredCapabilities.InternetExplorer());
          //  Constant.WebDriver.Manage().Window.Maximize();
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
            try
            {
                //Constant.WebDriver.Manage().Window.Maximize();
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

