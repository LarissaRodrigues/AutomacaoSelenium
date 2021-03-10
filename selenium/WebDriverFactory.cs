using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace selenium
{
    public static class WebDriverFactory
    {
        public static IWebDriver CreateWebDriver(Browser browser, string pathDriver = null)
        {
            IWebDriver webDriver = null;

            switch (browser)
            {
                case Browser.FireFox:
                    FirefoxOptions options = new FirefoxOptions();
                    options.AcceptInsecureCertificates = true;
                    webDriver = new FirefoxDriver(pathDriver, options);

                    break;
                case Browser.Chrome:
                    ChromeOptions optionsChrome = new ChromeOptions();
                    optionsChrome.AcceptInsecureCertificates = true;
                    webDriver = new ChromeDriver(pathDriver, optionsChrome);
                    break;

            }
            return webDriver;
        }
    }


}
