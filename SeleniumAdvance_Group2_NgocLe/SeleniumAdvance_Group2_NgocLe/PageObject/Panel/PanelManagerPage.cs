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
            WaitForPageLoad();
            int panelItemCount = CountItems("panel table");

            string row = string.Empty;

            for (int i = 2; i < panelItemCount; i++)
            {
                row = "//table[@class='GridView']//tr[" + i + "]/td[2]";

                if (FindElement(By.XPath(row)).Text == panelName)
                {
                    Assert.IsTrue(true);
                    return;
                }

            }
            Assert.Fail("Panel does not exist.");
        }

        public void DeletePanel(string panelName)
        {
            int panelItemCount = CountItems("panel table");

            string row = string.Empty;
            string checkbox = string.Empty;

            for (int i = 2; i < panelItemCount; i++)
            {
                row = "//table[@class='GridView']//tr[" + i + "]/td[2]";

                if (FindElement(By.XPath(row)).Text == panelName)
                {
                    checkbox = "//table[@class='GridView']//tr[" + i + "]/td[1]";
                    ClickControl(By.XPath(checkbox));
                    ClickControl("delete link");
                    AcceptAlert();
                    return;
                }
            }
        }

        public void DeleteAllPanel()
        {
            int panelItemCount = CountItems("panel table");

            if (panelItemCount > 1)
            {
                string checkAllElement = "//table[@class='GridView']//tr[" + panelItemCount.ToString() + "]/td[1]/a[text()='Check All']";

                ClickControl(By.XPath(checkAllElement));
                ClickControl("delete link");
                AcceptAlert();
            }
        }
    }
}

