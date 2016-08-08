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

        #region TestCleanup
        [TestCleanup]
        public void TestCleanupMethods()
        {

            CloseBrowser();
        }
        #endregion

        #region Methods

        public void OpenBrowser(string browser)

        {
            switch (browser.ToLower())
            {

                case "chrome":
                    ChromeOptions options = new ChromeOptions();
                    options.AddArguments("--disable-extensions");
                    Constant.WebDriver = new ChromeDriver(options);
                    Constant.WebDriver.Manage().Window.Maximize();
                    break;
                case "ie":
                    Constant.WebDriver = new InternetExplorerDriver();
                    Constant.WebDriver.Manage().Window.Maximize();
                    break;
                case "firefox":
                    Constant.WebDriver = new FirefoxDriver();
                    Constant.WebDriver.Manage().Window.Maximize();
                    break;
                case "edgewin":
                    Constant.WebDriver = new EdgeDriver();
                    Constant.WebDriver.Manage().Window.Maximize();
                    break;
                default:
                    Console.WriteLine(String.Format("Browser '{0}' not recognized. Spawning default Firefox browser.", browser));
                    Constant.WebDriver = new FirefoxDriver();
                    Constant.WebDriver.Manage().Window.Maximize();
                    break;
            }
        }

        public void CloseBrowser()
        {
            Constant.WebDriver.Manage().Cookies.DeleteAllCookies();
            Constant.WebDriver.Quit();
            #endregion
        }
    }
}

