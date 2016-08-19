using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumAdvance_Group2.PageObject.DataProfile;
using SeleniumAdvance_Group2.PageObject.Login;
using SeleniumAdvance_Group2.PageObject.General;
using SeleniumAdvance_Group2.Common;

namespace SeleniumAdvance_Group2.TestCases.Draft
{
    [TestClass]
    public class Nghia
    {
        LoginPage loginPage;
        GeneralPage generalPage;
        DataProfileManagerPage dataProfileManagerPage;

       [TestMethod]
        public void DA_DP_TC073_Verify_that_all_data_profile_types_are_listed_in_priority_order_under_Item_Type_dropped_down_menu()
        {
            NewDataProfilePage newDataProfilePage;

            loginPage = new LoginPage();

            generalPage = loginPage.LoginDashBoard(Constant.Respos_SampleRepository, Constant.Username_nghia, Constant.Password);

            dataProfileManagerPage = generalPage.GotoDataProfileManagerPage();

            newDataProfilePage = dataProfileManagerPage.GotoNewDataProfilePage();

            newDataProfilePage.VerifyDropdownlistDisplayByPriority(Constant.itemTypeValues, newDataProfilePage.GetItemTypeValues());
        }
    }
}
