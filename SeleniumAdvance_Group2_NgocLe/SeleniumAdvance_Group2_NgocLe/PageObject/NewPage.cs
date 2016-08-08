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

        private readonly By txtPageName = By.Id("name");
        private readonly By ddlParentName = By.Id("parent");
        private readonly By ddlDisplayAfter = By.Id("afterpage");
        private readonly By rdPublic = By.Id("ispublic");
        private readonly By ddlnumbercolum = By.Id("columnnumber");
        private readonly By btnOk = By.Id("OK");
        private readonly By menuitemsMainPage = By.XPath("//div[@id='main-menu']/div/ul/li[{0}]/a");

        private readonly By itemsMainPage = By.XPath("//div[@id='main-menu']/div/ul/li/a");



        public void CreadNewPage(string status, string pagename, string parentname, string afterpage, string numbercolum)

        {
            if (parentname == null)
            {
                parentname = Constant.parentname_newpage;
            }

            if (afterpage == null)
            {
                afterpage = Constant.pageafter_newpage;
            }
            if (numbercolum == null)
            {
                numbercolum = Constant.numbercolumn_newpage;
            }

            switch (status.ToLower())
            {
                case "public":
                    ClickControl(rdPublic);
                    break;
                default:
                    break;
            }

            TypeValue(txtPageName, pagename);
            SelectItemByDropdownList(ddlParentName, parentname);
            SelectItemByDropdownList(ddlnumbercolum, numbercolum);
            SelectItemByDropdownList(ddlDisplayAfter, afterpage);
            ClickControl(btnOk);


        }


        public void VerifyNameOfNewPageDisplayedBesidesOverviewPage(string namepage)
        {
            int numberitemsmainmenu = CountItems(itemsMainPage) - 2;
            for (int i = 1; i <= numberitemsmainmenu; i++)
            {

                string itemmenuMainPage = "//div[@id='main-menu']/div/ul/li[" + i + "]/a";
                By realitemMainpage = By.XPath(itemmenuMainPage);
                if (GetText(realitemMainpage).Equals("Overview"))

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
