using OpenQA.Selenium;
using SeleniumAdvance_Group2.PageObject.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
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
        public GeneralPage CreateNewPage(string status, string pagename, string parentname, string afterpage, string numbercolum)

        {
            switch (status.ToLower())
            {
                case "public":
                    ClickControl("public checkbox");
                    break;
                default:
                    break;
            }
            if (pagename != null)
            { TypeValue("page name textbox", pagename); }
            if (parentname != null)
            { SelectItemByDropdownList("parent name list", parentname); }
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
