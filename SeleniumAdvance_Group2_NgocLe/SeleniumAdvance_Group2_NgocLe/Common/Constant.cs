using OpenQA.Selenium;
using System;
using System.Configuration;
using System.IO;

namespace SeleniumAdvance_Group2.Common
{
    public class Constant
    {
        public static IWebDriver WebDriver;
        public static IWebElement WebElement;
        //  public static string DashboardURL = "http://192.168.190.205:54000/TADashboard/2f9njff6y9.page";

        public static string defaultValue = null;
        public static int timeout = 10;
        public static string Respository = "SampleRepository";
        public static string userTrang = "trang.le";
        public static string passTrang = "1";
        public static string MsgRequiredFieldPanel = "Display Name is a required field.";
        public static string MsgDashboardErrorLogin = "Username or password is invalid";

        public static string[] preSetDataProfile = { "Action Implementation By Status", "Test Case Execution",
            "Test Case Execution Failed Trend", "Test Case Execution History",
            "Test Case Execution Results", "Test Case Execution Trend",
            "Test Module Execution", "Test Module Execution Failure Trend",
            "Test Module Execution History", "Test Module Execution Results",
            "Test Module Execution Results Report", "Test Module Execution Trend",
            "Test Module Implementation By Priority", "Test Module Implementation By Status",
            "Test Module Status per Assigned Users", "Test Objective Execution"};

        public static string[] itemTypeValues = {"Test Modules", "Test Cases", "Test Objectives", "Data Sets",
            "Actions", "Interface Entities", "Test Results", "Test Cases results" };
        #region AppConfig

        public static string timesystem = Convert.ToString(DateTime.Now.ToString("ddMMyyyyhhmmssffff"));
        #endregion

        #region Browser/Url

        public static string Browser = ConfigurationManager.AppSettings["browser"];
        public static string DashboardURL = ConfigurationManager.AppSettings["url"];
        #endregion

        #region DataLogin_
        public static string UsernameAdmin = ConfigurationManager.AppSettings["usernameadmin"];
        public static string PasswordAdmin = ConfigurationManager.AppSettings["passwordadmin"];

        public static string Username_thi = ConfigurationManager.AppSettings["username_thi"];
        public static string Username_trang = ConfigurationManager.AppSettings["username_trang"];
        public static string Username_nghia = ConfigurationManager.AppSettings["username_nghia"];
        public static string Username_ngoc = ConfigurationManager.AppSettings["username_ngoc"];
        public static string Password = ConfigurationManager.AppSettings["password"];
        public static string Respos_SampleRepository = ConfigurationManager.AppSettings["respos_SampleRepository"];
        public static string Respos_TestRepository = ConfigurationManager.AppSettings["respos_TestRepository"];

        #endregion

        #region DataCreateNewpage

        public static string statuspublic = "public";
        public static string pagename1 = "page1" + Constant.timesystem;
        public static string pagename2 = "page2" + Constant.timesystem;
        public static string itemdisplayafter = "Overview";
               
        #endregion




        #region XML

        public static string XMLPath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())) + "\\PageObject\\XML\\";
        public static string XMLLoginPage = "LoginPage.xml";
        public static string XMLPanelManagerPage = "PanelManagerPage.xml";
        public static string XMLNewPanelPage = "NewPanelPage.xml";

        #endregion

    }
}
