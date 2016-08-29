using OpenQA.Selenium;
using System;
using System.Configuration;
using System.IO;
using System.Collections.Generic;

namespace SeleniumAdvance_Group2.Common
{
    public class Constant
    {
        public static IWebDriver WebDriver;
        public static IWebElement WebElement;

        public static int Timeout = 20;
        public static string TimeSystem = Convert.ToString(DateTime.Now.ToString("ddMMyyyyhhmmss"));

        public static string[] PreSetDataProfile = { "Action Implementation By Status", "Test Case Execution",
            "Test Case Execution Failed Trend", "Test Case Execution History",
            "Test Case Execution Results", "Test Case Execution Trend",
            "Test Module Execution", "Test Module Execution Failure Trend",
            "Test Module Execution History", "Test Module Execution Results",
            "Test Module Execution Results Report", "Test Module Execution Trend",
            "Test Module Implementation By Priority", "Test Module Implementation By Status",
            "Test Module Status per Assigned Users", "Test Objective Execution"};

        public static string[] ItemTypeValues = {"Test Modules", "Test Cases", "Test Objectives", "Data Sets",
            "Actions", "Interface Entities", "Test Results", "Test Cases results", "Test Suites", "Bugs" };

        #region Message

        public static string MsgRequiredFieldPanel = "Display Name is required field";
        public static string MsgDashboardErrorLogin = "Username or password is invalid";
        public static string MsgInvalidPanelDisplayName = "Invalid display name. The name cannot contain high ASCII characters or any of the following characters: /:*?<>|\"#[]{}=%;";
        public static string MsgInvalidFolder_Panel = "Panel folder is incorrect";
        public static string MsgDeletePage = "Are you sure you want to remove this page?";

        #endregion

        #region Browser/Url
        public static string Grid = ConfigurationManager.AppSettings["grid"];
        public static string Browser = ConfigurationManager.AppSettings["browser"];
        public static string DashboardURL = ConfigurationManager.AppSettings["url"];
        public static string HubRL = ConfigurationManager.AppSettings["hubUrl"];

        #endregion

        #region DataLogin

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

        #region DataTest_DataProfile

        public static string ItemType = "test modules";
        public static string RelatedData = "Related test results";

        public static string SortField_Location = "Location";
        public static string SortField_Source = "Source";

        #endregion

        #region DataCreateNewpage

        public static string StatusPublic = "public";
        public static string Overview = "Overview";
        public static string DefaultValue = null;


        #endregion

        #region DataPanel

        public static string Series = "  Name";

        #endregion

        #region XML

        public static string XMLPath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())) + "\\Interfaces\\";
        public static Dictionary<string, string>[] LoginDictionary;
        public static Dictionary<string, string>[] NewPanelDictionary;
        public static Dictionary<string, string>[] PanelManagerDictionary;
        public static Dictionary<string, string>[] NewPageDictionary;
        public static Dictionary<string, string>[] NewDataProfileDictionary;
        public static Dictionary<string, string>[] DataProfileDictionary;
        public static Dictionary<string, string>[] GeneralDictionary;
        public static Dictionary<string, string>[] ChoosePanelDictionary;
        public static Dictionary<string, string>[] PanelConfigurationDictionary;
        public static Dictionary<string, string>[] EditDataProfileDictionary;
        public static Dictionary<string, string>[] SelectFolderPageDictionary;

        #endregion
    }
}
