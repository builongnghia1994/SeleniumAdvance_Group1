using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAdvance_Group2.PageObject.PanelPage.NewPanelPage
{
    class NewPanelPageUI
    {
        public static readonly By txtDisplayName = By.Id("txtDisplayName");
        public static readonly By btnOK = By.Id("OK");
        public static readonly By btnCancel = By.Id("Cancel");
    }
}
