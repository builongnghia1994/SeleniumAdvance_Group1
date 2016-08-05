using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SeleniumAdvance_Group2.PageObject
{
    public class PanelManagerPage : GeneralPage
    {
        public readonly By linkAddNewPanel = By.XPath("//a[contains(@href,'javascript:Dashboard.openAddPanel')]");


        public PanelPage GoToPanelPage()
        {
            ClickControl(linkAddNewPanel);
            return new PanelPage();
        }
    }

}
