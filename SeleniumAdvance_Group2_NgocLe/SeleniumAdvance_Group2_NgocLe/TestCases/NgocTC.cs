using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumAdvance_Group2.Common;

namespace SeleniumAdvance_Group2.TestCases
{
    [TestClass]
    public class NgocTC : TestBases
    {
        [TestMethod]
        public void NgocTC01()
        {

            loginPage = OpenURL(Constant.DashboardURL);
            generalPage = loginPage.Login(Constant.userTrang, Constant.passTrang);
            generalPage.GlobalSetting("Add Page");
            generalPage.CreatePage("hihi", "public", "Select parent", "2", "Overview");
            Console.Read();
        }


    }
}
