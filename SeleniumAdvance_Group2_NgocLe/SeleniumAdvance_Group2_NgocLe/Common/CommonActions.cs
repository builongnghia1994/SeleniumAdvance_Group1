﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumAdvance_Group2.PageObject;

namespace SeleniumAdvance_Group2.Common
{
    public class CommonActions
    {

        public static LoginPage OpenURL(string url)
        {
            Constant.WebDriver.Navigate().GoToUrl(url);
            return new LoginPage();
        }
        public IWebElement FindElement(By control)
        {
            return Constant.WebDriver.FindElement(control);
        }

        public void ClickControl (By control)
        {
            FindElement(control).Click();
        }


        public void TypeValue(By control, string value)
        {
            FindElement(control).Clear();
            FindElement(control).SendKeys(value);
        }
        
        public void SelectItemByDropdownList(By control, string value)
        {
            SelectElement SelectElementByXpath = new SelectElement(FindElement(control));
            SelectElementByXpath.SelectByValue(value);
        }


        public string GetText(By control)
        {
            return FindElement(control).Text;
        }


        public bool DoesControlExist(By control)
        {
            try
            {
                FindElement(control);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }


    


    }
}
