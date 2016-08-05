using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SeleniumAdvance_Group2.PageObject
{
  public  class PanelPage:GeneralPage
    {
        public readonly By txtDisplayName = By.Id("txtDisplayName");
        public readonly By btnOK = By.Id("OK");
        public readonly By btnCancel = By.Id("Cancel");


      
    }
}
