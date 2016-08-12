using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumAdvance_Group2.Common;

namespace SeleniumAdvance_Group2.PageObject.PanelPage.PanelManagerPage
{
    public class PanelManagerPageUI : CommonActions
    {
        //  public static readonly By linkAddNewPanel = By.XPath("//a[contains(@href,'javascript:Dashboard.openAddPanel')]");

        public static IWebElement linkAddNewPanel;

        public PanelManagerPageUI()
        {
            Dictionary<string, string>[] iDictionary = ReadXMlFile(Constant.XMLPath + Constant.XMLPanelManagerPage);

            linkAddNewPanel = FindElementFromXML("linkAddNewPanel", iDictionary);
        }
    }
}
