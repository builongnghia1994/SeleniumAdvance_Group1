using SeleniumAdvance_Group2.PageObject.GeneralPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumAdvance_Group2.PageObject.PanelPage.NewPanelPage;

namespace SeleniumAdvance_Group2.PageObject.PanelPage.PanelManagerPage
{
    public class PanelManagerPageActions: GeneralPage.GeneralPageActions
    {
        public NewPanelPageUI GoToPanelPage()
        {
            ClickControl(PanelManagerPageUI.linkAddNewPanel);
            return new NewPanelPageUI();
        }
    }
}
