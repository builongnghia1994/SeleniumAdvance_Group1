using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using SeleniumAdvance_Group2.PageObject.Login;
using SeleniumAdvance_Group2.PageObject.General;
using SeleniumAdvance_Group2.Common;
using System.Threading;

namespace SeleniumAdvance_Group2.TestCases
{
    [TestClass]
    public class TestGrid
    {
        [TestMethod]
        public void Nghia_Grid()
        {
            LoginPage loginPage = new LoginPage();
            GeneralPage generalPage = new GeneralPage();
            //IWebDriver webDriver;
            Constant.WebDriver = new RemoteWebDriver(new Uri("http://192.168.190.205:4444/wd/hub"), DesiredCapabilities.Firefox());
            Constant.WebDriver.Navigate().GoToUrl("http://192.168.190.205:54000/TADashboard/login.jsp");
            Thread.Sleep(500);
            generalPage = loginPage.LoginDashBoard(Constant.Respos_SampleRepository, Constant.Username_nghia, Constant.Password);
        }
    }
}
