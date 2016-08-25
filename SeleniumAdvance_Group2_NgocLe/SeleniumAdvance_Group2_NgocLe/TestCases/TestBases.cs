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
            switch (Constant.RunType.ToLower())
            {
                case "local":
                    OpenBrowser(Constant.Browser);
                    break;
                case "parallel":

                    break;
                case "grid":
                    Uri uri = new Uri("http://192.168.190.114:4444/wd/hub");
                    switch (Constant.Browser.ToLower())
                    {
                        case "firefox":
                            Constant.WebDriver = new RemoteWebDriver(uri, DesiredCapabilities.Firefox());
                            Constant.WebDriver.Manage().Window.Maximize();
                            break;
                        case "chrome":
                            Constant.WebDriver = new RemoteWebDriver(uri, DesiredCapabilities.Chrome());
                            Constant.WebDriver.Manage().Window.Maximize();
                            break;
                        case "ie":
                            Constant.WebDriver = new RemoteWebDriver(uri, DesiredCapabilities.InternetExplorer());
                            Constant.WebDriver.Manage().Window.Maximize();
                            break;
                        case "edgewin":
                            Constant.WebDriver = new RemoteWebDriver(uri, DesiredCapabilities.Edge());
                            Constant.WebDriver.Manage().Window.Maximize();
                            break;
                        default:
                            Console.WriteLine(String.Format("Browser '{0}' is not recognized. Spawning default Firefox browser.", Constant.Browser));
                            Constant.WebDriver = new RemoteWebDriver(uri, DesiredCapabilities.Firefox());
                            Constant.WebDriver.Manage().Window.Maximize();
                            break;
                    }
                    break;
                default:
                    Console.WriteLine(String.Format("Run type '{0}' is not recognized. Spawning default Firefox browser.", Constant.RunType));
                    OpenBrowser(Constant.Browser);
                    break;
            }
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

