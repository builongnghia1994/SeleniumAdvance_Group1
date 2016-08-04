using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SeleniumAdvance_Group2_NgocLe
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public static void Openbrowser(string browser)

        {

            switch (browser.ToLower())
            {

                case "chrome":
                    Constant.WebDriver = new ChromeDriver();
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
    }
}
