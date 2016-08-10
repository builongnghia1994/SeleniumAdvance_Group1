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

            loginPageActions = OpenURL(Constant.DashboardURL);
            generalPageActions = loginPageActions.Login(Constant.Respository, Constant.userTrang, Constant.passTrang);
            generalPageActions.GotoPage("Trang/Trang1/Trang2");
        }


    }
}
