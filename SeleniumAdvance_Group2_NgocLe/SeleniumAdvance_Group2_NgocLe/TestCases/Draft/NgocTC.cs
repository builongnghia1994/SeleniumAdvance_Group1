using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumAdvance_Group2.Common;
using System.Threading;
using SeleniumAdvance_Group2.PageObject.Login;
using SeleniumAdvance_Group2.PageObject.General;
using SeleniumAdvance_Group2.PageObject.MainPage;
using OpenQA.Selenium;

namespace SeleniumAdvance_Group2.TestCases
{
    [TestClass]
    public class NgocTC : TestBases
    {
        GeneralPage generalPage;
        NewPage newPage;

        [TestMethod]
        public void DA_MP_TC014_Public_pages_can_be_visible_and_accessed_by_all_users()
        {

            generalPage = loginPage.LoginDashBoard(Constant.Respos_SampleRepository, Constant.Username_ngoc, Constant.Password);
            newPage = generalPage.GotoNewPage();
            generalPage = newPage.CreateNewPage(Constant.statusPublic, Constant.timesystem, Constant.defaultValue, Constant.defaultValue, Constant.defaultValue, 0);
            loginPage = newPage.LogOut();
            //vp
            generalPage = loginPage.LoginDashBoard(Constant.Respos_SampleRepository, Constant.Username_ngoc, Constant.Password);
            generalPage.VerifyPageDisplayedBesideAnotherPage(Constant.itemDisplayAfter, Constant.timesystem);

        }      


    }
}
