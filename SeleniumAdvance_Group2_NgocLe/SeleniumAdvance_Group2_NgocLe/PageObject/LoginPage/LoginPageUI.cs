using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAdvance_Group2.PageObject.LoginPage
{
    class LoginPageUI
    {
        public static readonly By ddlRespository = By.Id("repository");
        public static readonly By txtUserName = By.Id("username");
        public static readonly By txtPassWord = By.Id("password");
        public static readonly By btnLogin = By.XPath("//div[@id='content']//div[@class='btn-login']");
    }
}
