using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumAdvance_Group2.Common;

namespace SeleniumAdvance_Group2.TestCases
{
    [TestClass]
   public class PanelTestCases:TestBases
    {
        public void DA_PANEL_TC029()
        {
          loginpage=  OpenURL(Constant.DashboardURL);
           generalpage= loginpage.Login(Constant.userTrang, Constant.passTrang);
        }
    }
}
