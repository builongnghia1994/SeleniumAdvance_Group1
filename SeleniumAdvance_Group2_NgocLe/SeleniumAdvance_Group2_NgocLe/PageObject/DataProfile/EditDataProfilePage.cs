using SeleniumAdvance_Group2.Common;
using SeleniumAdvance_Group2.PageObject.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumAdvance_Group2.PageObject.DataProfile
{
    public class EditDataProfilePage : GeneralPage
    {
        public EditDataProfilePage()
        {
            if (Constant.EditDataProfileDictionary == null)
                Constant.EditDataProfileDictionary = ReadXML();
        }

        #region Verify Method
        public void ClickTab(string tab)
        {
            ClickControl(tab);
        }
        public void VerifyPageDisplay(string expected)
        {
            WaitForPageLoad();
            VerifyTextFromControl(expected, "header of tab");
        }
        #endregion
    }
}
