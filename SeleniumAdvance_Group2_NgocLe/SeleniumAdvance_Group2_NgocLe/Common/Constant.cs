using OpenQA.Selenium;
using System;
using System.Configuration;

namespace SeleniumAdvance_Group2.Common
{
    public class Constant
    {
        public static IWebDriver WebDriver;
        public static IWebElement WebElement;
      //  public static string DashboardURL = "http://192.168.190.205:54000/TADashboard/2f9njff6y9.page";
       
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
            "Test Module Status per Assigned Users", "Test Objective Execution" };

        public static string timesystem = Convert.ToString(DateTime.Now.ToString("ddMMyyyyhhmmssffff"));
        public static string Browser = ConfigurationManager.AppSettings["Browser"];
        public static string DashboardURL= ConfigurationManager.AppSettings["URL"];
        public static string defaultValue = null;
        public static int timeout = 3000;


    }
}
