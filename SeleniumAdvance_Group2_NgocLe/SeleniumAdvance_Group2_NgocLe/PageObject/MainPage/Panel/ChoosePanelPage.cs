using System;
using SeleniumAdvance_Group2.Common;
using OpenQA.Selenium;
using SeleniumAdvance_Group2.PageObject.General;

namespace SeleniumAdvance_Group2.PageObject.MainPage.Panel
{
    public class ChoosePanelPage : GeneralPage
    {
        public ChoosePanelPage()
        {
            if (Constant.ChoosePanelDictionary == null)
                Constant.ChoosePanelDictionary = ReadXML();
        }

        public NewPanelForPage GotoNewPanelPage()
        {
            if (Constant.Browser.Equals("ie"))
            {
                ClickControlByJS("create new panel button");
            }
            else
            {
                ClickControl("create new panel button");
            }
            return new NewPanelForPage();
        }

        public PanelConfigurationPage GotoConfigurationPage()
        {
            SelectChartItemPanel();
            return new PanelConfigurationPage();
        }

        public void SelectChartItemPanel()
        {
            int numberRows = CountItems("items row in chart");
            int numberColumn = CountItems("items column in chart");
            int itemRow;
            int itemRowColumn;
            Random i = new Random();
            itemRow = i.Next(1, numberRows);
            Random j = new Random();
            itemRowColumn = j.Next(1, numberColumn);

            string itemNameChart = "//div[@id='container']//div[@class='ptit pchart']/../table//tr[" + itemRow + "]/td[" + itemRowColumn + "]//a";

            if (Constant.Browser == "ie")
            {
                ClickControlByJS(By.XPath(itemNameChart));
            }
            else
            {
                ClickControl(By.XPath(itemNameChart));
            }
        }
    }
}