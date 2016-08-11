using SeleniumAdvance_Group2.PageObject.GeneralPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAdvance_Group2.PageObject.PanelPage.PanelManagerPage
{
    public class PanelManagerPageActions: GeneralPageActions
    {
        public NewPanelPageActions GoToPanelPage()
        {
            ClickControl(PanelManagerPageUI.linkAddNewPanel);
            return new NewPanelPageActions();
        }
    }
}
