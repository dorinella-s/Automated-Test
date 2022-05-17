using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectPlanAutomation.PageObject
{
    public class LogInPage : SetUp
    {
        private IWebElement _logInBTN => webDriver.FindElement(By.CssSelector(".button > span"));

        public LogInPage(IWebDriver webDriver, WebDriverWait wait)
        {
            base.webDriver = webDriver;
            base.wait = wait;
        }
        public void ClickLogInButton()
        {
            wait.Until(ExpectedConditions
                .ElementToBeClickable(_logInBTN))
                .Click();
        }
    }
}
