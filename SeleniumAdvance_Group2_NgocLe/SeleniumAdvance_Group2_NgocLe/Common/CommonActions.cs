using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumAdvance_Group2.PageObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Edge;

namespace SeleniumAdvance_Group2.Common
{
    public class CommonActions
    {
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
            WaitForControl(control, Constant.timeout);
            return Constant.WebDriver.FindElement(control);
        }

        public void ClickControl(By control)
        {
            FindElement(control).Click();
        }

        public void ClickControlByJS(By control)
        {
            IWebElement webElement = FindElement(control);
            IJavaScriptExecutor executor = (IJavaScriptExecutor)Constant.WebDriver;
            executor.ExecuteScript("arguments[0].click();", webElement);
        }


        public void TypeValue(By control, string value)
        {
            FindElement(control).Clear();
            FindElement(control).SendKeys(value);
        }

        public void SelectItemByDropdownList(By control, string value)
        {
            SelectElement SelectElementByXpath = new SelectElement(FindElement(control));
            SelectElementByXpath.SelectByText(value);
        }


        public string GetText(By control)
        {
            return FindElement(control).Text;
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

        public int CountItems(By control)
        {
            return Constant.WebDriver.FindElements(control).Count;
        }

        public void VerifyText(string expectedText, By element)
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
            alert.Accept();
            Constant.WebDriver.SwitchTo().DefaultContent();
            return alertText;
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

        public void VerifyDoesControlNotExist(By control)
        {
            Assert.IsFalse(DoesControlExist(control));
        }

        public void VerifyDoesControlExist(By control)
        {
            Assert.IsTrue(DoesControlExist(control));
        }
    }
}
