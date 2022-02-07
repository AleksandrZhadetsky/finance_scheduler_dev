using NUnit.Framework;
using OpenQA.Selenium;
using SpecflowTests.Pages;
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

        public LoginSteps(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            this.loginPage = new LoginPage(webDriver);
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
            dynamic credentials = table.CreateDynamicInstance();

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
            Assert.True(loginPage.IsUserLoggedInSuccessfully());
        }
    }
}
