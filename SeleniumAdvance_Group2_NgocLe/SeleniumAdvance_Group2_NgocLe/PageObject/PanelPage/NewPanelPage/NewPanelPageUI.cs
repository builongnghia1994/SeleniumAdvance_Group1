using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumAdvance_Group2.Common;

namespace SeleniumAdvance_Group2.PageObject.PanelPage.NewPanelPage
{
    public class NewPanelPageUI : CommonActions
    {
        //public static readonly By txtDisplayName = By.Id("txtDisplayName");
        // public static readonly By btnOK = By.Id("OK");
        // public static readonly By btnCancel = By.Id("Cancel");

        public static IWebElement txtDisplayName, btnOK, btnCancel;

        public NewPanelPageUI()
        {
            Dictionary<string, string>[] iDictionary = ReadXMlFile(Constant.XMLPath + Constant.XMLNewPanelPage);

            txtDisplayName = FindElementFromXML("txtDisplayName", iDictionary);
            btnOK = FindElementFromXML("btnOK", iDictionary);
            btnCancel = FindElementFromXML("btnCancel", iDictionary);
        }
    }
}
