using OpenQA.Selenium;
using SeleniumAdvance_Group2.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;

namespace SeleniumAdvance_Group2.PageObject
{
    public class GeneralPage : CommonActions
    {
        private readonly By menuUser = By.XPath("//a[@href='#Welcome']");
        private readonly By itemLogOut = By.XPath("//a[@href='logout.do']");
        private readonly By menuAdminister = By.XPath("//a[@href='#Administer']");
        private readonly By itemDataProfile = By.XPath("//a[@href='profiles.jsp']");
        private readonly By itemPanel = By.XPath("//a[@href='panels.jsp']");

        private readonly By menuGlobalSetting = By.XPath("//li[@class='mn-setting']/a[@href='javascript:void(0);']");
        private readonly By itemAddPage = By.XPath("//a[@class='add' and text()='Add Page']");




        private readonly By txtPageName = By.Id("name");
        private readonly By rdIsPublic = By.Id("ispublic");
        private readonly By drdparentname = By.Id("parent");
        private readonly By drdafterpage = By.Id("afterpage");
        private readonly By drdnumberclm = By.Id("columnnumber");
        private readonly By btnOK = By.Id("OK");

        private readonly By itemsMainPage = By.XPath("//div[@id='main-menu']/div/ul/li/a");





        public LoginPage LogOut()
        {
            if (Constant.Browser == "ie")
            {

                ClickControlByJS(menuUser);
                ClickControlByJS(itemLogOut);
            }
            else
            {
                ClickControl(menuUser);
                ClickControl(itemLogOut);
            }
            return new LoginPage();
        }

        public DataProfilePage GotoDataProfilePage()
        {
            if (Constant.Browser == "ie")
            {

                ClickControlByJS(menuAdminister);
                ClickControlByJS(itemDataProfile);
            }
            else
            {
                ClickControl(menuAdminister);
                ClickControl(itemDataProfile);
            }

            return new DataProfilePage();
        }

        public PanelManagerPage GotoPanelManagerPage()
        {


            if (Constant.Browser == "ie")
            {
                ClickControlByJS(menuAdminister);
                ClickControlByJS(itemPanel);
            }

            else
            {
                ClickControl(menuAdminister);
                ClickControl(itemPanel);
            }

            return new PanelManagerPage();
        }

        public PanelPage GotoPanelPage()
        {
            PanelManagerPage panelManagerPage = GotoPanelManagerPage();
            return panelManagerPage.GoToPanelPage();
        }

        public void GotoPage(string way)
        {
            WaitForControl(menuUser, 5);
            string[] allpages = way.Split('/');
            By lastpage = By.XPath("");
            string currentpagexpath = "//ul/li/a[text()='" + allpages[0] + "']";

            if (allpages.Length == 1)
            {
                //cover trường hợp tới 1 page chính nào đó mà k qua bất kì 1 page nào nữa
                lastpage = By.XPath(currentpagexpath);
                ClickControl(lastpage);
            }
            else
            {
                //trường hợp nếu phải thông qua nhiều page
                for (int b = 1; b < allpages.Length; b++)
                {
                    Actions builder = new Actions(Constant.WebDriver);
                    Actions hoverClick = builder.MoveToElement(FindElement(By.XPath(currentpagexpath)));
                    hoverClick.Build().Perform();
                    string next = "/following-sibling::ul/li/a[text()='" + allpages[b] + "']";
                    currentpagexpath = currentpagexpath + next;
                    lastpage = By.XPath(currentpagexpath);
                }
                ClickControl(lastpage);
            }
        }

        public void DeletePages()
        {
            //int numberitems = CountItems(itemsMainPage);
            //string  xpath = "//div[@id='main-menu']/div/ul/li[2]/a";
            //By curentItemPageXpath = By.XPath("//div[@id='main-menu']/div/ul/li[2]/a");
            //while (GetText(By.XPath(xpath)) != ("Execution Dashboard"))


            By lastxpath = By.XPath("");
            By imtecalss = By.XPath("");
            string xpath = "//div[@id='main-menu']/div/ul/li[5]/a";
            string itemclasscurrent = FindElement(By.XPath(xpath)).GetAttribute("class").ToString();

            if (itemclasscurrent.Equals(""))
            {
                ClickControl(By.XPath(xpath));
                SelectGlobalSetting("Delete");
                AcceptAlert();
            }
            else
            {
              
                    while (itemclasscurrent.Equals("haschild"))
                    {
                        Console.WriteLine(itemclasscurrent);
                        Actions builder = new Actions(Constant.WebDriver);
                        Actions hoverClick = builder.MoveToElement(FindElement(By.XPath(xpath)));
                        hoverClick.Build().Perform();
                        string next = "/following-sibling::ul/li/a";
                        xpath = xpath + next;
                        
                        lastxpath = By.XPath(xpath);
                        
                    }
                    ClickControl(lastxpath);
                    SelectGlobalSetting("Delete");
                    AcceptAlert();
                
            }
            
            //for (int i = 2; i <= numberitems; i++)
            //{
            //    string curentitempagexpath = "//div[@id='main-menu']/div/ul/li[2]/a";
            //    By realitempage = By.XPath(curentitempagexpath);
            //    string itemclass = FindElement(realitempage).GetAttribute("class").ToString();
            //    if (itemclass.Equals(""))
            //    {
            //        ClickControl(realitempage);
            //        SelectGlobalSetting("Delete");
            //        AcceptAlert();
            //    }
            //    else
            //    {
            //        while (itemclass.Equals("haschild"))
            //        {

            //            Actions builder = new Actions(Constant.WebDriver);
            //            Actions hoverClick = builder.MoveToElement(FindElement(By.XPath(curentitempagexpath)));
            //            string next = "/following-sibling::ul/li";
            //            curentitempagexpath = curentitempagexpath + next;
            //            By lastitempage = By.XPath(curentitempagexpath);

            //        }
            //    }



            //}
        }


        public void VerifyWelComeUserDisplayed(string username)
        {
            VerifyText(username, menuUser);
        }


        public void SelectGlobalSetting(string settingname)
        {
            By a = By.XPath("//li/a[text()='" + settingname + "']");
            ClickControl(menuGlobalSetting);
            ClickControl(a);
        }


        public void CreatePage(string pagename, string ispublic, string parentname, string numberclm, string afterpage)
        {
            FindElement(txtPageName).SendKeys(pagename);
            switch (ispublic)
            {
                case "public":
                    FindElement(rdIsPublic).Click();
                    break;
                default:
                    break;
            }
            if (parentname != "")
            {
                new SelectElement(FindElement(drdparentname)).SelectByText(parentname);
            }
            if (afterpage != "")
            {
                new SelectElement(FindElement(drdafterpage)).SelectByText(afterpage);
            }
            if (numberclm != "")
            {
                new SelectElement(FindElement(drdnumberclm)).SelectByText(numberclm);
            }
            ClickControl(btnOK);
        }


        public NewPage GotoNewPage()
        {
            SelectGlobalSetting("Add Page");
            return new NewPage();
        }







    }
}
