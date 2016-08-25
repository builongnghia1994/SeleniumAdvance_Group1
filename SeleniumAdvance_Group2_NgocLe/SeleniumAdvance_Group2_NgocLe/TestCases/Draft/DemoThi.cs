using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumAdvance_Group2.Common;
using SeleniumAdvance_Group2.PageObject.Login;
using SeleniumAdvance_Group2.PageObject.General;
using SeleniumAdvance_Group2.PageObject.MainPage;
using OpenQA.Selenium.Support.UI;
using SeleniumAdvance_Group2.PageObject.MainPage.Panel;

namespace SeleniumAdvance_Group2.TestCases
{  
    [TestClass]
    public class DemoThi : TestBases
    {
        GeneralPage generalPage;
        NewPage newPage;
       
            [TestMethod]
        public void Demo_Thi_DeleteAllPage()
        {
            generalPage = new GeneralPage();
            generalPage = loginPage.LoginDashBoard(Constant.Respos_SampleRepository, Constant.Username_thi, Constant.Password);
            generalPage.DeleteAllPages();
            //generalPage.DeletePagesJustCreated("page1160820160300190324");

        }
        [TestMethod]
        public void Demo_Thi_DeletePageJustCreated()
        {
            generalPage = new GeneralPage();
            newPage = new NewPage();
            
            generalPage = loginPage.LoginDashBoard(Constant.Respos_SampleRepository, Constant.Username_thi, Constant.Password);
            newPage = generalPage.GotoNewPage();
            generalPage = newPage.CreateNewPage(Constant.statusPublic, "abc"+Constant.timesystem, Constant.defaultValue, Constant.defaultValue, Constant.defaultValue, 0);

            newPage = generalPage.GotoNewPage();          
            generalPage = newPage.CreateNewPage(Constant.statusPublic, "abc1"+Constant.timesystem, "abc"+Constant.timesystem, Constant.defaultValue, Constant.defaultValue, 0);

            newPage = generalPage.GotoNewPage();
            generalPage = newPage.CreateNewPage(Constant.statusPublic, "abc2"+Constant.timesystem, "abc1"+Constant.timesystem, Constant.defaultValue, Constant.defaultValue,1);

            //newPage = generalPage.GotoNewPage();
            //generalPage = newPage.CreateNewPage(Constant.statusPublic, "abc3","abc2" , Constant.defaultValue, Constant.defaultValue,2);

            //generalPage.DeletePagesJustCreated(Constant.pageName);

        }


        [TestMethod]
        public void Demo_Thi_Spaceeeeeee()
        {
            newPage = new NewPage();
            newPage.PageNameFormat("b", 3);
            
        }

        
        public void DA_PANEL_TC045_Verify_that_Folder_field_is_not_allowed_to_be_empty()
        {
            string displayName = "panel" + Constant.timesystem;
            string series = "  Name";
            generalPage = loginPage.LoginDashBoard(Constant.Respos_SampleRepository, Constant.Username_trang, Constant.Password);
            generalPage = generalPage.CreateNewPageFromGeneralPage(Constant.statusPublic, Constant.pageName2, Constant.defaultValue, Constant.defaultValue, Constant.defaultValue, 0);
            ChoosePanelPage choosePanelPage = generalPage.GotoChoosePanelPage();
            NewPanelForPage newPanelForPage = new NewPanelForPage();
            newPanelForPage = choosePanelPage.GotoNewPanelPage();
            newPanelForPage.AddNewPanel(displayName, series);
            PanelConfigurationPage panelConfiguration = new PanelConfigurationPage();
            panelConfiguration.CreatePanelConfiguration(null, null, "");
            VerifyTextFromAlertAndAccept(Constant.MsgInvalidFolder_Panel);

        }
    }
}
