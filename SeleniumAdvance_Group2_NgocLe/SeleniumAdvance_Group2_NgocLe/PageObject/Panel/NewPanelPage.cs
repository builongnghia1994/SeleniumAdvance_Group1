using SeleniumAdvance_Group2.Common;
using SeleniumAdvance_Group2.PageObject.General;

namespace SeleniumAdvance_Group2.PageObject.Panel
{
    public class NewPanelPage : GeneralPage
    {
        public NewPanelPage()
        {
            if (Constant.NewPanelDictionary == null)
                Constant.NewPanelDictionary = ReadXML();
        }

        public void ClickOK()
        {
            ClickControl("ok button");

        }
        public void VerifyTextInAlertPopup(string expectedString)
        {
            string alertText = GetTextFromAlertPopup();

            AcceptAlert();

            ClickControl("cancel button");

            //move Verify to the end in case test case verify fail we can close alert and click Cancel button -> can log out
            VerifyText(expectedString, alertText);
        }

        public void AddNewPanel(string displayName, string series)
        {
            //currently, we just have 2 arguments for this methods since our test cases just need Display name and Series
            TypeValue("display name textbox", displayName);

            SelectItemByDropdownList("series list", series);

            ClickControl("ok button");
        }
    }
}
