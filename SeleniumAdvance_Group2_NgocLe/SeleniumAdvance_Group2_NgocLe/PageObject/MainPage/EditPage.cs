using SeleniumAdvance_Group2.PageObject.General;
using SeleniumAdvance_Group2.PageObject.MainPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumAdvance_Group2.Common;
using System.Threading;

namespace SeleniumAdvance_Group2.PageObject.MainPage
{
  public  class EditPage: GeneralPage
    {
        public EditPage()
        {
            Constant.NewPageDictionary = ReadXML();
        }
        public GeneralPage EditAPage(string status, string pagename, string parentname, string afterpage, string numbercolum)

        {
            Thread.Sleep(500);// sleep to wait all elements ared loaded
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

            return new GeneralPage();
        }
    }
}
