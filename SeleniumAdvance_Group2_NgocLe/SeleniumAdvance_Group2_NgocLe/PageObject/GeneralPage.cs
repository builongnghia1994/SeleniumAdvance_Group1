using OpenQA.Selenium;
using SeleniumAdvance_Group2.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;

namespace SeleniumAdvance_Group2.PageObject
{
    public class GeneralPage:CommonActions
    {
        private readonly By menuUser = By.XPath("//a[@href='#Welcome']");
        private readonly By itemLogOut = By.XPath("//a[@href='logout.do']");
        private readonly By menuAdminister = By.XPath("//a[@href='#Administer']");
        private readonly By itemDataProfile = By.XPath("//a[@href='profiles.jsp']");
        private readonly By itemPanel = By.XPath("//a[@href='panels.jsp']");
        private readonly By menuGlobalSetting = By.XPath("//li[@class='mn-setting']/a");


        private readonly By txtPageName = By.Id("name");
        private readonly By rdIsPublic = By.Id("ispublic");
        private readonly By drdparentname = By.Id("parent");
        private readonly By drdafterpage = By.Id("afterpage");
        private readonly By drdnumberclm = By.Id("columnnumber");
        private readonly By btnOK = By.Id("OK");







        public LoginPage LogOut()
        {
            ClickControl(menuUser);
            ClickControl(itemLogOut);
            return new LoginPage();
        }

        public DataProfilePage GotoDataProfilePage()
        {
            ClickControl(menuAdminister);
            ClickControl(itemDataProfile);
            return new DataProfilePage();
        }

        public PanelManagerPage GotoPanelManagerPage()
        {
            ClickControl(menuAdminister);
            ClickControl(itemPanel);
            return new PanelManagerPage();
        }

        public PanelPage GotoPanelPage()
        {
            PanelManagerPage panelManagerPage = GotoPanelManagerPage();
            return panelManagerPage.GoToPanelPage();
        }

        public void GotoPage(string way)
        {
            WaitForControl(menuUser, 5);
            string[] allpages = way.Split('/');
            By lastpage = By.XPath("");
            int b=0;
            string currentpagexpath = "//ul/li/a[text()='" + allpages[b] + "']";

            if (allpages.Length==1)
            {
                //cover trường hợp tới 1 page chính nào đó mà k qua bất kì 1 page nào nữa
                lastpage = By.XPath(currentpagexpath);
                ClickControl(lastpage);
            }
            else
            {
                //trường hợp nếu phải thông qua nhiều page
            for (b=0;(b+1)< allpages.Length; b++)
            {       
                Actions builder = new Actions(Constant.WebDriver);
                Actions hoverClick = builder.MoveToElement(FindElement(By.XPath(currentpagexpath)));
                hoverClick.Build().Perform();
                string next = "/following-sibling::ul/li/a[text()='" + allpages[b+1] + "']";
                currentpagexpath = currentpagexpath + next;
                lastpage = By.XPath(currentpagexpath);
            }
                ClickControl(lastpage);
            }
        }

        public void VerifyWelComeUser(string username)
        {
            VerifyText(menuUser, username);
        }

        public void VerifyText(By element, string expectedText)
        {
            string actualText = GetText(element);
            Assert.AreEqual(expectedText, actualText);
        }





        public void SelectGlobalSetting(string settingname)
        {
            By itemGlobal = By.XPath("//li/a[text()='"+settingname+"']");
            ClickControl(menuGlobalSetting);
            ClickControl(itemGlobal);
        }
        public void DeletePage(string pagelink)
        {
            string[] allpages = pagelink.Split('/');
            string deletepage = allpages[allpages.Length - 1];

            string childpage = "//li[@class='haschild']/a[text()='" + deletepage + "']//following-sibling::ul//li[@class!='haschild']";
            GotoPage(pagelink);
            SelectGlobalSetting("Delete");
            Constant.WebDriver.SwitchTo().Alert().Accept();
        }
 

    }
}
