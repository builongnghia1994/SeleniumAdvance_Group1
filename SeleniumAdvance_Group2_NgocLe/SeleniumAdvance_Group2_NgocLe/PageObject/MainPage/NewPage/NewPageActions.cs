using OpenQA.Selenium;
using SeleniumAdvance_Group2.PageObject.GeneralPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAdvance_Group2.PageObject.MainPage.NewPage
{
    public class NewPageActions : GeneralPageActions
    {
        public void CreadNewPage(string status, string pagename, string parentname, string afterpage, string numbercolum)

        {
            switch (status.ToLower())
            {
                case "public":
                    ClickControl(NewPageUI.rdPublic);
                    break;
                default:
                    break;
            }
            if (pagename != null)
            { TypeValue(NewPageUI.txtPageName, pagename); }
            if (parentname != null)
            { SelectItemByDropdownList(NewPageUI.ddlParentName, parentname); }
            if (numbercolum != null)
            { SelectItemByDropdownList(NewPageUI.ddlnumbercolum, numbercolum); }
            if (afterpage != null)
            { SelectItemByDropdownList(NewPageUI.ddlDisplayAfter, afterpage); }
            ClickControl(NewPageUI.btnOk);


        }

        public void VerifyNameOfNewPageDisplayedBesidesSpecificItemDisplayAfter(string itemdisplayafter, string namepage)
        {
            int numberitemsmainmenu = CountItems(NewPageUI.itemsMainPage) - 2;
            for (int i = 1; i <= numberitemsmainmenu; i++)
            {

                string itemmenuMainPage = "//div[@id='main-menu']/div/ul/li[" + i + "]/a";
                By realitemMainpage = By.XPath(itemmenuMainPage);
                if (GetText(realitemMainpage).Equals(itemdisplayafter))

                {
                    string itemnamepage = "//div[@id='main-menu']/div/ul/li[" + (i + 1) + "]/a";
                    By realitemnamepage = By.XPath(itemnamepage);
                    string real = GetText(realitemnamepage);
                    VerifyText(namepage, realitemnamepage);

                }
            }

        }
    }
}
