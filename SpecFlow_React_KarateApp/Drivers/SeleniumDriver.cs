using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SpecFlowCalculator.Specs.Drivers
{
    public class SeleniumDriver : IDisposable
    {
        private readonly Lazy<IWebDriver> _driver;
        private bool _isDisposed;

        public SeleniumDriver(ScenarioContext scenarioContext)
        {
            _driver = new Lazy<IWebDriver>(CreateWebDriver);
        }

        public IWebDriver Current => _driver.Value;

        private IWebDriver CreateWebDriver()
        {
            var chromeDriverService = ChromeDriverService.CreateDefaultService();

            var chromeOptions = new ChromeOptions();

            var chromeDriver = new ChromeDriver(chromeDriverService, chromeOptions);

            return chromeDriver;
        }

        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }

            if (_driver.IsValueCreated)
            {
                Current.Quit();
            }

            _isDisposed = true;
        }
    }
}
