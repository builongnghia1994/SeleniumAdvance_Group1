using SeleniumAdvance_Group2.PageObject.General;
using SeleniumAdvance_Group2.Common;

namespace SeleniumAdvance_Group2.PageObject.Login
{
    public class LoginPage : GeneralPage
    {
        public LoginPage()
        {
            if (Constant.LoginDictionary == null)
                Constant.LoginDictionary = ReadXML();
        }

        public GeneralPage LoginDashBoard(string respository, string username, string password)
        {
            Login(respository, username, password);
            return new GeneralPage();
        }

        public void Login(string respository, string username, string password)
        {
            SelectItemByDropdownList("repository list", respository);
            TypeValue("username textbox", username);
            TypeValue("password textbox", password);
            ClickControl("login button");

        }

        public void VerifyDashboardErrorMessageLogin(string expectederromessage)
        {
            VerifyText(expectederromessage, GetTextFromAlertPopup());
            AcceptAlert();
        }
    }
}

