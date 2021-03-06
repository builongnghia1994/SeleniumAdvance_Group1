﻿using Fenton.Selenium.SuperDriver;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SeleniumAdvance_Group2.Common
{
    class BrowserManager
    {
        public static IWebDriver Browser
        {
            get
            {
                Uri uri = new Uri(Constant.HubURL);
                if (Constant.Grid.ToLower().Equals("yes"))
                {
                    switch (Constant.Browser.ToLower())
                    {
                        case "parallel":
                            Constant.WebDriver = new SuperWebDriver(GetDriverSuiteGrid());
                            break;
                        case "ie":
                            Constant.WebDriver = new RemoteWebDriver(uri, DesiredCapabilities.InternetExplorer());
                            break;
                        case "chrome":
                            Constant.WebDriver = new RemoteWebDriver(uri, DesiredCapabilities.Chrome());
                            break;
                        case "winedge":
                            Constant.WebDriver = new RemoteWebDriver(uri, DesiredCapabilities.Edge());
                            break;
                        default:
                            Constant.WebDriver = new RemoteWebDriver(uri, DesiredCapabilities.Firefox());
                            break;
                    }
                }
                else
                {
                    switch (Constant.Browser.ToLower())
                    {
                        case "parallel":
                            Constant.WebDriver = new SuperWebDriver(GetDriverSuiteLocal());
                            break;
                        case "ie":
                            Constant.WebDriver = new InternetExplorerDriver();
                            break;
                        case "chrome":
                            Constant.WebDriver = new ChromeDriver();
                            break;
                        case "winedge":
                            Constant.WebDriver = new EdgeDriver();
                            break;
                        default:
                            Constant.WebDriver = new FirefoxDriver();
                            break;
                    }
                }
                Constant.WebDriver.Manage().Window.Maximize();
                return Constant.WebDriver;
            }
        }
        private static IList<IWebDriver> GetDriverSuiteGrid()
        {
            Uri uri = new Uri(Constant.HubURL);
            IList<IWebDriver> drivers = new List<Func<IWebDriver>>
            {
                () => { return new RemoteWebDriver(uri, DesiredCapabilities.Firefox()); },
                () => { return new RemoteWebDriver(uri, DesiredCapabilities.Chrome()); },
                () => { return new RemoteWebDriver(uri, DesiredCapabilities.InternetExplorer()); },
            }.AsParallel().Select(d => d()).ToList();

            return drivers;
        }

        private static IList<IWebDriver> GetDriverSuiteLocal()
        {
            IList<IWebDriver> drivers = new List<Func<IWebDriver>>
            {
                () =>  { return (IWebDriver)new ChromeDriver(); },
                () =>  { return (IWebDriver)new FirefoxDriver(); },
                () =>  { return (IWebDriver)new InternetExplorerDriver(); },
            }.AsParallel().Select(d => d()).ToList();
            return drivers;
        }
    }
}
