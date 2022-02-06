using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecflowTests.Pages;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecflowTests.Steps
{
    [Binding]
    public sealed class LoginSteps
    {
        private const string Url = "http://localhost:5000/";
        private readonly LoginPage loginPage;
        private readonly IWebDriver webDriver;
        private readonly ChromeOptions chromeOptions;

        public LoginSteps(IWebDriver webDriver, LoginPage loginPage, ChromeOptions chromeOptions)
        {
            this.chromeOptions = chromeOptions;
            chromeOptions.AddArguments("--headless", "--disable-gpu", "--window-size=1920,1080");
            this.webDriver = webDriver;
            this.loginPage = loginPage;
        }

        [Given(@"I launch the app")]
        public void GivenILaunchTheApp()
        {
            webDriver.Navigate().GoToUrl(Url);
        }

        [Given(@"I click the Sign In button")]
        public void GivenIClickTheSignInButton()
        {
            loginPage.ClickLoginTab();
        }

        [Given(@"I enter the following credentials")]
        public void GivenIEnterTheFollowingCredentials(Table table)
        {
            var credentials = table.CreateDynamicInstance();

            loginPage.EnterCredentials((string)credentials.Username, (string)credentials.Password);
        }

        [Given(@"I click submit button button")]
        public void GivenIClickSubmitButtonButton()
        {
            loginPage.ClickLoginButton();
        }

        [Then(@"I should see the user account page")]
        public void ThenIShouldSeeTheUserAccountPage()
        {
            Assert.That(loginPage.IsUserLoggedInSuccessfully(), Is.True);
        }
    }
}
