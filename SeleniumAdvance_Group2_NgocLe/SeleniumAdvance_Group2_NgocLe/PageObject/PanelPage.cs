using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumAdvance_Group2.Common;

namespace SeleniumAdvance_Group2.PageObject
{
  public  class PanelPage:GeneralPage
    {
        private readonly By txtDisplayName = By.Id("txtDisplayName");
        private readonly By btnOK = By.Id("OK");
        private readonly By btnCancel = By.Id("Cancel");

        public By BtnOK
        {
            get { return btnOK; }
        }

        public By BtnCancel
        {
            get { return btnCancel; }
        }

        public void VerifyTextInAlertPopup()
        {
            VerifyText(Constant.MsgRequiredFieldPanel, GetTextFromAlertPopup());
            ClickControl(this.BtnCancel);
        }
    }
}
