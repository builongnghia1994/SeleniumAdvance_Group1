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

        public DataProfileManagerPage GotoDataProfilePage()
        {
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

            ClickControl("global setting");
            ClickControl(control);
        }

        public void VerifyPageDisplayedBesideAnotherPage(string itemdisplayafter, string namepage)
        {
            WaitForControl(By.XPath("//div[@id='main-menu']/div/ul/li/a[text()='" + namepage + "']"), 3);

            int numberitemsmainmenu = CountItems("main page") - 2;
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


        public NewPage GotoNewPage()
        {

            SelectGlobalSetting("Add Page");
            return new NewPage();
        }

        public EditPage GotoEditPage(string namepage)
        {

            ClickControl(By.XPath("//div[@id='main-menu']/div/ul/li/a[text()='" + namepage + "']"));
            SelectGlobalSetting("Edit");
            return new EditPage();
        }


        public void DeletePage(string path)
        {
            GotoPage(path);
            SelectGlobalSetting("Delete");
        }

        public void VerifyAlertMessenge(string expected)
        {
            string actual = Constant.WebDriver.SwitchTo().Alert().Text;
            Assert.AreEqual(expected, actual);
        }




        public void VerifyPageNotExist(string way)
        {

            WaitForControl("user link", 5);
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
            Thread.Sleep(500);
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

                ClickControl(By.XPath(xpath));
                SelectGlobalSetting("Delete");
                AcceptAlert();

                Thread.Sleep(300);
                i = CountItems(By.XPath("//div[@id='main-menu']/div/ul/li/a")) - 3;
                Console.WriteLine("a" + i);
            }

        }


    }
}


