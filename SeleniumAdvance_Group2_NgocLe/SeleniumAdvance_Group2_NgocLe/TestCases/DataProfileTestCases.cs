using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumAdvance_Group2.Common;

namespace SeleniumAdvance_Group2.TestCases
{
    [TestClass]
    public class DataProfileTestCases: TestBases
    {
        [TestMethod]
        public void DA_DP_TC065_Verify_that_all_Preset_Data_Profiles_are_populated_correctly()
        {
            loginPage = OpenURL(Constant.DashboardURL);

            generalPage  = loginPage.Login("nghia.bui", "1");

            dataProfilePage.GotoDataProfilePage();
        }
    }
}
