using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumAdvance_Group2.Common;
using SeleniumAdvance_Group2.PageObject.Login;
using SeleniumAdvance_Group2.PageObject.General;
using SeleniumAdvance_Group2.PageObject.DataProfile;

namespace SeleniumAdvance_Group2.TestCases
{
    [TestClass]
    public class DataProfileTestCases : TestBases
    {
        GeneralPage generalPage;
        DataProfileManagerPage dataProfileManagerPage;

       [TestMethod]
        public void DA_DP_TC065_Verify_that_all_Preset_Data_Profiles_are_populated_correctly()
        {
            loginPage = new LoginPage();

            generalPage = loginPage.LoginDashBoard(Constant.Respos_SampleRepository, Constant.Username_nghia, Constant.Password);

            dataProfileManagerPage = generalPage.GotoDataProfileManagerPage();

            dataProfileManagerPage.VerifyPreDataProfile(Constant.preSetDataProfile, dataProfileManagerPage.GetActualPreDataPRofile());
        }

        [TestMethod]
        public void DA_DP_TC067_Verify_that_Data_Profiles_are_listed_alphabetically()
        {
            loginPage = new LoginPage();

            generalPage = loginPage.LoginDashBoard(Constant.Respos_SampleRepository, Constant.Username_nghia, Constant.Password);

            dataProfileManagerPage = generalPage.GotoDataProfileManagerPage();

            dataProfileManagerPage.VerifyDataProfileInAlphabeticalOrder();
        }

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

        [TestMethod]
        public void DA_DP_TC076_Verify_that_for_newly_created_data_profile_user_is_able_to_navigate_through_other_setting_pages_on_the_left_navigation_panel()
        {
            NewDataProfilePage newDataProfilePage;
            EditDataProfilePage editDataProfilePage;

            loginPage = new LoginPage();

            generalPage = loginPage.LoginDashBoard(Constant.Respos_SampleRepository, Constant.Username_nghia, Constant.Password);

            dataProfileManagerPage = generalPage.GotoDataProfileManagerPage();

            newDataProfilePage = dataProfileManagerPage.GotoNewDataProfilePage();

            dataProfileManagerPage = newDataProfilePage.AddADataProfile(Constant.nameOfDataProfile, "test modules", "Related test results");

            editDataProfilePage = dataProfileManagerPage.GotoEditDataProfilePage(Constant.nameOfDataProfile);

            editDataProfilePage.ClickTab("general settings tab");
            editDataProfilePage.VerifyPageDisplay("General Settings");

            editDataProfilePage.ClickTab("display fields tab");
            editDataProfilePage.VerifyPageDisplay("Display Fields");

            editDataProfilePage.ClickTab("sort fields tab");
            editDataProfilePage.VerifyPageDisplay("Sort Fields");

            editDataProfilePage.ClickTab("filter fields tab");
            editDataProfilePage.VerifyPageDisplay("Filter Fields");

            editDataProfilePage.ClickTab("statistic fields tab");
            editDataProfilePage.VerifyPageDisplay("Statistic Fields");

            editDataProfilePage.ClickTab("display sub fields tab");
            editDataProfilePage.VerifyPageDisplay("Display Sub-Fields");

            editDataProfilePage.ClickTab("sort sub fields tab");
            editDataProfilePage.VerifyPageDisplay("Sort Sub-Fields");

            editDataProfilePage.ClickTab("filter sub fields tab");
            editDataProfilePage.VerifyPageDisplay("Filter Sub-Fields");

            editDataProfilePage.ClickTab("statistic sub fields tab");
            editDataProfilePage.VerifyPageDisplay("Statistic Sub-Fields");

        }
    }
}
