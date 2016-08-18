using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumAdvance_Group2.Common;
using SeleniumAdvance_Group2.PageObject.General;

namespace SeleniumAdvance_Group2.PageObject.Panel
{
  public  class ChoosePanelPage:GeneralPage
    {
        public ChoosePanelPage()
        {
            Constant.ChoosePanelDictionary = ReadXML();
        }

        public NewPanelPage GoToNewPanelPage()
        {
            ClickControl("create new panel button");
            return new NewPanelPage();
        }
    }
}
