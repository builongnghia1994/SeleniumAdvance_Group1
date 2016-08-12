using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumAdvance_Group2.Common;
using SeleniumAdvance_Group2.PageObject.LoginPage;

namespace SeleniumAdvance_Group2.TestCases
{
    [TestClass]
    public class DataProfileTestCases: TestBases
    {
        string username = "nghia.bui";
        string password = "1";
        private string respository_SampleRepository = "SampleRepository";

        [TestMethod]
        public void DA_DP_TC065_Verify_that_all_Preset_Data_Profiles_are_populated_correctly()
        {
            loginPageActions = new LoginPageActions();

            generalPageActions = loginPageActions.Login(respository_SampleRepository,username, password);

            dataProfileManagerPageActions = generalPageActions.GotoDataProfilePage();

            dataProfileManagerPageActions.VerifyPreDataProfile(Constant.preSetDataProfile, dataProfileManagerPageActions.GetActualPreDataPRofile());
        }

        [TestMethod]
        public void DA_DP_TC067_Verify_that_Data_Profiles_are_listed_alphabetically()
        {
            loginPageActions = new LoginPageActions();

            generalPageActions = loginPageActions.Login(respository_SampleRepository,username, password);

            dataProfileManagerPageActions = generalPageActions.GotoDataProfilePage();

            dataProfileManagerPageActions.VerifyDataProfileInAlphabeticalOrder();
        }

        [TestMethod]
        public void DA_DP_TC073_Verify_that_all_data_profile_types_are_listed_in_priority_order_under_Item_Type_dropped_down_menu()
        {
            loginPageActions = new LoginPageActions();

            generalPageActions = loginPageActions.Login(respository_SampleRepository, username, password);

            dataProfileManagerPageActions = generalPageActions.GotoDataProfilePage();

            newDataProfileActions = dataProfileManagerPageActions.GotoNewDataProfile();

            newDataProfileActions.VerifyDropdownlistDisplayByPriority(Constant.itemTypeValues, newDataProfileActions.GetItemTypeValues());
        }
    }
}
