using OpenQA.Selenium;
using SeleniumAdvance_Group2.Common;
using SeleniumAdvance_Group2.PageObject.GeneralPage;
using SeleniumAdvance_Group2.PageObject.PanelPage.NewPanelPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SeleniumAdvance_Group2.PageObject.PanelPage.NewPanelPage
{
    public class NewPanelPageActions : GeneralPageActions
    {

        public void ClickOK()
        {
            ClickControl(NewPanelPageUI.btnOK);

        }
        public void VerifyTextInAlertPopup(string expectedString)
        {
            VerifyText(expectedString, GetTextFromAlertPopup());
            AcceptAlert();
            ClickControl(NewPanelPageUI.btnCancel);
        }
    }
}
