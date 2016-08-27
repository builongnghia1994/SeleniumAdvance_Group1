using System;
using SeleniumAdvance_Group2.PageObject.General;
using SeleniumAdvance_Group2.Common;

namespace SeleniumAdvance_Group2.PageObject.MainPage
{
    public class NewPage : GeneralPage
    {
        public NewPage()
        {
            if (Constant.NewPageDictionary == null)
                Constant.NewPageDictionary = ReadXML();
        }
        public GeneralPage CreateNewPage(string statuspublic, string pagename, string parentname, string afterpage, string numbercolum, string level)
        {            
            if(statuspublic!=null&& statuspublic=="public")
            {
                ClickControl("public checkbox");
            }

            if (pagename != null)
            { TypeValue("page name textbox", pagename); }

            if (parentname != null)
            {
                if (level != null)
                {
                    //if pageparent has level that is equal to Overview item, there is no space in selected text in dropdown list parrentpage when selecting, and it means level now is 0. 
                    //Level 1 to up: pageparents are child of pages have level with equal level to Overview item(level 0)
                    //Level 1: there are 4 spaces before text of page parent in drpdownlist, and similar to other level, (level 2: 8 spaces.....)
                    int parentLevel = int.Parse(level);
                    string space = "    ";                      
                    for (int i = 1; i <= parentLevel; i++)
                    {
                        parentname = space + parentname;
                    }
                }
                SelectItemByDropdownList("parent name list", parentname);
            }

            if (numbercolum != null)
            { SelectItemByDropdownList("number column list", numbercolum); }

            if (afterpage != null)
            { SelectItemByDropdownList("page display after", afterpage); }

            ClickControl("OK button");
            WaitForPageLoad();
            return new GeneralPage();
        }

       
        
    }
}
