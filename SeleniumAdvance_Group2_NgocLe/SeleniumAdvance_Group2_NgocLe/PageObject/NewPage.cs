using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumAdvance_Group2.Common;


namespace SeleniumAdvance_Group2.PageObject
{
    public class NewPage : GeneralPage
    {

        public readonly By txtPageName = By.Id("name");
        public readonly By ddlParentName = By.Id("parent");
        public readonly By ddlDisplayAfter = By.Id("afterpage");
        public readonly By rdPublic = By.Id("ispublic");
        public readonly By ddlnumbercolum = By.Id("columnnumber");
        public readonly By btnOk = By.Id("OK");
        public readonly By menuitemsMainPage = By.XPath("//div[@id='main-menu']/div/ul/li[{0}]/a");

        private readonly By itemsMainPage = By.XPath("//div[@id='main-menu']/div/ul/li/a");



        public void CreadNewPage(string status, string pagename, string parentname, string afterpage, string numbercolum)

        {
         

            switch (status.ToLower())
            {
                case "public":
                    ClickControl(rdPublic);
                    break;
                default:
                    break;
            }
            if (pagename !=null)
            {TypeValue(txtPageName, pagename); }
            if (parentname != null)
            { SelectItemByDropdownList(ddlParentName, parentname); }
            if (numbercolum != null)
            { SelectItemByDropdownList(ddlnumbercolum, numbercolum); }
            if (afterpage != null)
            { SelectItemByDropdownList(ddlDisplayAfter, afterpage); }
            ClickControl(btnOk);


        }


        public void VerifyNameOfNewPageDisplayedBesidesSpecificItemDisplayAfter(string itemdisplayafter, string namepage)
        {
            int numberitemsmainmenu = CountItems(itemsMainPage) - 2;
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
