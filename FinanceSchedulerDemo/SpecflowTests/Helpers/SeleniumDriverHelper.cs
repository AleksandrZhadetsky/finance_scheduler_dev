using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace SpecflowTests.Helpers
{
    internal class SeleniumDriverHelper
    {
        private const string ChromeBinaryLocationEnvironmentVariableName = "CHROME_BINARY_LOCATION";

        public static ChromeDriver CreateChromeDriver()
        {
            var chromeOptions = new ChromeOptions();

            SetChromeBinaryLocation(chromeOptions);
            chromeOptions.PageLoadStrategy = PageLoadStrategy.Normal;
            chromeOptions.AddArguments("--headless", "--disable-gpu", "--window-size=1920,1080");

            var driver = new ChromeDriver(chromeOptions);

            return driver;
        }

        private static void SetChromeBinaryLocation(ChromeOptions chromeOptions)
        {
            var chromeBinaryLocation = Environment.GetEnvironmentVariable(
                ChromeBinaryLocationEnvironmentVariableName, EnvironmentVariableTarget.Machine);

            if (!string.IsNullOrWhiteSpace(chromeBinaryLocation))
            {
                chromeOptions.BinaryLocation = chromeBinaryLocation;
            }
        }
    }
}