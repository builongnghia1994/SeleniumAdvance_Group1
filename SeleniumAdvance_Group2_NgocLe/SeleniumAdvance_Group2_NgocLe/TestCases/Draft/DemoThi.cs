using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumAdvance_Group2.Common;
using SeleniumAdvance_Group2.PageObject.General;
using SeleniumAdvance_Group2.PageObject.MainPage;
using SeleniumAdvance_Group2.PageObject.MainPage.Panel;

namespace SeleniumAdvance_Group2.TestCases
{  
    [TestClass]
    public class DemoThi : TestBases
    {
        GeneralPage generalPage;
        NewPage newPage;

        [TestMethod]
        public void DA_LOGIN_TC001_Verify_that_user_can_login_specific_repository_successfully_with_correct_credentials()
        {
            GeneralPage generalPage;

            generalPage = loginPage.LoginDashBoard(Constant.Respos_SampleRepository, Constant.Username_thi, Constant.Password);

            generalPage.VerifyWelComeUserDisplayed(Constant.Username_thi);
            loginPage = generalPage.LogOut();
        }

        [TestMethod]
        public void DA_LOGIN_TC002_Verify_that_user_fails_to_login_with_incorrect_credentials()
        {

            loginPage.Login(Constant.Respos_SampleRepository, "abc", "abc");

            loginPage.VerifyDashboardErrorMessageLogin(Constant.MsgDashboardErrorLogin);
        }

        //[TestMethod]
        public void DA_LOGIN_TC003_Verify_that_user_fails_to_login_with_correct_username_and_incorrect_password()
        {

            loginPage.Login(Constant.Respos_SampleRepository, Constant.UsernameAdmin, "abc");

            loginPage.VerifyDashboardErrorMessageLogin(Constant.MsgDashboardErrorLogin);
        }

        //[TestMethod]
        public void Demo_Thi_DeleteAllPage()
        {
            generalPage = new GeneralPage();
            generalPage = loginPage.LoginDashBoard(Constant.Respos_SampleRepository, Constant.Username_thi, Constant.Password);
            generalPage.DeleteAllPages();
            //generalPage.DeletePagesJustCreated("page1160820160300190324");

        }
        [TestMethod]
        public void DA_MP_TC017_Verify_that_user_can_remove_any_main_parent_page_without_children_and_except_Overview_page()
        {
            string parentPage = "TC17" + Constant.TimeSystem;
            string childPage = "TC17" + Constant.TimeSystem + "1";

            generalPage = loginPage.LoginDashBoard(Constant.Respos_SampleRepository, Constant.Username_ngoc, Constant.Password);

            newPage = generalPage.GotoNewPage();
            generalPage = newPage.CreateNewPage(Constant.StatusPublic, parentPage, Constant.DefaultValue, Constant.DefaultValue, Constant.DefaultValue, Constant.DefaultValue);

            newPage = generalPage.GotoNewPage();
            generalPage = newPage.CreateNewPage(Constant.StatusPublic, childPage, parentPage, Constant.DefaultValue, Constant.DefaultValue, Constant.DefaultValue);


            generalPage.SelectDeletePage(parentPage);

            generalPage.VerifyAlertMessage(Constant.MsgDeletePage);
            generalPage.AcceptAlert();

            generalPage.VerifyAlertMessage("Cannot delete page '" + parentPage + "' since it has child page(s).");
            generalPage.AcceptAlert();

            generalPage.SelectDeletePage(parentPage + "/" + childPage);
            generalPage.VerifyAlertMessage(Constant.MsgDeletePage);
            generalPage.AcceptAlert();


            generalPage.VerifyPageNotExist(parentPage + "/" + childPage);

            generalPage.SelectDeletePage(parentPage);

            generalPage.VerifyAlertMessage(Constant.MsgDeletePage);
            generalPage.AcceptAlert();

            generalPage.VerifyPageNotExist(parentPage);

            generalPage.GotoPage(Constant.Overview);

            generalPage.VerifyControlNotExistInGlobalSetting("Delete");

            //post-condition
            generalPage.LogOut();
        }
        // [TestMethod]
        public void Demo_Thi_DeletePageJustCreated()
        {
            generalPage = new GeneralPage();
            newPage = new NewPage();
            
            generalPage = loginPage.LoginDashBoard(Constant.Respos_SampleRepository, Constant.Username_thi, Constant.Password);
            newPage = generalPage.GotoNewPage();
            generalPage = newPage.CreateNewPage(Constant.StatusPublic, "abc"+Constant.TimeSystem, Constant.DefaultValue, Constant.DefaultValue, Constant.DefaultValue, Constant.DefaultValue);

            newPage = generalPage.GotoNewPage();          
            generalPage = newPage.CreateNewPage(Constant.StatusPublic, "abc1"+Constant.TimeSystem, "abc"+Constant.TimeSystem, Constant.DefaultValue, Constant.DefaultValue, Constant.DefaultValue);

            newPage = generalPage.GotoNewPage();
            generalPage = newPage.CreateNewPage(Constant.StatusPublic, "abc2"+Constant.TimeSystem, "abc1"+Constant.TimeSystem, Constant.DefaultValue, Constant.DefaultValue,"1");

            //newPage = generalPage.GotoNewPage();
            //generalPage = newPage.CreateNewPage(Constant.statusPublic, "abc3","abc2" , Constant.defaultValue, Constant.defaultValue,2);

            //generalPage.DeletePagesJustCreated(Constant.pageName);

        }
 
        public void DA_PANEL_TC045_Verify_that_Folder_field_is_not_allowed_to_be_empty()
        {
            string displayName = "panel" + Constant.TimeSystem;
            string series = "  Name";
            string pageName = "TC45" + Constant.TimeSystem;

            generalPage = loginPage.LoginDashBoard(Constant.Respos_SampleRepository, Constant.Username_trang, Constant.Password);
            generalPage = generalPage.CreateNewPageFromGeneralPage(Constant.StatusPublic, pageName, Constant.DefaultValue, Constant.DefaultValue, Constant.DefaultValue, Constant.DefaultValue);
            ChoosePanelPage choosePanelPage = generalPage.GotoChoosePanelPage();
            NewPanelForPage newPanelForPage = new NewPanelForPage();
            newPanelForPage = choosePanelPage.GotoNewPanelPage();
            newPanelForPage.AddNewPanel(displayName, series);
            PanelConfigurationPage panelConfiguration = new PanelConfigurationPage();
            panelConfiguration.CreatePanelConfiguration(null, null, "");
            VerifyTextFromAlertAndAccept(Constant.MsgInvalidFolder_Panel);

        }

        //public void DeletePagesJustCreated(string namepageparrent)
        //{
        //    string itemclasscurrent = string.Empty;
        //    string xpath = string.Empty;
        //    xpath = "//div[@id='main-menu']/div/ul/li/a[text()='" + namepageparrent + "']";
        //    while (DoesControlExist(By.XPath(xpath)))
        //    {
        //        string xpath2 = xpath;
        //        itemclasscurrent = FindElement(By.XPath(xpath2)).GetAttribute("class");
        //        while (itemclasscurrent.Equals("haschild") || itemclasscurrent.Equals("active haschild"))
        //        {
        //            Actions builder = new Actions(Constant.WebDriver);
        //            Actions hoverClick = builder.MoveToElement(FindElement(By.XPath(xpath2)));
        //            hoverClick.Build().Perform();
        //            string next = "/following-sibling::ul/li/a";
        //            xpath2 = xpath2 + next;
        //            itemclasscurrent = FindElement(By.XPath(xpath2)).GetAttribute("class").ToString();
        //        }
        //        if (Constant.Browser.Equals("ie"))
        //        {
        //            ClickControlByJS(By.XPath(xpath2));
        //            SelectGlobalSetting("Delete");
        //            AcceptAlert();
        //        }
        //        else
        //        {
        //            Console.Write(xpath2);
        //            ClickControl(By.XPath(xpath2));
        //            SelectGlobalSetting("Delete");
        //            AcceptAlert();
        //            Thread.Sleep(500);
        //        }
        //    }
        //}
    }
}