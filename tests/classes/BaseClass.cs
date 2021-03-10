using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using selenium;

namespace tests.classes
{
    public class BaseClass
    {
        public IConfiguration _configuration;
        private Browser _browser;
        public IWebDriver _driver;
        public BaseClass(IConfiguration configuration, Browser browser)
        {
            _configuration = configuration;
            _browser = browser;

            string pathDriver = null;

            if (_browser == Browser.FireFox)
            {
                pathDriver = _configuration.GetSection("Selenium:PathDriverFirefox").Value;

            }
            else if (_browser == Browser.Chrome)
            {
                pathDriver = _configuration.GetSection("Selenium:PathDriverChrome").Value;
            }
            _driver = WebDriverFactory.CreateWebDriver(browser, pathDriver);
        }
    }
}
