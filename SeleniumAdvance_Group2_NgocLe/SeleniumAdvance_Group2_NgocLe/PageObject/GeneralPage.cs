using OpenQA.Selenium;
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

        public void GotoDataProfilePage()
        {
            ClickControl(menuAdminister);
            ClickControl(itemDataProfile);
        }

        public void GotoPanelPage()
        {
            ClickControl(menuAdminister);
            ClickControl(itemDataProfile);
        }

        public void GotoPage(string way)
        {
            string[] a = way.Split('/');
            int count = 1;
            for (int i=0;i<way.Length;i++ )
            {
                if(a[i]=="/")
                {
                    count++;
                }
            }
            for (int b=1;b<count;b++)
            {
                Actions builder = new Actions(Constant.WebDriver);
                Actions hoverClick = builder.MoveToElement(FindElement(By.XPath("//li//a[contains(.,'" + a[b] + "')]")));
                hoverClick.Build().Perform();
            }
            
        }

    }
}
