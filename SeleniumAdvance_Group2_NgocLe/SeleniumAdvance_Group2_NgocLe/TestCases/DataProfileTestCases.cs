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
            generalPage = loginPage.LoginDashBoard(Constant.Respos_SampleRepository, Constant.Username_nghia, Constant.Password);

            dataProfileManagerPage = generalPage.GotoDataProfileManagerPage();

            //vp
            dataProfileManagerPage.VerifyPreDataProfile(Constant.PreSetDataProfile, dataProfileManagerPage.GetActualPreDataProfile());

            //post-condition
            generalPage.LogOut();
        }

        [TestMethod]
        public void DA_DP_TC067_Verify_that_Data_Profiles_are_listed_alphabetically()
        {
            generalPage = loginPage.LoginDashBoard(Constant.Respos_SampleRepository, Constant.Username_nghia, Constant.Password);

            dataProfileManagerPage = generalPage.GotoDataProfileManagerPage();

            //vp
            dataProfileManagerPage.VerifyDataProfileInAlphabeticalOrder();

            //post-condition
            generalPage.LogOut();
        }

        [TestMethod]
        public void DA_DP_TC076_Verify_that_for_newly_created_data_profile_user_is_able_to_navigate_through_other_setting_pages_on_the_left_navigation_panel()
        {
            NewDataProfilePage newDataProfilePage;
            EditDataProfilePage editDataProfilePage;

            generalPage = loginPage.LoginDashBoard(Constant.Respos_SampleRepository, Constant.Username_nghia, Constant.Password);

            dataProfileManagerPage = generalPage.GotoDataProfileManagerPage();

            newDataProfilePage = dataProfileManagerPage.GotoNewDataProfilePage();

            dataProfileManagerPage = newDataProfilePage.AddADataProfile(Constant.NameOfDataProfile, Constant.ItemType, Constant.RelatedData);

            editDataProfilePage = dataProfileManagerPage.GotoEditDataProfilePage(Constant.NameOfDataProfile);

            editDataProfilePage.ClickTab("display fields tab");
            //vp
            editDataProfilePage.VerifyPageDisplay("Display Fields");

            editDataProfilePage.ClickTab("sort fields tab");
            //vp
            editDataProfilePage.VerifyPageDisplay("Sort Fields");

            editDataProfilePage.ClickTab("filter fields tab");
            //vp
            editDataProfilePage.VerifyPageDisplay("Filter Fields");

            editDataProfilePage.ClickTab("statistic fields tab");
            //vp
            editDataProfilePage.VerifyPageDisplay("Statistic Fields");

            editDataProfilePage.ClickTab("display sub fields tab");
            //vp
            editDataProfilePage.VerifyPageDisplay("Display Sub-Fields");

            editDataProfilePage.ClickTab("sort sub fields tab");
            //vp
            editDataProfilePage.VerifyPageDisplay("Sort Sub-Fields");

            editDataProfilePage.ClickTab("filter sub fields tab");
            //vp
            editDataProfilePage.VerifyPageDisplay("Filter Sub-Fields");

            editDataProfilePage.ClickTab("statistic sub fields tab");
            //vp
            editDataProfilePage.VerifyPageDisplay("Statistic Sub-Fields");

            //post-condition
            generalPage.LogOut();
        }

        [TestMethod]
        public void DA_DP_TC085_Verify_that_user_is_able_to_change_the_level_of_sorting_amongst_fields_by_using_Up_and_Down_arrow()
        {
            NewDataProfilePage newDataProfilePage;

            generalPage = loginPage.LoginDashBoard(Constant.Respos_SampleRepository, Constant.Username_nghia, Constant.Password);

            dataProfileManagerPage = generalPage.GotoDataProfileManagerPage();

            newDataProfilePage = dataProfileManagerPage.GotoNewDataProfilePage();

            newDataProfilePage.NavigateToSortField(Constant.NameOfDataProfile, Constant.ItemType, Constant.RelatedData);

            newDataProfilePage.AddASortField(Constant.SortField_Source);

            newDataProfilePage.AddASortField(Constant.SortField_Location);

            newDataProfilePage.MoveLevelOfSortFieldlUp(Constant.SortField_Location);

            //vp
            newDataProfilePage.VerifyMoveLevel(Constant.SortField_Location, newDataProfilePage.GetValueSortBy());

            newDataProfilePage.MoveLevelOfSortFieldDown(Constant.SortField_Location);
            //vp
            newDataProfilePage.VerifyMoveLevel(Constant.SortField_Location, newDataProfilePage.GetValueThenBy());

            //post-condition
            generalPage.LogOut();
        }
    }
}
