using OpenQA.Selenium;
using System.Threading;

namespace SpecflowTests.Pages
{
    public class LoginPage
    {
        public IWebDriver webDriver { get; }

        public LoginPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public IWebElement LoginTab => webDriver.FindElement(By.Id("loginTab"));
        public IWebElement UserNameInput => webDriver.FindElement(By.Id("userName"));
        public IWebElement PasswordInput => webDriver.FindElement(By.Id("password"));
        public IWebElement LoginBtn => webDriver.FindElement(By.Id("loginButton"));
        public IWebElement UserAccountInfoCard => webDriver.FindElement(By.Id("userInfoCard"));

        public void ClickLoginTab()
        {
            LoginTab.Click();
        }

        public void EnterCredentials(string userName, string password)
        {
            UserNameInput.SendKeys(userName);
            PasswordInput.SendKeys(password);
        }

        public void ClickLoginButton()
        {
            Thread.Sleep(1000); // change with selenium wait
            LoginBtn.Click();
        }

        public bool IsUserLoggedInSuccessfully()
        {
            Thread.Sleep(1000);
            return UserAccountInfoCard.Displayed;
        }
    }
}
