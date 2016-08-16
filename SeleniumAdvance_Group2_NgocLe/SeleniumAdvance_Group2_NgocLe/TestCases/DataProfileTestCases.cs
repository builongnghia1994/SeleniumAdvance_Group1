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

            generalPage = loginPage.LoginSuccessfully(Constant.Respos_SampleRepository, Constant.Username_nghia, Constant.Password);

            dataProfileManagerPage = generalPage.GotoDataProfilePage();

            dataProfileManagerPage.VerifyPreDataProfile(Constant.preSetDataProfile, dataProfileManagerPage.GetActualPreDataPRofile());
        }

        [TestMethod]
        public void DA_DP_TC067_Verify_that_Data_Profiles_are_listed_alphabetically()
        {
            loginPage = new LoginPage();

            generalPage = loginPage.LoginSuccessfully(Constant.Respos_SampleRepository, Constant.Username_nghia, Constant.Password);

            dataProfileManagerPage = generalPage.GotoDataProfilePage();

            dataProfileManagerPage.VerifyDataProfileInAlphabeticalOrder();
        }

        [TestMethod]
        public void DA_DP_TC073_Verify_that_all_data_profile_types_are_listed_in_priority_order_under_Item_Type_dropped_down_menu()
        {
            NewDataProfilePage newDataProfilePage;

            loginPage = new LoginPage();

            generalPage = loginPage.LoginSuccessfully(Constant.Respos_SampleRepository, Constant.Username_nghia, Constant.Password);

            dataProfileManagerPage = generalPage.GotoDataProfilePage();

            newDataProfilePage = dataProfileManagerPage.GotoNewDataProfilePage();

            newDataProfilePage.VerifyDropdownlistDisplayByPriority(Constant.itemTypeValues, newDataProfilePage.GetItemTypeValues());
        }

        [TestMethod]
        public void DA_DP_TC076Verify_that_for_newly_created_data_profile_user_is_able_to_navigate_through_other_setting_pages_on_the_left_navigation_panel()
        {
            NewDataProfilePage newDataProfilePage;

            loginPage = new LoginPage();

            generalPage = loginPage.LoginSuccessfully(Constant.Respos_SampleRepository, Constant.Username_nghia, Constant.Password);

            dataProfileManagerPage = generalPage.GotoDataProfilePage();

            newDataProfilePage = dataProfileManagerPage.GotoNewDataProfilePage();

            dataProfileManagerPage = newDataProfilePage.AddADataProfile("nghiabui", "Test Modules", "Related bugs");

            newDataProfilePage = dataProfileManagerPage.GotoEditProfilePage("nghiabui");

            newDataProfilePage.VerifyPageDisplayCorrectlyWithLeftNavigation();
        }
    }
}
