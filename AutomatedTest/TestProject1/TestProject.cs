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
        public void LoginWithInvalidEmail()
        {
            LogInPage logInPage = new LogInPage(webDriver, wait);
            logInPage.ClickLogInButton();

            EmailPage emailPage = new EmailPage(webDriver, wait);
            emailPage.WriteEmailText("hello @ . com");
            emailPage.PressNextBTN();
            emailPage.CheckErrorMessage("Enter a valid email address, phone number or Skype name.");
        }


        [Test]
        public void FilterNotificationByEntityType()
        {
            LoginSuccessfulIntoAdminAccount();

            HomePage homePage = new HomePage(webDriver, wait);
            homePage.ClickNotificationBTN();
            homePage.ClickFilterIcon();
            homePage.ClickEntityType();
            homePage.FindEntityType("Opportunity");
            homePage.ChooseOportunityType();
        }

        [Test]
        public void SearchProjectWithSpecificWord()
        {
            LoginSuccessfulIntoAdminAccount();

            HomePage homePage = new HomePage(webDriver, wait);
            homePage.OpenProjectPage();
            homePage.WriteProjectName("Amdaris");
            homePage.FindProjectByName("Amdaris");
            homePage.CheckNumberOfResults();

        }
        [Test]
        public void SearchInexistingProject()
        {
            LoginSuccessfulIntoAdminAccount();

            HomePage homePage = new HomePage(webDriver, wait);
            homePage.OpenProjectPage();
            homePage.WriteProjectName("----");
            homePage.FindInexistingProject("No Such Projects");

        }
    }
}