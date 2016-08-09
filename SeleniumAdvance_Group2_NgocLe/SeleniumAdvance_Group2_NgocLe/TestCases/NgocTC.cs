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
            generalPage = loginPage.Login(Constant.Respository, Constant.userTrang, Constant.passTrang);
            generalPage.GotoPage("Trang/Trang1/Trang2");
        }


    }
}
