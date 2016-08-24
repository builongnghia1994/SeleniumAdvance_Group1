using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumAdvance_Group2.Common;
using SeleniumAdvance_Group2.PageObject.General;

namespace SeleniumAdvance_Group2.PageObject.MainPage.Panel
{
    public class SelectFolderPage : GeneralPage
    {
        public SelectFolderPage()
        {
            if (Constant.SelectFolderPageDictionary == null)
                Constant.SelectFolderPageDictionary = ReadXML();
        }

        public PanelConfigurationPage GotoPanelConfigurationPageAfterSelectFolder(string path)
        {
            GotoFolder(path);
            ClickControl("ok button");
            return new PanelConfigurationPage();
        }


    }
}
