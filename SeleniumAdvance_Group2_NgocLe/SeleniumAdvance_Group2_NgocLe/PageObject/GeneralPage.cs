using OpenQA.Selenium;
using SeleniumAdvance_Group2.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System;



namespace SeleniumAdvance_Group2.PageObject
{
    public class GeneralPage:CommonActions
    {
        public readonly By menuUser = By.XPath("//a[@href='#Welcome']");
        public readonly By itemLogOut = By.XPath("//a[@href='logout.do']");
        public readonly By menuAdminister = By.XPath("//a[@href='#Administer']");
        public readonly By itemDataProfile = By.XPath("//a[@href='profiles.jsp']");
        public readonly By itemPanel = By.XPath("//a[@href='panels.jsp']");

        public LoginPage LogOut()
        {
            ClickControl(menuUser);
            ClickControl(itemLogOut);
            return new LoginPage();
        }

        public void GotoDataProfilePage()
        {
            ClickControl(menuAdminister);
            ClickControl(itemPanel);
        }

        public PanelManagerPage GotoPanelManagerPage()
        {
            ClickControl(menuAdminister);
            ClickControl(itemDataProfile);
            return new PanelManagerPage();
        }

        public void GotoPage(string way)
        {
            WaitForControl(menuUser, 5);
            string[] a = way.Split('/');
            By tam=By.XPath("");
            for (int b=0;b< a.Length; b++)
            {
                Actions builder = new Actions(Constant.WebDriver);
                Actions hoverClick = builder.MoveToElement(FindElement(By.XPath("//li/a[contains(.,'" + a[b] + "')]")));
                hoverClick.Build().Perform();
                tam = By.XPath("//li/a[contains(.,'" + a[b] + "')]");
            }

            ClickControl(tam);

        }

        public void VerifyWelComeUser(string username)
        {
            Assert.IsTrue(GetText(menuUser).Equals(username));
        }

    }
}
