using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumAdvance_Group2.Common;
using SeleniumAdvance_Group2.PageObject.Login;
using SeleniumAdvance_Group2.PageObject.General;
using SeleniumAdvance_Group2.PageObject.MainPage;
using OpenQA.Selenium.Support.UI;

namespace SeleniumAdvance_Group2.TestCases
{
    [TestClass]
    public class DemoThi : TestBases
    {
        GeneralPage generalPage;
        NewPage newPage;

        [TestMethod]

        public void Demo_Thi_DeleteAllPage()
        {
            loginPage = new LoginPage();
            generalPage = loginPage.LoginDashBoard(Constant.Respos_SampleRepository, Constant.Username_thi, Constant.Password);
            generalPage.DeleteAllPages();
            //generalPage.DeletePagesJustCreated("page1160820160300190324");

        }
        [TestMethod]
        public void Demo_Thi_DeletePageJustCreated()
        {
            loginPage = new LoginPage();
            generalPage = loginPage.LoginDashBoard(Constant.Respos_SampleRepository, Constant.Username_thi, Constant.Password);
            newPage = generalPage.GotoNewPage();
            generalPage = newPage.CreateNewPage(Constant.statusPublic, Constant.pageName, Constant.defaultValue, Constant.defaultValue, Constant.defaultValue);
            newPage = generalPage.GotoNewPage();

            generalPage = newPage.CreateNewPage(Constant.statusPublic, Constant.pageName1, Constant.pageName, Constant.defaultValue, Constant.defaultValue);
            generalPage.DeletePagesJustCreated(Constant.pageName);

        }
    }
}
