using SeleniumAdvance_Group2.PageObject.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumAdvance_Group2.PageObject.Panel;
using SeleniumAdvance_Group2.Common;

namespace SeleniumAdvance_Group2.PageObject.Panel
{
    public class PanelManagerPage : GeneralPage
    {
        public PanelManagerPage()
        {
            Constant.PanelManagerDictionary = ReadXML();
        }
        public NewPanelPage GoToPanelPage()
        {
            ClickControl("add new link");
            return new NewPanelPage();
        }
    }
}
