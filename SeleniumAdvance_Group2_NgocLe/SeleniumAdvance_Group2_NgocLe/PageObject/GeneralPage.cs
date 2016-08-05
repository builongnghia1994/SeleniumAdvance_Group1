using OpenQA.Selenium;
using System;
using SeleniumAdvance_Group2.Common;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace SeleniumAdvance_Group2.PageObject
{
    public class GeneralPage:CommonActions
    {
        public readonly By menuUser = By.XPath("//a[@href='#Welcome']");
        public readonly By itemLogOut = By.XPath("//a[@href='logout.do']");
        public readonly By menuAdminister = By.XPath("//a[href='#Administer']");
        public readonly By itemDataProfile = By.XPath("//a[@href='profiles.jsp']");
        

        public LoginPage LogOut()
        {
            ClickControl(menuUser);
            ClickControl(itemLogOut);
            return new LoginPage();
        }



        public LoginPage Logoutupdage ()
        {            
            Actions Action = new Actions(Constant.WebDriver);
            Action.MoveToElement(FindElement(menuUser)).Perform();
            WebDriverWait wait = new WebDriverWait(Constant.WebDriver, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(itemLogOut));
            ClickControl(itemLogOut);
            return new LoginPage();
        }

       
    }
}
