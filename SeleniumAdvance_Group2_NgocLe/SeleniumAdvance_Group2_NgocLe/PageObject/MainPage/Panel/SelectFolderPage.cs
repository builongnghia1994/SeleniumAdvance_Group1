using System;
using SeleniumAdvance_Group2.Common;
using SeleniumAdvance_Group2.PageObject.General;
using OpenQA.Selenium;

namespace SeleniumAdvance_Group2.PageObject.MainPage.Panel
{
    public class SelectFolderPage : GeneralPage
    {
        public SelectFolderPage()
        {
            if (Constant.SelectFolderPageDictionary == null)
                Constant.SelectFolderPageDictionary = ReadXML();
        }

        public PanelConfigurationPage GotoPanelConfigurationPageAfterSelectFolder(string path)
        {
            GotoFolder(path);
            ClickControl("ok button");
            return new PanelConfigurationPage();
        }

        public void GotoFolder(string pathfolder)
        {
            WaitForPageLoad();
            string[] allpathfolders = pathfolder.Split('/');
            By lastfolder = By.XPath("");
            string currentfolderxpath = "//div[@id='async_html_2']//tbody/tr/td[2]//input[@value='/" + allpathfolders[0] + "']";
            Console.WriteLine(currentfolderxpath);
            if (allpathfolders.Length == 1)
            {
                lastfolder = By.XPath(currentfolderxpath);
                ClickControl(lastfolder);
            }
            else
            {
                string next = string.Empty;
                for (int b = 1; b < allpathfolders.Length; b++)
                {

                    ClickControl(By.XPath(currentfolderxpath + "/../a[1]"));

                    next += "/" + allpathfolders[b];
                    currentfolderxpath = "//div[@id='async_html_2']//tbody/tr/td[2]//input[@value='/" + allpathfolders[0] + next + "']";
                    Console.WriteLine(currentfolderxpath);

                }
                lastfolder = By.XPath(currentfolderxpath + "/../a[2]");
                Console.WriteLine(lastfolder);
                if (Constant.Browser == "ie")
                {
                    WaitForPageLoad();
                    ClickControlByJS(lastfolder);
                }
                else
                {
                    WaitForPageLoad();
                    ClickControl(lastfolder);
                }
            }
        }
        
    }
}
