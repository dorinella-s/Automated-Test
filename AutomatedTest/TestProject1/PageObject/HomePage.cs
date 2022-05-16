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
        private IWebElement _notifcationBTN => _webDriver.FindElement(By.CssSelector("button.notification-icon > span"));
        private IWebElement _filterIcon => _webDriver.FindElement(By.CssSelector("div.actions > button:first-child"));
        private IWebElement _entityTypeItem => _webDriver.FindElement(By.XPath("//mat-select[@formcontrolname = 'typeId' or @placeholder = 'Entity Type']"));
        private IWebElement _entityTypeElement => _webDriver.FindElement(By.CssSelector("mat-option:nth-child(2)>span.mat-option-text"));
        private IWebElement _oportunityType => _webDriver.FindElement(By.CssSelector("mat-option:nth-child(2)>span.mat-option-text"));
        private IWebElement _projectBTN => _webDriver.FindElement(By.CssSelector("a#projects-tab"));
        private IWebElement _searchField => _webDriver.FindElement(By.CssSelector("input.input-search"));
        private IWebElement _searchResult => _webDriver.FindElement(By.CssSelector("app-project-item > div > div > a > h5 > span"));
        private IWebElement _searchNotFound => _webDriver.FindElement(By.XPath(("//div[contains(text(),'No Such Projects')]")));
        private By _numberOfResults => By.CssSelector("div.num");
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
                .ElementToBeClickable(_notifcationBTN))
                .Click();
        }

        public void ClickFilterIcon()
        {
            _wait.Until(ExpectedConditions
                .ElementToBeClickable(_filterIcon))
                .Click();
        }

        public void ClickEntityType()
        {
            _wait.Until(ExpectedConditions
                .ElementToBeClickable(_entityTypeItem))
                .Click();
        }

        public void FindEntityType(string exceptedResult)
        {
            string actualResultFilterText = _wait.Until(ExpectedConditions
                .ElementToBeClickable(_entityTypeElement))
                .Text;
            Assert.AreEqual(exceptedResult, actualResultFilterText);
        }
        public void ChooseOportunityType()
        {
            _wait.Until(ExpectedConditions
                .ElementToBeClickable(_oportunityType))
                .Click();
        }

        public void OpenProjectPage()
        {
            _wait.Until(ExpectedConditions
                .ElementToBeClickable(_projectBTN))
                .Click();
        }

        public void WriteProjectName(string name)
        {
            _wait.Until(ExpectedConditions
                .ElementToBeClickable(_searchField))
                .SendKeys(name);
        }
        public void FindProjectByName(string expectedResult)
        {
            string actualSearchResult = _wait.Until(ExpectedConditions
                                            .ElementToBeClickable(_searchResult))
                                            .Text;
            Assert.That(actualSearchResult, Does.Contain(expectedResult).IgnoreCase);
        }

        public void CheckNumberOfResults()
        {
            string actualSearchResult = _wait.Until(ExpectedConditions
                .ElementIsVisible(_numberOfResults))
                .Text;
            Assert.IsNotNull(actualSearchResult);
        }

        public void FindInexistingProject(string expectedResult)
        {
            string actualSearchResult = _wait.Until(ExpectedConditions
                                            .ElementToBeClickable(_searchNotFound))
                                            .Text;
            Assert.That(actualSearchResult, Does.Contain(expectedResult).IgnoreCase);


        }

        
    }
}
