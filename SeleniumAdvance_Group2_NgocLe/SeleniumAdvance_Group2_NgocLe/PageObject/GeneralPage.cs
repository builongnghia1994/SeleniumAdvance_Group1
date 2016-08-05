using OpenQA.Selenium;
using SeleniumAdvance_Group2.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;

namespace SeleniumAdvance_Group2.PageObject
{
    public class GeneralPage : CommonActions
    {
        private readonly By menuUser = By.XPath("//a[@href='#Welcome']");
        private readonly By itemLogOut = By.XPath("//a[@href='logout.do']");
        private readonly By menuAdminister = By.XPath("//a[@href='#Administer']");
        private readonly By itemDataProfile = By.XPath("//a[@href='profiles.jsp']");
        private readonly By itemPanel = By.XPath("//a[@href='panels.jsp']");

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
            for (int b = 0; b < allpages.Length; b++)
            {
                string currentpagexpath = "//ul/li/a[text()='" + allpages[b] + "']";
                Actions builder = new Actions(Constant.WebDriver);
                Actions hoverClick = builder.MoveToElement(FindElement(By.XPath(currentpagexpath)));
                hoverClick.Build().Perform();
                lastpage = By.XPath(currentpagexpath);
            }
            ClickControl(lastpage);
        }


        public void VerifyWelComeUser(string username)
        {
            VerifyText(username, menuUser);
        }


    }
}
