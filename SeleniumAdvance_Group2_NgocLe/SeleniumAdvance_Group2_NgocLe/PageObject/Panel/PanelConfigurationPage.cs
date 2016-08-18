using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumAdvance_Group2.Common;
using SeleniumAdvance_Group2.PageObject.General;

namespace SeleniumAdvance_Group2.PageObject.Panel
{
    public class PanelConfigurationPage : GeneralPage
    {
        public PanelConfigurationPage()
        {
            Constant.PanelConfigurationDictionary = ReadXML();
        }

        public GeneralPage CreatePanelConfiguration(string page, string height, string folder)
        {
            if (page != null)
                SelectItemByDropdownList("page list", page);
            if (height != null)
                TypeValue("height textbox", height);
            if (folder != null)
                TypeValue("folder textbox", folder);
            ClickControl("ok button");
            return new GeneralPage();
        }



    }
}
