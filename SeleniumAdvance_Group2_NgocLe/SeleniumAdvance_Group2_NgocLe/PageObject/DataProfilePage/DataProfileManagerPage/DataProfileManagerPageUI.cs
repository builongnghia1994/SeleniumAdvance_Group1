using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAdvance_Group2.PageObject.DataProfilePage.DataProfileManagerPage
{
    class DataProfileManagerPageUI
    {
        public static By tblDataProfile = By.XPath("//table[@class='GridView']/tbody/tr");
    }
}
