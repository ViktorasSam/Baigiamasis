using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaigiamasisDenon.Page
{
    public class DenonLoginPage : BasePage
    {
        
        private const string _loginAddress = "https://www.denonsalonai.lt/mano-paskyra";
        private const string _loginName = "baigiamasis123@gmail.com";
        private const string _loginPassword = "testuoju123";
        private const string _expectedPersonalInfo = "JŪSŲ ASMENINĖ INFORMACIJA";

        private IWebElement _loginNameInputBox => Driver.FindElement(By.CssSelector("#login-form > div > div:nth-child(2) > div.col-md-6 > input"));
        private IWebElement _loginPasswordInputBox => Driver.FindElement(By.CssSelector("#login-form > div > div:nth-child(3) > div.col-md-6 > div > input"));
        private IWebElement _loginButton => Driver.FindElement(By.CssSelector("#submit-login"));
        private IWebElement _loginInfo => Driver.FindElement(By.CssSelector("#identity-link > span"));
        private IWebElement _personalInfoText => Driver.FindElement(By.CssSelector("#main > header > h1"));
        public DenonLoginPage(IWebDriver webDriver) : base(webDriver) { }

        public DenonLoginPage NavigateToLoginPage()
        {
            if (Driver.Url != _loginAddress)
            {
                Driver.Url = _loginAddress;
            }
            return this;
        }

        public DenonLoginPage ClickLoginButton()
        {
            _loginButton.Click();

            return this;
                
        }

        public DenonLoginPage InsertLoginName()
        {
            _loginNameInputBox.Clear();
            _loginNameInputBox.SendKeys(_loginName);

            return this;
        }
        public DenonLoginPage InsertLoginPassword()
        {
            _loginPasswordInputBox.Clear();
            _loginPasswordInputBox.SendKeys(_loginPassword);

            return this;
        }
        public DenonLoginPage PressLoginButton()
        {
            _loginButton.Click();

            return this;
        }
        public DenonLoginPage PressLoginInfoButton()
        {
            _loginInfo.Click();

            return this;
        }
        public DenonLoginPage VerifyLoginName()
        {
            Assert.AreEqual(_expectedPersonalInfo, _personalInfoText.Text, "Login is wrong or Enter wasnt completed");

            return this;
        }

    }
}
