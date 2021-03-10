using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using selenium;

namespace contatosTestes.classesBase
{
    public static class Driver
    {
        private static IWebDriver _Instance { get; set; }

        public static IWebDriver GetNewInstance(IConfiguration configuration, Browser browser)
        {

            string pathDriver = null;

            if (browser == Browser.FireFox)
            {
                pathDriver = configuration.GetSection("Selenium:PathDriverFirefox").Value;

            }
            else if (browser == Browser.Chrome)
            {
                pathDriver = configuration.GetSection("Selenium:PathDriverChrome").Value;
            }
            _Instance = WebDriverFactory.CreateWebDriver(browser, pathDriver);

            return _Instance;

        }

        public static IWebDriver GetIntance()
        {

            return _Instance;

        }
    }
}
