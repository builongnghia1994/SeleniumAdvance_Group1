using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumAdvance_Group2.Common;
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
            generalPage = loginPage.LoginDashBoard(Constant.Respos_SampleRepository, Constant.UsernameAdmin, Constant.PasswordAdmin);

            dataProfileManagerPage = generalPage.GotoDataProfileManagerPage();
            
            dataProfileManagerPage.VerifyPreDataProfile(Constant.PreSetDataProfile, dataProfileManagerPage.GetActualPreDataProfile());

            //post-condition
            dataProfileManagerPage.LogOut();
        }

        [TestMethod]
        public void DA_DP_TC067_Verify_that_Data_Profiles_are_listed_alphabetically()
        {
            generalPage = loginPage.LoginDashBoard(Constant.Respos_SampleRepository, Constant.UsernameAdmin, Constant.PasswordAdmin);

            dataProfileManagerPage = generalPage.GotoDataProfileManagerPage();
            
            dataProfileManagerPage.VerifyDataProfileInAlphabeticalOrder();

            //post-condition
            dataProfileManagerPage.LogOut();
        }

        [TestMethod]
        public void DA_DP_TC076_Verify_that_for_newly_created_data_profile_user_is_able_to_navigate_through_other_setting_pages_on_the_left_navigation_panel()
        {
            NewDataProfilePage newDataProfilePage;
            EditDataProfilePage editDataProfilePage;
            string dataProfileName = "TC76" + Constant.TimeSystem;

            generalPage = loginPage.LoginDashBoard(Constant.Respos_SampleRepository, Constant.UsernameAdmin, Constant.PasswordAdmin);

            dataProfileManagerPage = generalPage.GotoDataProfileManagerPage();

            newDataProfilePage = dataProfileManagerPage.GotoNewDataProfilePage();

            dataProfileManagerPage = newDataProfilePage.AddADataProfile(dataProfileName, Constant.ItemType, Constant.RelatedData);

            editDataProfilePage = dataProfileManagerPage.GotoEditDataProfilePage(dataProfileName);

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

            //post-condition
            dataProfileManagerPage = editDataProfilePage.GotoDataProfileManagerPage();
            dataProfileManagerPage.DeleteCreatedDataProfile(dataProfileName);
            dataProfileManagerPage.LogOut();
        }

        [TestMethod]
        public void DA_DP_TC085_Verify_that_user_is_able_to_change_the_level_of_sorting_amongst_fields_by_using_Up_and_Down_arrow()
        {
            NewDataProfilePage newDataProfilePage;
            string dataProfileName = "TC85" + Constant.TimeSystem;

            generalPage = loginPage.LoginDashBoard(Constant.Respos_SampleRepository, Constant.UsernameAdmin, Constant.PasswordAdmin);

            dataProfileManagerPage = generalPage.GotoDataProfileManagerPage();

            newDataProfilePage = dataProfileManagerPage.GotoNewDataProfilePage();

            newDataProfilePage.NavigateToSortField(dataProfileName, Constant.ItemType, Constant.RelatedData);

            newDataProfilePage.AddASortField(Constant.SortField_Source);

            newDataProfilePage.AddASortField(Constant.SortField_Location);

            newDataProfilePage.MoveLevelOfSortFieldlUp(Constant.SortField_Location);
            newDataProfilePage.VerifyMoveLevel(Constant.SortField_Location, newDataProfilePage.GetValueSortBy());

            newDataProfilePage.MoveLevelOfSortFieldDown(Constant.SortField_Location);
            newDataProfilePage.VerifyMoveLevel(Constant.SortField_Location, newDataProfilePage.GetValueThenBy());

            //post-condition
            newDataProfilePage.LogOut();
        }
    }
}