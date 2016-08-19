using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumAdvance_Group2.Common;
using OpenQA.Selenium;
using SeleniumAdvance_Group2.PageObject.General;
using System.Threading;

namespace SeleniumAdvance_Group2.PageObject.Panel
{
  public  class ChoosePanelPage:GeneralPage
    {
        public ChoosePanelPage()
        {
            Constant.ChoosePanelDictionary = ReadXML();
        }

        public NewPanelPage GotoNewPanelPage()
        {
            Thread.Sleep(1000); //wait to page load
            ClickControl("create new panel button");
           
            return new NewPanelPage();
        }

        public PanelConfigurationPage GotoConfigurationPage()
        {
            Thread.Sleep(1000);//wait to page loaded
            SelectChartItemPanel();            
            return new PanelConfigurationPage();
            
        }

        public void SelectChartItemPanel ()
        {
            Thread.Sleep(1000);//wait to elements is loated stably
            int numberrows = CountItems("items row in chart");
            int numbercolumn = CountItems("items column in chart");

            int itemRow;
            int itemRowColumn;
            Random i = new Random();
            itemRow = i.Next(1, numberrows);
            Random j = new Random();
            itemRowColumn = j.Next(1, numbercolumn);
          
             string itemNameChart = "//div[@id='container']//div[@class='ptit pchart']/../table//tr["+ itemRow + "]/td["+ itemRowColumn + "]//a";

                   
                        if(Constant.Browser=="ie")
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
