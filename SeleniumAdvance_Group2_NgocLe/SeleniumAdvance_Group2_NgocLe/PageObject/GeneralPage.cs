using OpenQA.Selenium;
using SeleniumAdvance_Group2.Common;

namespace SeleniumAdvance_Group2.PageObject
{
    public class GeneralPage:CommonActions
    {
        public readonly By _menuUser = By.XPath("//a[@href='#Welcome']");
        public readonly By _itemLogOut = By.XPath("//a[@href='logout.do']");

        public IWebElement ItemLogOut
        { get { return Constant.WebDriver.FindElement(_itemLogOut); } }
        public IWebElement MenuUser
        { get { return Constant.WebDriver.FindElement(_menuUser); } }


        public LoginPage LogOut()
        {
            MenuUser.Click();
            ItemLogOut.Click();
            return new LoginPage();
        }


    }
}
