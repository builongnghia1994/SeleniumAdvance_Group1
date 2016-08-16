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
          
            generalPage = loginPage.LoginSuccessfully(Constant.Respos_SampleRepository, Constant.Username_ngoc, Constant.Password);
            newPage = generalPage.GotoNewPage();
            generalPage = newPage.CreateNewPage(Constant.statusPublic, Constant.timesystem, Constant.defaultValue, Constant.defaultValue, Constant.defaultValue);
            loginPage = newPage.LogOut();
            //vp
            generalPage = loginPage.LoginSuccessfully(Constant.Respos_SampleRepository, Constant.Username_ngoc, Constant.Password);
            generalPage.VerifyPageDisplayedBesideAnotherPage(Constant.itemDisplayAfter, Constant.timesystem);

        }

        [TestMethod]
        public void DA_MP_TC017_user_can_remove_any_main_parent_page_without_children_and_except_Overview_page()
        {
          
            generalPage = loginPage.LoginSuccessfully(Constant.Respos_SampleRepository, Constant.Username_ngoc, Constant.Password);

            newPage = generalPage.GotoNewPage();
            generalPage = newPage.CreateNewPage(Constant.statusPublic,Constant.timesystem, Constant.defaultValue, Constant.defaultValue, Constant.defaultValue);

            newPage = generalPage.GotoNewPage();
            generalPage = newPage.CreateNewPage(Constant.statusPublic,Constant.timesystem+"1",Constant.timesystem, Constant.defaultValue, Constant.defaultValue);


            generalPage.DeletePage(Constant.timesystem);
            //vp1
            generalPage.VerifyAlertMessage("Are you sure you want to remove this page?");
            generalPage.AcceptAlert();
            //vp2
            generalPage.VerifyAlertMessage("Cannot delete page '" +  Constant.timesystem + "' since it has child page(s).");
            generalPage.AcceptAlert();

            generalPage.DeletePage( Constant.timesystem + "/" + Constant.timesystem+"1");
            //vp3
            generalPage.VerifyAlertMessage("Are you sure you want to remove this page?");
            generalPage.AcceptAlert();
            //vp4
            generalPage.VerifyPageNotExist( Constant.timesystem + "/" + Constant.timesystem + "1");

            generalPage.DeletePage(Constant.timesystem);
            //vp5
            generalPage.VerifyAlertMessage("Are you sure you want to remove this page?");
            generalPage.AcceptAlert();
            //vp6
            generalPage.VerifyPageNotExist(Constant.timesystem);

            generalPage.GotoPage("Overview");

            //generalPage.VerifyControlNotExist(PageObject.GeneralPage.GeneralPageUI.itemDelete);
        }


    }
}
