using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SeleniumAdvance_Group2.TestCases
{
    [TestClass]
    public class DataProfileTestCases: TestBases
    {
        [TestMethod]
        public void DA_DP_TC065_Verify_that_all_Preset_Data_Profiles_are_populated_correctly()
        {
            loginpage.Login();

            dataProfilePage.GotoDataProfilePage();
        }
    }
}
