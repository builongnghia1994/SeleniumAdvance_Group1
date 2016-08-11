using OpenQA.Selenium;
using SeleniumAdvance_Group2.Common;
using SeleniumAdvance_Group2.PageObject.GeneralPage;
using SeleniumAdvance_Group2.PageObject.PanelPage.NewPanelPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAdvance_Group2.PageObject.PanelPage
{
    public class NewPanelPageActions : GeneralPageActions
    {
        public By BtnOK
        {
            get { return NewPanelPageUI.btnOK; }
        }

        public By BtnCancel
        {
            get { return NewPanelPageUI.btnCancel; }
        }

        public void VerifyTextInAlertPopup()
        {
            VerifyText(Constant.MsgRequiredFieldPanel, GetTextFromAlertPopup());
            ClickControl(this.BtnCancel);
        }
    }
}
