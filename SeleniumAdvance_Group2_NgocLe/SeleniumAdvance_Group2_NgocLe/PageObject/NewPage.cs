using SeleniumAdvance_Group2.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumAdvance_Group2.PageObject
{
    public class NewPage: GeneralPage
    {
        private readonly By txtPageName = By.Id("name");
        private readonly By rdIsPublic = By.Id("ispublic");
        private readonly By drdparentname = By.Id("parent");
        private readonly By drdafterpage = By.Id("afterpage");
        private readonly By drdnumberclm = By.Id("columnnumber");
        private readonly By btnOK = By.Id("ok");

       /* public void CreatePage(string pagename,string ispublic, string parentname,string numberclm,string afterpage)
        {
            FindElement(txtPageName).SendKeys(pagename);
           switch(ispublic)
                {
                case "public":
                    FindElement(rdIsPublic).Click();
                    break;
                default:
                    break;
                 }
           if(parentname!="")
            {
                new SelectElement(FindElement(drdparentname)).SelectByText(parentname);
            }
           if(afterpage!= "")
            {
                new SelectElement(FindElement(drdafterpage)).SelectByText(afterpage);
            }
           if(numberclm!="")
            {
                new SelectElement(FindElement(drdnumberclm)).SelectByText(numberclm);
            }
            ClickControl(btnOK);
        }*/
    }
}
