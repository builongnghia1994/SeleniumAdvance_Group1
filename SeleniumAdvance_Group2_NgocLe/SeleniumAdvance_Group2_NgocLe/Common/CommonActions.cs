using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Edge;
using SeleniumAdvance_Group2.PageObject.Login;
using System.Xml;
using System.Diagnostics;
using System.Threading;

namespace SeleniumAdvance_Group2.Common
{
    public class CommonActions
    {
        public bool Displayed { get; private set; }

        public static void OpenBrowser(string browser)

        {
            switch (browser.ToLower())
            {

                case "chrome":
                    ChromeOptions options = new ChromeOptions();
                    options.AddArguments("--disable-extensions");
                    Constant.WebDriver = new ChromeDriver(options);
                    Constant.WebDriver.Manage().Window.Maximize();
                    break;
                case "ie":
                    InternetExplorerOptions optionIE = new InternetExplorerOptions();
                    optionIE.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                    Constant.WebDriver = new InternetExplorerDriver(optionIE);
                    Constant.WebDriver.Manage().Window.Maximize();

                   
                    break;
                case "firefox":
                    Constant.WebDriver = new FirefoxDriver();
                    Constant.WebDriver.Manage().Window.Maximize();
                    break;
                case "edgewin":
                    Constant.WebDriver = new EdgeDriver();
                    Constant.WebDriver.Manage().Window.Maximize();
                    break;
                default:
                    Console.WriteLine(String.Format("Browser '{0}' not recognized. Spawning default Firefox browser.", browser));
                    Constant.WebDriver = new FirefoxDriver();
                    Constant.WebDriver.Manage().Window.Maximize();
                    break;
            }
        }
        public static void CloseBrowser()
        {
            Constant.WebDriver.Manage().Cookies.DeleteAllCookies();
            Constant.WebDriver.Quit();
        }
        public LoginPage OpenURL(string url)
        {
            Constant.WebDriver.Navigate().GoToUrl(url);
            return new LoginPage();
        }

        public IWebElement FindElement(By control)
        {
           
            return Constant.WebDriver.FindElement(control);
        }

        public void ClickControl(By control)
        {
            FindElement(control).Click();
        }

        public void ClickControl(IWebElement control)
        {
            control.Click();
        }

        public void ClickControlByJS(By control)
        {
            IWebElement webElement = FindElement(control);
            IJavaScriptExecutor executor = (IJavaScriptExecutor)Constant.WebDriver;
            executor.ExecuteScript("arguments[0].click();", webElement);
        }

        public void ClickControlByJS(string locator)
        {
            IWebElement webElement = FindElement(locator);
            IJavaScriptExecutor executor = (IJavaScriptExecutor)Constant.WebDriver;
            executor.ExecuteScript("arguments[0].click();", webElement);
        }

        public void ClickControlByJS(IWebElement control)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)Constant.WebDriver;
            executor.ExecuteScript("arguments[0].click();", control);
        }

        public void TypeValue(By control, string value)
        {
            FindElement(control).Clear();
            FindElement(control).SendKeys(value);
        }

        public void TypeValue(IWebElement control, string value)
        {
            control.Clear();
            control.SendKeys(value);
        }
        public void SelectItemByDropdownList(By control, string value)
        {
            SelectElement SelectElementByXpath = new SelectElement(FindElement(control));
            SelectElementByXpath.SelectByText(value);
        }

        public void SelectItemByDropdownList(IWebElement control, string value)
        {
            SelectElement SelectElementByXpath = new SelectElement(control);
            SelectElementByXpath.SelectByText(value);
        }

        public string GetText(By control)
        {
            return FindElement(control).Text;
        }

        public string GetText(IWebElement control)
        {
            return control.Text;
        }
        public bool DoesControlExist(By control)
        {
            try
            {
                Constant.WebDriver.FindElement(control);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void WaitForControl(By control, int timesecond)
        {
            Constant.WebElement = new WebDriverWait(Constant.WebDriver, TimeSpan.FromSeconds(timesecond)).Until(ExpectedConditions.ElementExists(control));

        }

        public void WaitForControl(string locator, int timesecond)
        {
            By control = BYFindElement(locator);
            Constant.WebElement = new WebDriverWait(Constant.WebDriver, TimeSpan.FromSeconds(timesecond)).Until(ExpectedConditions.ElementExists(control));
        }

        public void WaitForControlNotVisible(By control, int timesecond)
        {
            Constant.WebElement = new WebDriverWait(Constant.WebDriver, TimeSpan.FromSeconds(timesecond)).Until(ExpectedConditions.ElementIsVisible(control));
        }

        public int CountItems(By control)
        {
            return Constant.WebDriver.FindElements(control).Count;
        }

        public void VerifyText(string expectedText, By element)
        {
            string actualText = GetText(element);
            Assert.AreEqual(expectedText, actualText);
        }

        public void VerifyTextFromControl(string expectedText, string locator)
        {
            By element = BYFindElement(locator);
            string actualText = GetText(element);
            Assert.AreEqual(expectedText, actualText);
        }

        public void VerifyText(string expectedText, IWebElement element)
        {
            string actualText = GetText(element);
            Assert.AreEqual(expectedText, actualText);
        }
        public void VerifyText(string expectedText, string actualText)
        {
            Assert.AreEqual(expectedText, actualText);
        }

        public string GetTextFromAlertPopup()
        {
            WaitForAlertPresent(Constant.timeout);
            IAlert alert = Constant.WebDriver.SwitchTo().Alert();
            string alertText = alert.Text;
            Constant.WebDriver.SwitchTo().DefaultContent();
            return alertText;
        }


        public void DismissAlert()
        {
            WaitForAlertPresent(Constant.timeout);
            IAlert alert = Constant.WebDriver.SwitchTo().Alert();
            alert.Dismiss();
            Constant.WebDriver.SwitchTo().DefaultContent();
        }

        public void AcceptAlert()
        {
            WaitForAlertPresent(Constant.timeout);
            IAlert alert = Constant.WebDriver.SwitchTo().Alert();
            alert.Accept();
            Constant.WebDriver.SwitchTo().DefaultContent();
        }

        public void WaitForAlertPresent(int timeout)
        {
            new WebDriverWait(Constant.WebDriver, TimeSpan.FromSeconds(timeout)).Until(ExpectedConditions.AlertIsPresent());
        }

        public void VerifyControlNotExist(By control)
        {
            Assert.IsFalse(DoesControlExist(control));
        }

        public void VerifyDoesControlExist(By control)
        {
            Assert.IsTrue(DoesControlExist(control));
        }


        //public Dictionary<string, string>[] ReadXMlFile(string filename)
        //{
        //    XmlDocument xd = new XmlDocument();
        //    xd.Load(filename);

        //    Dictionary<string, string> typeDictionary = new Dictionary<string, string>();
        //    Dictionary<string, string> valueDictionary = new Dictionary<string, string>();
        //    foreach (XmlNode node in xd.DocumentElement.ChildNodes)
        //    {
        //        typeDictionary.Add(node.Name, node.ChildNodes[0].InnerText);
        //        valueDictionary.Add(node.Name, node.ChildNodes[1].InnerText);
        //    }
        //    Dictionary<string, string>[] iDictionary = new Dictionary<string, string>[2];
        //    iDictionary[0] = typeDictionary;
        //    iDictionary[1] = valueDictionary;
        //    return iDictionary;
        //}

        public IWebElement FindElementFromXML(string key, Dictionary<string, string>[] iDictionary)
        {
            return FindElementByType(iDictionary[0][key], iDictionary[1][key]);
        }

        public By BYFindElementFromXML(string key, Dictionary<string, string>[] iDictionary)
        {
            return BYFindElementByType(iDictionary[0][key], iDictionary[1][key]);
        }
        public IWebElement FindElementByType(string type, string value)
        {
            By element = null;
            switch (type.ToLower())
            {
                case "id":
                    element = By.Id(value);
                    break;
                case "xpath":
                    element = By.XPath(value);
                    break;
                case "class":
                    element = By.ClassName(value);
                    break;
                case "name":
                    element = By.Name(value);
                    break;
            }

            return FindElement(element);
        }

        #region temporary
        public By BYFindElementByType(string type, string value)
        {
            By element = null;
            switch (type.ToLower())
            {
                case "id":
                    element = By.Id(value);
                    break;
                case "xpath":
                    element = By.XPath(value);
                    break;
                case "class":
                    element = By.ClassName(value);
                    break;
                case "name":
                    element = By.Name(value);
                    break;
            }

            return element;
        }
        #endregion

        public Dictionary<string, string>[] ReadXMlFile(string filename)
        {
            XmlDocument xd = new XmlDocument();
            xd.Load(filename);

            Dictionary<string, string> typeDictionary = new Dictionary<string, string>();
            Dictionary<string, string> valueDictionary = new Dictionary<string, string>();
            foreach (XmlNode node in xd.DocumentElement.ChildNodes)
            {
                typeDictionary.Add(node.ChildNodes[0].InnerText, node.ChildNodes[1].InnerText);
                valueDictionary.Add(node.ChildNodes[0].InnerText, node.ChildNodes[2].InnerText);
            }
            Dictionary<string, string>[] iDictionary = new Dictionary<string, string>[2];
            iDictionary[0] = typeDictionary;
            iDictionary[1] = valueDictionary;
            return iDictionary;
        }

        public void TypeValue(string locator, string value)
        {
            IWebElement element = FindElement(locator);
            element.Clear();
            element.SendKeys(value);
        }

        public void SelectItemByDropdownList(string locator, string value)
        {

            SelectElement selectElementByControl = new SelectElement(FindElement(locator));
            selectElementByControl.SelectByText(value);
        }

        public void ClickControl(string locator)
        {
            FindElement(locator).Click();
        }

        public IWebElement FindElement(string locator)
        {
           
            string page = GetClassCaller(3);
            //  page = page.Substring(0, page.Length - 7);
            string filename = Constant.XMLPath + page + ".xml";
            Dictionary<string, string>[] iDictionary = new Dictionary<string, string>[2];
            switch (page)
            {

                case "LoginPage":
                    iDictionary = Constant.LoginDictionary;
                    break;
                case "NewPanelPage":
                    iDictionary = Constant.NewPanelDictionary;
                    break;
                case "PanelManagerPage":
                    iDictionary = Constant.NewPanelDictionary;
                    break;
                case "EditPage":
                case "NewPage":
                    iDictionary = Constant.NewPageDictionary;
                    break;
                case "DataProfileManagerPage":
                    iDictionary = Constant.DataProfileDictionary;
                    break;
                case "NewDataProfilePage":
                    iDictionary = Constant.NewDataProfileDictionary;
                    break;
                case "GeneralPage":
                    iDictionary = Constant.GeneralDictionary;
                    break;

            }
            //    Dictionary<string, string>[] iDictionary = ReadXMlFile(filename);
            return FindElementFromXML(locator, iDictionary);
        }

        public By BYFindElement(string locator)
        {
            string page = GetClassCaller(3);
            //  page = page.Substring(0, page.Length - 7);
            string filename = Constant.XMLPath + page + ".xml";
            Dictionary<string, string>[] iDictionary = new Dictionary<string, string>[2];
            switch (page)
            {

                case "LoginPage":
                    iDictionary = Constant.LoginDictionary;
                    break;
                case "NewPanelPage":
                    iDictionary = Constant.NewPanelDictionary;
                    break;
                case "PanelManagerPage":
                    iDictionary = Constant.NewPanelDictionary;
                    break;
                case "EditPage":
                case "NewPage":
                    iDictionary = Constant.NewPageDictionary;
                    break;
                case "DataProfileManagerPage":
                    iDictionary = Constant.DataProfileDictionary;
                    break;
                case "NewDataProfilePage":
                    iDictionary = Constant.NewDataProfileDictionary;
                    break;
                case "GeneralPage":
                    iDictionary = Constant.GeneralDictionary;
                    break;

            }
            //    Dictionary<string, string>[] iDictionary = ReadXMlFile(filename);
            return BYFindElementFromXML(locator, iDictionary);
        }

        public Dictionary<string, string>[] ReadXML()
        {
            string page = GetClassCaller(2);
            //   page = page.Substring(0, page.Length - 7);
            string filename = Constant.XMLPath + page + ".xml";
            return ReadXMlFile(filename);

        }

        private static string GetClassCaller(int level)
        {
            // StackTrace stackTrace = new StackTrace();           // get call stack
            //  StackFrame[] stackFrames = stackTrace.GetFrames();  // get method calls (frames)

            //   StackFrame callingFrame = stackFrames[1];

            //   var method = callingFrame.GetMethod();

            //    var n = System.Reflection.MethodBase.GetCurrentMethod();


            var m = new StackTrace().GetFrame(level).GetMethod();
            return m.DeclaringType.Name;
        }

        public int CountItems(string locator)
        {
            By element = BYFindElement(locator);
            return Constant.WebDriver.FindElements(element).Count;
        }



        public  IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds)
        {
           
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by));
            
           
        }



    }
}
