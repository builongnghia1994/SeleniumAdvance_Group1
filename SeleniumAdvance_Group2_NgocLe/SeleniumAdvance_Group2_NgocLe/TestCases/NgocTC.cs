using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumAdvance_Group2.Common;

namespace SeleniumAdvance_Group2.TestCases
{
    [TestClass]
    public class NgocTC : TestBases
    {
        [TestMethod]
        public void DA_MP_TC014_Public_pages_can_be_visible_and_accessed_by_all_users()
        {

            loginPageActions = OpenURL(Constant.DashboardURL);
            generalPageActions = loginPageActions.Login(Constant.Respository, Constant.userTrang, Constant.passTrang);
            newPageActions = generalPageActions.GotoNewPage();
            newPageActions.CreadNewPage("public", "TC016", Constant.defaultValue, Constant.defaultValue, Constant.defaultValue);
            loginPageActions = newPageActions.LogOut();
            generalPageActions = loginPageActions.Login(Constant.Respository, Constant.userTrang, Constant.passTrang);
            generalPageActions.VerifyPageDisplayedBesideAnotherPage("Overview", "TC016");

        }

        [TestMethod]
        public void DA_MP_TC017_user_can_remove_any_main_parent_page_without_children()
        {
        }

    }
}
