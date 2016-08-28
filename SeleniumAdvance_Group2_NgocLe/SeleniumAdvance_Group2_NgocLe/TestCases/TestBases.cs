using Fenton.Selenium.SuperDriver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumAdvance_Group2.Common;
using SeleniumAdvance_Group2.PageObject.Login;
using System;
using OpenQA.Selenium;
using System.Collections.Generic;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using System.Linq;
using OpenQA.Selenium.Remote;

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
                    Constant.WebDriver = new SuperWebDriver(GetDriverSuite());
                    Constant.WebDriver.Manage().Window.Maximize();
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

        private static IList<IWebDriver> GetDriverSuite()
        {
            Uri uri = new Uri(Constant.HubRL);
            IList<IWebDriver> drivers = new List<Func<IWebDriver>>
            {
                () => { return Constant.WebDriver = new RemoteWebDriver(uri, DesiredCapabilities.Firefox()); },
                () => { return Constant.WebDriver = new RemoteWebDriver(uri, DesiredCapabilities.Chrome()); },
                //() => { return Constant.WebDriver = new RemoteWebDriver(uri, DesiredCapabilities.InternetExplorer()); },
            }.AsParallel().Select(d => d()).ToList();

            return drivers;
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