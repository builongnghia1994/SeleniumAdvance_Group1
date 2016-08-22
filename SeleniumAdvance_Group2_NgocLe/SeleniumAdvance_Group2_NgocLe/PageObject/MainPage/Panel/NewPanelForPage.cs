using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumAdvance_Group2.PageObject.General;
using SeleniumAdvance_Group2.Common;

namespace SeleniumAdvance_Group2.PageObject.MainPage.Panel
{
    public class NewPanelForPage : GeneralPage
    {
        public NewPanelForPage()
        {
            if (Constant.NewPanelDictionary == null)
                Constant.NewPanelDictionary = ReadXML();
        }

        public void AddNewPanel(string displayName, string series)
        {
            TypeValue("display name textbox", displayName);
            SelectItemByDropdownList("series list", series);
            ClickControl("ok button");
        }

        public PanelConfigurationPage GotoPanelConfigurationPageByAddNewPanel(string displayName, string series)
        {
            AddNewPanel(displayName, series);
            return new PanelConfigurationPage();
        }
    }
}
