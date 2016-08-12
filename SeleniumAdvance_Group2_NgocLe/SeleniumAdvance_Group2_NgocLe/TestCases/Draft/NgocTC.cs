using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumAdvance_Group2.Common;
using System.Threading;
using SeleniumAdvance_Group2.PageObject.LoginPage;

namespace SeleniumAdvance_Group2.TestCases
{
    [TestClass]
    public class NgocTC : TestBases
    {
        [TestMethod]
        public void DA_MP_TC014_Public_pages_can_be_visible_and_accessed_by_all_users()
        {

            loginPageActions = new LoginPageActions();
            generalPageActions = loginPageActions.Login(Constant.Respository, Constant.userTrang, Constant.passTrang);
            newPageActions = generalPageActions.GotoNewPage();
            generalPageActions = newPageActions.CreadNewPage("public", "TC016", Constant.defaultValue, Constant.defaultValue, Constant.defaultValue);
            loginPageActions = newPageActions.LogOut();
            generalPageActions = loginPageActions.Login(Constant.Respository, Constant.userTrang, Constant.passTrang);
            generalPageActions.VerifyPageDisplayedBesideAnotherPage("Overview", "TC016");

        }

        [TestMethod]
        public void DA_MP_TC017_user_can_remove_any_main_parent_page_without_children()
        {
            loginPageActions = new LoginPageActions();
            generalPageActions = loginPageActions.Login(Constant.Respository, Constant.userTrang, Constant.passTrang);
            newPageActions = generalPageActions.GotoNewPage();
  
            generalPageActions = newPageActions.CreadNewPage("public", Constant.timesystem, Constant.defaultValue, Constant.defaultValue, Constant.defaultValue);
            newPageActions = generalPageActions.GotoNewPage();
            generalPageActions = newPageActions.CreadNewPage("public", Constant.timesystem+"1", Constant.timesystem, Constant.defaultValue, Constant.defaultValue);
            

            generalPageActions.DeletePage(Constant.timesystem);
            generalPageActions.VerifyAlertMessenge("Are you sure you want to remove this page?");
            generalPageActions.AcceptAlert();

            generalPageActions.VerifyAlertMessenge("Cannot delete page '"+Constant.timesystem+"' since it has child page(s)");
            generalPageActions.AcceptAlert();

            generalPageActions.DeletePage(Constant.timesystem + "/" + Constant.timesystem + "1");
            generalPageActions.VerifyAlertMessenge("Are you sure you want to remove this page?");
            generalPageActions.AcceptAlert();
            generalPageActions.VerifyPageNotExist(Constant.timesystem + "/" + Constant.timesystem + "1");

            generalPageActions.DeletePage(Constant.timesystem);
            generalPageActions.VerifyAlertMessenge("Are you sure you want to remove this page?");
            generalPageActions.AcceptAlert();
            generalPageActions.VerifyPageNotExist(Constant.timesystem);
            generalPageActions.VerifyControlNotExist(PageObject.GeneralPage.GeneralPageUI.itemDelete);
        }

    }
}
