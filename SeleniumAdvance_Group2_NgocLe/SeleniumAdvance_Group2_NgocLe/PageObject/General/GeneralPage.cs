using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumAdvance_Group2.PageObject.Login;
using SeleniumAdvance_Group2.PageObject.DataProfile;
using SeleniumAdvance_Group2.PageObject.Panel;
using SeleniumAdvance_Group2.PageObject.MainPage;
using SeleniumAdvance_Group2.PageObject.MainPage.Panel;
using SeleniumAdvance_Group2.Common;

namespace SeleniumAdvance_Group2.PageObject.General
{
    public class GeneralPage : CommonActions
    {
        public GeneralPage()
        {
            if (Constant.GeneralDictionary == null)
                Constant.GeneralDictionary = ReadXML();
        }
        public LoginPage LogOut()
        {
            WaitForPageLoad();
            if (Constant.Browser == "ie" || Constant.Browser == "chrome")
            {

                ClickControlByJS("user link");
                ClickControlByJS("log out link");
            }
            else
            {
                ClickControl("user link");
                ClickControl("log out link");
            }
            return new LoginPage();
        }

        public DataProfileManagerPage GotoDataProfileManagerPage()
        {
            if (Constant.Browser == "ie" || Constant.Browser == "chrome")
            {
                ClickControlByJS("administer link");
                ClickControlByJS("data profile link");
            }
            else
            {
                ClickControl("administer link");
                ClickControl("data profile link");
            }
            return new DataProfileManagerPage();
        }

        public PanelManagerPage GotoPanelManagerPage()
        {
            if (Constant.Browser == "ie" || Constant.Browser == "chrome")
            {
                ClickControlByJS("administer link");
                ClickControlByJS("panel link");
            }
            else
            {
                ClickControl("administer link");
                ClickControl("panel link");
            }
            return new PanelManagerPage();
        }

        public NewPanelPage GotoPanelPage()
        {
            PanelManagerPage panelManagerPage = GotoPanelManagerPage();
            return panelManagerPage.GoToPanelPage();
        }

        public void GotoPage(string path)
        {
            WaitForPageLoad();
            string[] allPages = path.Split('/');
            By lastPage = By.XPath("");
            string currentPageXpath = "//ul/li/a[text()='" + allPages[0] + "']";
            if (allPages.Length == 1)
            {
                //cover trường hợp tới 1 page chính nào đó mà k qua bất kì 1 page nào nữa
                lastPage = By.XPath(currentPageXpath);
                ClickControl(lastPage);
            }
            else
            {
                string next = string.Empty;

                //trường hợp nếu phải thông qua nhiều page
                for (int b = 1; b < allPages.Length; b++)
                {
                    Actions builder = new Actions(Constant.WebDriver);
                    Actions hoverClick = builder.MoveToElement(FindElement(By.XPath(currentPageXpath)));
                    hoverClick.Build().Perform();

                    next = "/following-sibling::ul/li/a[text()='" + allPages[b] + "']";
                    currentPageXpath = currentPageXpath + next;
                    lastPage = By.XPath(currentPageXpath);
                }
                if (Constant.Browser == "ie" || Constant.Browser == "chrome")
                {
                    ClickControlByJS(lastPage);
                }

                else
                    ClickControl(lastPage);
            }
        }

        public void VerifyWelComeUserDisplayed(string username)
        {
            VerifyTextFromControl(username, "user link");
        }

        public void SelectGlobalSetting(string settingname)
        {
            WaitForPageLoad();
            By control = By.XPath("//li/a[text()='" + settingname + "']");
            if (Constant.Browser == "ie" || Constant.Browser == "chrome")
            {
                ClickControlByJS("global setting");
                ClickControlByJS(control);
            }
            else
            {
                ClickControl("global setting");
                ClickControl(control);
            }
        }

        public void VerifyPageDisplayedBesideAnotherPage(string pageBefore, string namePage)
        {
            int numberItemsMainMenu = CountItems("main page") - 2;
            for (int i = 1; i <= numberItemsMainMenu; i++)
            {
                string itemMenuMainPage = "//div[@id='main-menu']/div/ul/li[" + i + "]/a";
                By realItemMainpage = By.XPath(itemMenuMainPage);
                if (GetText(realItemMainpage).Equals(pageBefore))
                {
                    string itemNamepage = "//div[@id='main-menu']/div/ul/li[" + (i + 1) + "]/a";
                    By realItemNamepage = By.XPath(itemNamepage);
                    VerifyText(namePage, realItemNamepage);
                    return;
                }
            }
        }

        public NewPage GotoNewPage()
        {

            SelectGlobalSetting("Add Page");
            WaitForPageLoad();
            return new NewPage();
        }

        public EditPage GotoEditPage(string namePage)
        {
            ClickControl(By.XPath("//div[@id='main-menu']/div/ul/li/a[text()='" + namePage + "']"));

            SelectGlobalSetting("Edit");

            return new EditPage();
        }

        public void SelectDeletePage(string path)
        {
            GotoPage(path);
            SelectGlobalSetting("Delete");
        }

        public void DeletePage(string path)
        {
            SelectDeletePage(path);
            AcceptAlert();


        }

        public void VerifyAlertMessage(string expected)
        {
            VerifyText(expected, GetTextFromAlertPopup().TrimEnd());
        }

        public void VerifyPageNotExist(string path)
        {
            WaitForPageLoad();
            string[] allPages = path.Split('/');
            By lastPage = By.XPath("");
            string currentPageXpath = "//ul/li/a[text()='" + allPages[0] + "']";

            if (allPages.Length == 1)
            {
                lastPage = By.XPath(currentPageXpath);
                VerifyControlNotExist(lastPage);
            }
            else
            {
                string next = string.Empty;

                for (int b = 1; b < allPages.Length; b++)
                {
                    next = "/following-sibling::ul/li/a[text()='" + allPages[b] + "']";
                    currentPageXpath = currentPageXpath + next;
                    lastPage = By.XPath(currentPageXpath);
                }
                VerifyControlNotExist(lastPage);
            }

        }

        public void DeleteAllPages()
        {
            WaitForPageLoad();
            int items = CountItems(By.XPath("//div[@id='main-menu']/div/ul/li/a"));
            string itemclasscurrent = string.Empty;
            string xpath = string.Empty;

            for (int i = items - 3; i >= 2;)
            {
                xpath = "//div[@id='main-menu']/div/ul/li[" + i + "]/a";
                itemclasscurrent = FindElement(By.XPath(xpath)).GetAttribute("class").ToString();
                while (itemclasscurrent.Equals("haschild"))
                {
                    Actions builder = new Actions(Constant.WebDriver);
                    Actions hoverClick = builder.MoveToElement(FindElement(By.XPath(xpath)));
                    hoverClick.Build().Perform();
                    string next = "/following-sibling::ul/li/a";
                    xpath = xpath + next;
                    itemclasscurrent = FindElement(By.XPath(xpath)).GetAttribute("class").ToString();
                }
                if (Constant.Browser.Equals("ie") || Constant.Browser.Equals("chrome"))
                {
                    ClickControlByJS(By.XPath(xpath));
                    SelectGlobalSetting("Delete");
                    IAlert alert = Constant.WebDriver.SwitchTo().Alert();
                    SendKeys.SendWait("{ENTER}");
                }
                else
                {
                    ClickControl(By.XPath(xpath));
                    SelectGlobalSetting("Delete");
                    AcceptAlert();
                }
                WaitForPageLoad();
                i = CountItems(By.XPath("//div[@id='main-menu']/div/ul/li/a")) - 3;
            }
        }

        public GeneralPage CreateNewPageFromGeneralPage(string status, string pagename, string parentname, string afterpage, string numbercolum, string level)
        {
            NewPage newPage = GotoNewPage();
            return newPage.CreateNewPage(status, pagename, parentname, afterpage, numbercolum, level);
        }

        public ChoosePanelPage GotoChoosePanelPage()
        {
            ClickControl("choose panel menu");
            return new ChoosePanelPage();
        }

        public void VerifyControlNotExistInGlobalSetting(string settingName)
        {
            WaitForPageLoad();
            By control = By.XPath("//li/a[text()='" + settingName + "']");
            VerifyControlNotExist(control);
        }

        public void VerifyPageNameDisplay(string namePage)
        {
            WaitForPageLoad();
            By control = By.XPath("//div[@id='main-menu']/div/ul/li/a[text()='" + namePage + "']");
            VerifyControlExist(control);
        }
    }
}


