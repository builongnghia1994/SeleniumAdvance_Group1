using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAdvance_Group2.PageObject.GeneralPage
{
    public class GeneralPageUI

    {
        public static readonly By menuUser = By.XPath("//a[@href='#Welcome']");
        public static readonly By itemLogOut = By.XPath("//a[@href='logout.do']");
        public static readonly By menuAdminister = By.XPath("//a[@href='#Administer']");
        public static readonly By itemDataProfile = By.XPath("//a[@href='profiles.jsp']");
        public static readonly By itemPanel = By.XPath("//a[@href='panels.jsp']");

        public static readonly By menuGlobalSetting = By.XPath("//li[@class='mn-setting']/a[@href='javascript:void(0);']");
        public static readonly By itemAddPage = By.XPath("//a[@class='add' and text()='Add Page']");

        public static readonly By txtPageName = By.Id("name");
        public static readonly By rdIsPublic = By.Id("ispublic");
        public static readonly By drdparentname = By.Id("parent");
        public static readonly By drdafterpage = By.Id("afterpage");
        public static readonly By drdnumberclm = By.Id("columnnumber");
        public static readonly By btnOK = By.Id("OK");

        public static readonly By menuitemsMainPage = By.XPath("//div[@id='main-menu']/div/ul/li[{0}]/a");
        public static readonly By itemsMainPage = By.XPath("//div[@id='main-menu']/div/ul/li/a");
    }
}
