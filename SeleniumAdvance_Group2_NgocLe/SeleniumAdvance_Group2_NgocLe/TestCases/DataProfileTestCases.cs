using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumAdvance_Group2.Common;

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
            loginPageActions = OpenURL(Constant.DashboardURL);

            generalPage = loginPageActions.Login(respository_SampleRepository,username, password);

            dataProfileManagerPageActions = generalPage.GotoDataProfilePage();

            dataProfileManagerPageActions.VerifyPreDataProfile(Constant.preSetDataProfile, dataProfileManagerPageActions.GetActualPreDataPRofile());
        }

        [TestMethod]
        public void DA_DP_TC067_Verify_that_Data_Profiles_are_listed_alphabetically()
        {
            loginPageActions = OpenURL(Constant.DashboardURL);

            generalPage = loginPageActions.Login(respository_SampleRepository,username, password);

            dataProfileManagerPageActions = generalPage.GotoDataProfilePage();

            dataProfileManagerPageActions.VerifyPreDataProfileInAlphabeticalOrder();
        }
    }
}
