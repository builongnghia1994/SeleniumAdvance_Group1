using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAdvance_Group2.PageObject.MainPage.NewPage
{
    class NewPageUI
    {
        public static readonly By txtPageName = By.Id("name");
        public static readonly By ddlParentName = By.Id("parent");
        public static readonly By ddlDisplayAfter = By.Id("afterpage");
        public static readonly By rdPublic = By.Id("ispublic");
        public static readonly By ddlnumbercolum = By.Id("columnnumber");
        public static readonly By btnOk = By.Id("OK");
        public static readonly By menuitemsMainPage = By.XPath("//div[@id='main-menu']/div/ul/li[{0}]/a");

        public static readonly By itemsMainPage = By.XPath("//div[@id='main-menu']/div/ul/li/a");
    }
}
