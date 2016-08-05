using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumAdvance_Group2.Common;


namespace SeleniumAdvance_Group2.PageObject
{
   public class NewPage:GeneralPage
    {
        


        private readonly By txtPageName = By.Id("name");
        private readonly By ddlParentName = By.Id("parent");
        private readonly By ddlDisplayAfter = By.Id("afterpage");
        private readonly By rdPublic = By.Id("ispublic");
        private readonly By btnOk = By.Id("OK");

        public void CreadNewPage(string status,string pagename, string parentyesno,string parentname, string afterpage)
        {
            TypeValue(txtPageName, pagename);
            //SelectItemByDropdownList(ddlParentName, parentname);
            //SelectItemByDropdownList(ddlDisplayAfter, afterpage);
            switch (status)
            {
                case "public":
                    ClickControl(rdPublic);
                    break;
                default:
                    break;      
            }
            switch(parentyesno)
            {
                case "parentyes":
                    SelectItemByDropdownList(ddlParentName, pagename);
                    break;
                default:
                    break;
            }
            switch(afterpage)
            {
                case
            }
            ClickControl(btnOk);
        }
    }
}
