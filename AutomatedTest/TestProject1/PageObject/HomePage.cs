using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectPlanAutomation.PageObject
{
    class HomePage
    {
        private IWebDriver _webDriver;
        private WebDriverWait _wait;
        private By helloUser => By.CssSelector("div .page-overview > div:nth-child(2)>div>div>h1");
        private IWebElement notifcationBTN => _webDriver.FindElement(By.CssSelector("button.notification-icon > span"));
        private IWebElement filterIcon => _webDriver.FindElement(By.CssSelector("div.actions > button:first-child"));
        private IWebElement entityTypeItem => _webDriver.FindElement(By.XPath("//mat-select[@formcontrolname = 'typeId' or @placeholder = 'Entity Type']"));
        private IWebElement entityTypeElement => _webDriver.FindElement(By.CssSelector("mat-option:nth-child(2)>span.mat-option-text"));
        private IWebElement oportunityType => _webDriver.FindElement(By.CssSelector("mat-option:nth-child(2)>span.mat-option-text"));
        private IWebElement projectBTN => _webDriver.FindElement(By.CssSelector("a#projects-tab"));
        private IWebElement searchField => _webDriver.FindElement(By.CssSelector("input.input-search"));
        private IWebElement searchResult => _webDriver.FindElement(By.CssSelector("app-project-item > div > div > a > h5 > span"));
        public HomePage(IWebDriver webDriver, WebDriverWait wait)
        {
            _webDriver = webDriver;
            _wait = wait;
        }
        public void GetUserHelloText(string exceptedResult)
        {
            string actualResultStartText = _wait.Until(ExpectedConditions
                .ElementIsVisible(helloUser))
                .Text;
            Assert.AreEqual(exceptedResult, actualResultStartText);
        }

        public void ClickNotificationBTN()
        {
            _wait.Until(ExpectedConditions
                .ElementToBeClickable(notifcationBTN))
                .Click();
        }

        public void ClickFilterIcon()
        {
            _wait.Until(ExpectedConditions
                .ElementToBeClickable(filterIcon))
                .Click();
        }

        public void ClickEntityType()
        {
            _wait.Until(ExpectedConditions
                .ElementToBeClickable(entityTypeItem))
                .Click();
        }

        public void FindEntityType(string exceptedResult)
        {
            string actualResultFilterText = _wait.Until(ExpectedConditions
                .ElementToBeClickable(entityTypeElement))
                .Text;
            Assert.AreEqual(exceptedResult, actualResultFilterText);
        }
        public void ChooseOportunityType()
        {
            _wait.Until(ExpectedConditions
                .ElementToBeClickable(oportunityType))
                .Click();
        }

        public void OpenProjectPage()
        {
            _wait.Until(ExpectedConditions
                .ElementToBeClickable(projectBTN))
                .Click();
        }

        public void WriteProjectName(string name)
        {
            _wait.Until(ExpectedConditions
                .ElementToBeClickable(searchField))
                .SendKeys(name);
        }
        public void FindProjectByName(string expectedResult)
        {
            string actualSearchResult = _wait.Until(ExpectedConditions
                                            .ElementToBeClickable(searchResult))
                                            .Text;
            Assert.That(actualSearchResult, Does.Contain(expectedResult).IgnoreCase);
        }
    }
}
