using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumAdvance_Group2.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using SeleniumAdvance_Group2.PageObject.Login;
using SeleniumAdvance_Group2.PageObject.DataProfile;
using SeleniumAdvance_Group2.TestCases;
using SeleniumAdvance_Group2.PageObject.Panel;
using SeleniumAdvance_Group2.PageObject.MainPage;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;


namespace SeleniumAdvance_Group2.PageObject.General
{
    public class GeneralPage : CommonActions
    {
        public GeneralPage()
        {
            Constant.GeneralDictionary = ReadXML();
        }
        public LoginPage LogOut()
        {
            Thread.Sleep(1000); //wait to logout button is loaded
            if (Constant.Browser == "ie")
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
            Thread.Sleep(500);
            if (Constant.Browser == "ie")
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
            if (Constant.Browser == "ie")
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

        public void GotoPage(string way)
        {
            WaitForControl("user link", Constant.timeout);
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
                if (Constant.Browser == "ie")
                { ClickControlByJS(lastpage); }
                else
                    ClickControl(lastpage);
            }
        }

        public void VerifyWelComeUserDisplayed(string username)
        {
            VerifyTextFromControl(username, "user link");
        }

        public void SelectGlobalSetting(string settingname)
        {
            By control = By.XPath("//li/a[text()='" + settingname + "']");
            //wait for element display
            Thread.Sleep(1000);
            if (Constant.Browser == "ie")
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

        public void VerifyPageDisplayedBesideAnotherPage(string itemdisplayafter, string namepage)
        {
            //WaitForControl(By.XPath("//div[@id='main-menu']/div/ul/li/a[text()='" + namepage + "']"), 10);
            Thread.Sleep(500);//wait to element of page just created is loaded
            int numberitemsmainmenu = CountItems("main page") - 2;
            for (int i = 1; i <= numberitemsmainmenu; i++)
            {
                string itemmenuMainPage = "//div[@id='main-menu']/div/ul/li[" + i + "]/a";
                By realitemMainpage = By.XPath(itemmenuMainPage);
                if (GetText(realitemMainpage).Equals(itemdisplayafter))

                {
                    string itemnamepage = "//div[@id='main-menu']/div/ul/li[" + (i + 1) + "]/a";
                    By realitemnamepage = By.XPath(itemnamepage);
                    VerifyText(namepage, realitemnamepage);
                }
            }
        }

        public NewPage GotoNewPage()
        {
            Thread.Sleep(1000);//wait to page loaded
            SelectGlobalSetting("Add Page");

            return new NewPage();
        }

        public EditPage GotoEditPage(string namepage)
        {
            Thread.Sleep(1000); //wait to page just created is load
            ClickControl(By.XPath("//div[@id='main-menu']/div/ul/li/a[text()='" + namepage + "']"));
            SelectGlobalSetting("Edit");
            return new EditPage();
        }

        public void DeletePage(string path)
        {
            GotoPage(path);
            SelectGlobalSetting("Delete");
        }

        public void VerifyAlertMessage(string expected)
        {
            Console.WriteLine(GetTextFromAlertPopup().TrimEnd());
            VerifyText(expected, GetTextFromAlertPopup().TrimEnd());
        }

        public void VerifyPageNotExist(string way)
        {
            WaitForControl("user link", Constant.timeout);
            string[] allpages = way.Split('/');
            By lastpage = By.XPath("");
            string currentpagexpath = "//ul/li/a[text()='" + allpages[0] + "']";
            if (allpages.Length == 1)
            {
                lastpage = By.XPath(currentpagexpath);
                Assert.IsFalse(DoesControlExist(lastpage));
            }
            else
            {
                for (int b = 1; b < allpages.Length; b++)
                {
                    string next = "/following-sibling::ul/li/a[text()='" + allpages[b] + "']";
                    currentpagexpath = currentpagexpath + next;
                    lastpage = By.XPath(currentpagexpath);
                }
                Assert.IsFalse(DoesControlExist(lastpage));
            }
        }

        public void DeleteAllPages()
        {
            Thread.Sleep(500);// sleep to wait all elements are stable to count
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
                if (Constant.Browser.Equals("ie"))
                {
                    ClickControlByJS(By.XPath(xpath));
                    SelectGlobalSetting("Delete");
                    AcceptAlert();
                }
                else
                {
                    ClickControl(By.XPath(xpath));
                    SelectGlobalSetting("Delete");
                    AcceptAlert();
                }

                Thread.Sleep(500); // sleep to wait elements are updated to count a gain
                i = CountItems(By.XPath("//div[@id='main-menu']/div/ul/li/a")) - 3;
                Console.WriteLine("a" + i);
            }
        }

        public void DeletePagesJustCreated(string namepageparrent)
        {
            string itemclasscurrent = string.Empty;
            string xpath = string.Empty;
            xpath = "//div[@id='main-menu']/div/ul/li/a[text()='" + namepageparrent + "']";
            while (DoesControlExist(By.XPath(xpath)))
            {
                string xpath2 = xpath;
                itemclasscurrent = FindElement(By.XPath(xpath2)).GetAttribute("class");
                while (itemclasscurrent.Equals("haschild") || itemclasscurrent.Equals("active haschild"))
                {
                    Actions builder = new Actions(Constant.WebDriver);
                    Actions hoverClick = builder.MoveToElement(FindElement(By.XPath(xpath2)));
                    hoverClick.Build().Perform();
                    string next = "/following-sibling::ul/li/a";
                    xpath2 = xpath2 + next;
                    itemclasscurrent = FindElement(By.XPath(xpath2)).GetAttribute("class").ToString();
                }
                if (Constant.Browser.Equals("ie"))
                {
                    ClickControlByJS(By.XPath(xpath2));
                    SelectGlobalSetting("Delete");
                    AcceptAlert();
                }
                else
                {
                    Console.Write(xpath2);
                    ClickControl(By.XPath(xpath2));
                    SelectGlobalSetting("Delete");
                    AcceptAlert();
                    Thread.Sleep(500);
                }
            }
        }

        public GeneralPage CreateNewPageFromGeneralPage(string status, string pagename, string parentname, string afterpage, string numbercolum)
        {
            NewPage newPage = GotoNewPage();
            return newPage.CreateNewPage(status, pagename, parentname, afterpage, numbercolum);
        }

        public ChoosePanelPage GotoChoosePanelPage()
        {
            ClickControl("choose panel menu");
            return new ChoosePanelPage();
        }
    }
}


