using OpenQA.Selenium;
using SeleniumAdvance_Group2.Common;
using OpenQA.Selenium.Support.UI;


namespace SeleniumAdvance_Group2.PageObject
{
    public class GeneralPage:CommonActions
    {
        public readonly By menuUser = By.XPath("//a[@href='#Welcome']");
        public readonly By itemLogOut = By.XPath("//a[@href='logout.do']");
        public readonly By itemAdminister = By.XPath("//a[href='#Administer']");

        public LoginPage LogOut()
        {
            ClickControl(menuUser);
            ClickControl(itemLogOut);
            return new LoginPage();
        }

        public void GotoPage(string parentpage, string childpage)
        {
            By control = By.XPath("//li/a[contains(.,'" + parentpage + "')]");
            switch (childpage)
            {
                case "":
                    break;
                default:
                    new SelectElement(FindElement(control)).SelectByText(childpage);
                    break;
            }
        }
        
    }
}
