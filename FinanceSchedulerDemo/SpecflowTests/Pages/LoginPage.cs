using OpenQA.Selenium;
using SpecflowTests.Extensions;

namespace SpecflowTests.Pages
{
    public class LoginPage
    {
        public IWebDriver webDriver { get; }

        public LoginPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public IWebElement LoginTab => webDriver.FindElement(By.Id("loginTab"), 1);
        public IWebElement UserNameInput => webDriver.FindElement(By.Id("userName"), 1);
        public IWebElement PasswordInput => webDriver.FindElement(By.Id("password"), 1);
        public IWebElement LoginBtn => webDriver.FindElement(By.Id("loginButton"), 1);
        public IWebElement UserAccountInfoCard => webDriver.FindElement(By.Id("userInfoCard"), 3);

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
            LoginBtn.Click();
        }

        public bool IsUserLoggedInSuccessfully()
        {
            return UserAccountInfoCard.Displayed;
        }
    }
}
