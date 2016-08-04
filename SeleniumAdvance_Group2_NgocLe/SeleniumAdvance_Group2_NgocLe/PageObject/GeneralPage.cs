using OpenQA.Selenium;
using SeleniumAdvance_Group2.Common;

namespace SeleniumAdvance_Group2.PageObject
{
    public class GeneralPage
    {
        public readonly By _lbUser = By.XPath("//a[@href='#Welcome']");
        public readonly By _btnLougout = By.XPath("//a[@href='logout.do']");
 



    }
}
