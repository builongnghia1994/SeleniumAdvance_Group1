using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumAdvance_Group2.Common;
using OpenQA.Selenium;

namespace SeleniumAdvance_Group2.PageObject
{
    public class LoginPage:GeneralPage
    {
        private readonly By ddlRespository = By.Id("repository");
        private readonly By txtUserName = By.Id("username");
        private readonly By txtPassWord = By.Id("password");
        private readonly By btnLogin = By.XPath("//div[@id='content']//div[@class='btn-login']");


        public GeneralPage Login()
        {
            SelectItemByDropdownList(ddlRespository, Constant.Respository);
            TypeValue(txtUserName, Constant.UserName);
            TypeValue(txtPassWord, Constant.PassWord);
            ClickControl(btnLogin);
            return new GeneralPage();
        }
    }
    jhfj
}
