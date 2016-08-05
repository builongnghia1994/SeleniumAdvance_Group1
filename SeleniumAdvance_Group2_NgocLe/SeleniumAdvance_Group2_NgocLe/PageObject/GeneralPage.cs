using OpenQA.Selenium;
using SeleniumAdvance_Group2.Common;

namespace SeleniumAdvance_Group2.PageObject
{
    public class GeneralPage:CommonActions
    {
        public readonly By menuUser = By.XPath("//a[@href='#Welcome']");
        public readonly By itemLogOut = By.XPath("//a[@href='logout.do']");


        public LoginPage LogOut()
        {
            ClickControl(menuUser);
            ClickControl(itemLogOut);
            return new LoginPage();
        }


    }
}
