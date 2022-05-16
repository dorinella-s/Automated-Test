using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectPlanAutomation.PageObject
{
    class PasswordPage
    {
        private IWebDriver _webDriver;
        private WebDriverWait _wait;
        private By _passwdField => By.XPath("//input[@type = 'password']");
        private IWebElement _nextBTN => _webDriver.FindElement(By.XPath("//input[@type = 'submit']"));
        public PasswordPage(IWebDriver webDriver, WebDriverWait wait)
        {
            _webDriver = webDriver;
            _wait = wait;
        }
        public void WritePasswdText(string passwd)
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(_passwdField)).SendKeys(passwd);
        }
        public void PressNextBTN()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_nextBTN)).Click();
        }
    }
}

