using OpenQA.Selenium;
using SpecflowTests.Helpers;
using TechTalk.SpecFlow;

namespace SpecflowTests.Hooks
{
    [Binding]
    public class BeforeScenarioHooks
    {
        private ScenarioContext _scenarioContext;

        public BeforeScenarioHooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario, Scope(Tag = "NeedsSelenium")]
        public void Needs_Selenium()
        {
            var driver = SeleniumDriverHelper.CreateChromeDriver();

            _scenarioContext.ScenarioContainer.RegisterInstanceAs<IWebDriver>(driver);
        }
    }
}
