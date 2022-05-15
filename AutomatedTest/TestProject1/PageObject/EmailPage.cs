using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectPlanAutomation.PageObject
{
    public class EmailPage
    {
        private IWebDriver _webDriver;
        private WebDriverWait _wait;
        private IWebElement emailField => _webDriver.FindElement(By.XPath("//input[@type = 'email']"));
        private IWebElement nextBTN => _webDriver.FindElement(By.XPath("//input[@type = 'submit']"));
        public EmailPage(IWebDriver webDriver, WebDriverWait wait)
        {
            _webDriver = webDriver;
            _wait = wait;
        }
        public void WriteEmailText(string email)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(emailField)).SendKeys(email);
        }
        public void PressNextBTN()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(nextBTN)).Click();
        }
    }
}
