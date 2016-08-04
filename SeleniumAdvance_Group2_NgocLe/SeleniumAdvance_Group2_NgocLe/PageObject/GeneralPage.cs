using OpenQA.Selenium;
using SeleniumAdvance_Group2_NgocLe.Common;

namespace SeleniumAdvance_Group2_NgocLe.PageObject
{
    public class GeneralPage
    {
        public readonly By _lbUser = By.XPath("//a[@href='#Welcome']");
        public readonly By _btnLougout = By.XPath("//a[@href='logout.do']");
 



    }
}
