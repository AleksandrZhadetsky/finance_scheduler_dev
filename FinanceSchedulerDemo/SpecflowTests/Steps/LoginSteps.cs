using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecflowTests.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecflowTests.Steps
{
    [Binding]
    public sealed class LoginSteps
    {
        LoginPage loginPage = null; // DI it also
        IWebDriver webDriver;

        public LoginSteps()
        {
            var chromeOptions = new ChromeOptions(); // DI it and all other
            chromeOptions.AddArguments("--headless", "--disable-gpu", "--window-size=1920,1080");
            webDriver = new ChromeDriver(chromeOptions);
        }

        [Given(@"I launch the app")]
        public void GivenILaunchTheApp()
        {
            webDriver.Navigate().GoToUrl("http://localhost:5000/");
            loginPage = new LoginPage(webDriver);
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
            Thread.Sleep(500);
            Assert.That(loginPage.IsUserLoggedInSuccessfully(), Is.True);
        }

    }
}
