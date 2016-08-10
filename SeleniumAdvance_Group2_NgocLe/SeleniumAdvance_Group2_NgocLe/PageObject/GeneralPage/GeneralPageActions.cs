using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumAdvance_Group2.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using SeleniumAdvance_Group2.PageObject.LoginPage;
using SeleniumAdvance_Group2.PageObject.DataProfilePage.DataProfileManagerPage;
using SeleniumAdvance_Group2.PageObject.MainPage.NewPage;
using SeleniumAdvance_Group2.TestCases;
using SeleniumAdvance_Group2.PageObject.PanelPage.PanelManagerPage;
using SeleniumAdvance_Group2.PageObject.PanelPage;

namespace SeleniumAdvance_Group2.PageObject.GeneralPage
{
    public class GeneralPageActions : CommonActions
    {
        public LoginPageActions LogOut()
        {
            if (Constant.Browser == "ie")
            {

                ClickControlByJS(GeneralPageUI.menuUser);
                ClickControlByJS(GeneralPageUI.itemLogOut);
            }
            else
            {
                ClickControl(GeneralPageUI.menuUser);
                ClickControl(GeneralPageUI.itemLogOut);
            }
            return new LoginPageActions();
        }

        public DataProfileManagerPageActions GotoDataProfilePage()
        {
            if (Constant.Browser == "ie")
            {

                ClickControlByJS(GeneralPageUI.menuAdminister);
                ClickControlByJS(GeneralPageUI.itemDataProfile);
            }
            else
            {
                ClickControl(GeneralPageUI.menuAdminister);
                ClickControl(GeneralPageUI.itemDataProfile);
            }

            return new DataProfileManagerPageActions();
        }

        public PanelManagerPageActions GotoPanelManagerPage()
        {


            if (Constant.Browser == "ie")
            {
                ClickControlByJS(GeneralPageUI.menuAdminister);
                ClickControlByJS(GeneralPageUI.itemPanel);
            }

            else
            {
                ClickControl(GeneralPageUI.menuAdminister);
                ClickControl(GeneralPageUI.itemPanel);
            }

            return new PanelManagerPageActions();
        }

        public NewPanelPageActions GotoPanelPage()
        {
            PanelManagerPageActions panelManagerPage = GotoPanelManagerPage();
            return panelManagerPage.GoToPanelPage();
        }

        public void GotoPage(string way)
        {
            WaitForControl(GeneralPageUI.menuUser, 5);
            string[] allpages = way.Split('/');
            By lastpage = By.XPath("");
            string currentpagexpath = "//ul/li/a[text()='" + allpages[0] + "']";

            if (allpages.Length == 1)
            {
                //cover trường hợp tới 1 page chính nào đó mà k qua bất kì 1 page nào nữa
                lastpage = By.XPath(currentpagexpath);
                ClickControl(lastpage);
            }
            else
            {
                //trường hợp nếu phải thông qua nhiều page
                for (int b = 1; b < allpages.Length; b++)
                {
                    Actions builder = new Actions(Constant.WebDriver);
                    Actions hoverClick = builder.MoveToElement(FindElement(By.XPath(currentpagexpath)));
                    hoverClick.Build().Perform();
                    string next = "/following-sibling::ul/li/a[text()='" + allpages[b] + "']";
                    currentpagexpath = currentpagexpath + next;
                    lastpage = By.XPath(currentpagexpath);
                }
                ClickControl(lastpage);
            }
        }

        public void VerifyWelComeUserDisplayed(string username)
        {
            VerifyText(username, GeneralPageUI.menuUser);
        }


        public void GlobalSetting(string settingname)
        {
            By control = By.XPath("//li/a[text()='" + settingname + "']");
            ClickControl(GeneralPageUI.menuGlobalSetting);
            ClickControl(control);
        }

        public void VerifyPageDisplayedBesideAnotherPage(string itemdisplayafter, string namepage)
        {
            int numberitemsmainmenu = CountItems(GeneralPageUI.itemsMainPage) - 2;
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

     
        public NewPageActions GotoNewPage()
        {
            GlobalSetting("Add Page");
            return new NewPageActions();
        }
    }
}
