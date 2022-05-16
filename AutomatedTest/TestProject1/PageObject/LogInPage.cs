using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectPlanAutomation.PageObject
{
    public class LogInPage
    {
        private IWebDriver _webDriver;
        private WebDriverWait _wait;
        private IWebElement _logInBTN => _webDriver.FindElement(By.CssSelector(".button > span"));

        public LogInPage(IWebDriver webDriver, WebDriverWait wait)
        {
            _webDriver = webDriver;
            _wait = wait;
        }
        public void ClickLogInButton()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_logInBTN)).Click();
        }
    }
}
