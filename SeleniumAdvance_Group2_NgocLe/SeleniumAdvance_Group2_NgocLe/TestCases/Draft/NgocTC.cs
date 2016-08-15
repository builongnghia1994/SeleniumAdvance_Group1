using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumAdvance_Group2.Common;
using System.Threading;
using SeleniumAdvance_Group2.PageObject.Login;
using SeleniumAdvance_Group2.PageObject.General;
using SeleniumAdvance_Group2.PageObject.MainPage;

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

            loginPage = new LoginPage();
            generalPage = loginPage.LoginSuccessfully(Constant.Respos_SampleRepository, Constant.Username_ngoc, Constant.Password);
            newPage = generalPage.GotoNewPage();
            generalPage = newPage.CreateNewPage("public", "TC016", Constant.defaultValue, Constant.defaultValue, Constant.defaultValue);
            loginPage = newPage.LogOut();
            generalPage = loginPage.LoginSuccessfully(Constant.Respos_SampleRepository, Constant.Username_ngoc, Constant.Password);
            generalPage.VerifyPageDisplayedBesideAnotherPage("Overview", "TC016");

        }

        [TestMethod]
        public void DA_MP_TC017_user_can_remove_any_main_parent_page_without_children()
        {
            loginPage = new LoginPage();
            generalPage = loginPage.LoginSuccessfully(Constant.Respos_SampleRepository, Constant.Username_ngoc, Constant.Password);
            newPage = generalPage.GotoNewPage();

            generalPage = newPage.CreateNewPage("public", Constant.timesystem, Constant.defaultValue, Constant.defaultValue, Constant.defaultValue);
            newPage = generalPage.GotoNewPage();
            generalPage = newPage.CreateNewPage("public", Constant.timesystem + "1", Constant.timesystem, Constant.defaultValue, Constant.defaultValue);


            generalPage.DeletePage(Constant.timesystem);
            generalPage.VerifyAlertMessenge("Are you sure you want to remove this page?");
            generalPage.AcceptAlert();

            generalPage.VerifyAlertMessenge("Cannot delete page '" + Constant.timesystem + "' since it has child page(s)");
            generalPage.AcceptAlert();

            generalPage.DeletePage(Constant.timesystem + "/" + Constant.timesystem + "1");
            generalPage.VerifyAlertMessenge("Are you sure you want to remove this page?");
            generalPage.AcceptAlert();
            generalPage.VerifyPageNotExist(Constant.timesystem + "/" + Constant.timesystem + "1");

            generalPage.DeletePage(Constant.timesystem);
            generalPage.VerifyAlertMessenge("Are you sure you want to remove this page?");
            generalPage.AcceptAlert();
            generalPage.VerifyPageNotExist(Constant.timesystem);
            //generalPage.VerifyControlNotExist(PageObject.GeneralPage.GeneralPageUI.itemDelete);
        }

    }
}
