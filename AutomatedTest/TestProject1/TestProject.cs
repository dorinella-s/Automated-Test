using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ProjectPlanAutomation.PageObject;
using SeleniumExtras.WaitHelpers;
using System.Threading;

namespace ProjectPlanAutomation
{
    public class ProjectPlanAutomation : SetUp
    {

        [Test]
        public void LoginSuccessfulIntoAdminAccount()
        {
            LogInPage logInPage = new LogInPage(webDriver, wait);
            logInPage.ClickLogInButton();

            EmailPage emailPage = new EmailPage(webDriver, wait);
            emailPage.WriteEmailText("automation.pp@amdaris.com");
            emailPage.PressNextBTN();

            PasswordPage passwordPage = new PasswordPage(webDriver, wait);
            passwordPage.WritePasswdText("10704-observe-MODERN-products-STRAIGHT-69112");
            passwordPage.PressNextBTN();

            SignedInPage signedInPage = new SignedInPage(webDriver, wait);
            signedInPage.ClickYesButton();

            HomePage homePage = new HomePage(webDriver, wait);
            homePage.GetUserHelloText("Hi Automation");
           
        }


        [Test]
        public void FilterNotificationByEntityType()
        {
            LogInPage logInPage = new LogInPage(webDriver, wait);
            logInPage.ClickLogInButton();

            EmailPage emailPage = new EmailPage(webDriver, wait);
            emailPage.WriteEmailText("automation.pp@amdaris.com");
            emailPage.PressNextBTN();

            PasswordPage passwordPage = new PasswordPage(webDriver, wait);
            passwordPage.WritePasswdText("10704-observe-MODERN-products-STRAIGHT-69112");
            passwordPage.PressNextBTN();

            SignedInPage signedInPage = new SignedInPage(webDriver, wait);
            signedInPage.ClickYesButton();

            HomePage homePage = new HomePage(webDriver, wait);
            homePage.GetUserHelloText("Hi Automation");
            homePage.ClickNotificationBTN();
            homePage.ClickFilterIcon();
            homePage.ClickEntityType();
            homePage.FindEntityType("Opportunity");
            homePage.ChooseOportunityType();
        }

        [Test]
        public void SearchProjectWithSpecificWord()
        {
            LogInPage logInPage = new LogInPage(webDriver, wait);
            logInPage.ClickLogInButton();

            EmailPage emailPage = new EmailPage(webDriver, wait);
            emailPage.WriteEmailText("automation.pp@amdaris.com");
            emailPage.PressNextBTN();

            PasswordPage passwordPage = new PasswordPage(webDriver, wait);
            passwordPage.WritePasswdText("10704-observe-MODERN-products-STRAIGHT-69112");
            passwordPage.PressNextBTN();

            SignedInPage signedInPage = new SignedInPage(webDriver, wait);
            signedInPage.ClickYesButton();

            HomePage homePage = new HomePage(webDriver, wait);
            homePage.GetUserHelloText("Hi Automation");
            homePage.OpenProjectPage();
            homePage.WriteProjectName("Amdaris");
            homePage.FindProjectByName("Amdaris");

        }

    }
}