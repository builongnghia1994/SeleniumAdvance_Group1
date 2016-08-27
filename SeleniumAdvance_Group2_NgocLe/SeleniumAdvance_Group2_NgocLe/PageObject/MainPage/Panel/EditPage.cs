using SeleniumAdvance_Group2.PageObject.General;
using SeleniumAdvance_Group2.Common;

namespace SeleniumAdvance_Group2.PageObject.MainPage
{
    public class EditPage : GeneralPage
    {
        public EditPage()
        {
            if (Constant.NewPageDictionary == null)
                Constant.NewPageDictionary = ReadXML();
        }
        public GeneralPage EditAPage(string status, string pagename, string parentname, string afterpage, string numbercolum, string level)

        {
            if (status != null && status == "public")
            {
                ClickControl("public checkbox");
            }

            if (pagename != null)
            { TypeValue("page name textbox", pagename); }

            if (parentname != null)
            {
                if (level != null)
                {
                    int parentLevel = int.Parse(level);
                    string space = "    ";//space=4 at level 1                        
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
