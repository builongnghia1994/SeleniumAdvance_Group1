using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAdvance_Group2.PageObject.PanelPage.PanelManagerPage
{
    class PanelManagerPageUI
    {
         public static readonly By linkAddNewPanel = By.XPath("//a[contains(@href,'javascript:Dashboard.openAddPanel')]");
    }
}
