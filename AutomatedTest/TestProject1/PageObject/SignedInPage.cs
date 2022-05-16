using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectPlanAutomation.PageObject
{
    class SignedInPage
    {
        private IWebDriver _webDriver;
        private WebDriverWait _wait;
        private IWebElement _yesBTN => _webDriver.FindElement(By.XPath("//input[@type = 'submit']"));

        public SignedInPage(IWebDriver webDriver, WebDriverWait wait)
        {
            _webDriver = webDriver;
            _wait = wait;
        }
        public void ClickYesButton()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_yesBTN)).Click();
        }


    }
}
