using SeleniumAdvance_Group2.PageObject.General;
using SeleniumAdvance_Group2.Common;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SeleniumAdvance_Group2.PageObject.Panel
{
    public class PanelManagerPage : GeneralPage
    {
        public PanelManagerPage()
        {
            if (Constant.PanelManagerDictionary == null)
                Constant.PanelManagerDictionary = ReadXML();
        }
        public NewPanelPage GoToPanelPage()
        {
            ClickControl("add new link");
            return new NewPanelPage();
        }

        public void VerifyPanelDisplayed(string panelName)
        {
            int panelItemCount = CountItems("panel table");

            for (int i = 2; i < panelItemCount; i++)
            {
                string row = "//table[@class='GridView']//tr[" + i + "]/td[2]";

                if (FindElement(By.XPath(row)).Text == panelName)
                {
                    Assert.IsTrue(true);
                    return;
                }

            }
            Assert.Fail("Panel does not exist.");

        }



    }
}

