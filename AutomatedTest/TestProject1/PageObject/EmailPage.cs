using NUnit.Framework;
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
        private IWebElement _emailField => _webDriver.FindElement(By.XPath("//input[@type = 'email']"));
        private IWebElement _nextBTN => _webDriver.FindElement(By.XPath("//input[@type = 'submit']"));
        private By _errorMessage => By.Id("usernameError");

        public EmailPage(IWebDriver webDriver, WebDriverWait wait)
        {
            _webDriver = webDriver;
            _wait = wait;
        }
        public void WriteEmailText(string email)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_emailField)).SendKeys(email);
        }
        public void PressNextBTN()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_nextBTN)).Click();
        }

        public void CheckErrorMessage(string exceptedResult)
        {
            string actualResultErrorMessage = _wait.Until(ExpectedConditions
                .ElementIsVisible(_errorMessage))
                .Text;
            Assert.AreEqual(exceptedResult, actualResultErrorMessage);
        }
    }
}
