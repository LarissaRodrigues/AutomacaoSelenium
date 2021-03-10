
using System;
using System.Collections.ObjectModel;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using selenium;
using Selenium;

namespace tests.classes
{
    public class Google: BaseClass
    {
        public Google(IConfiguration configuration, Browser browser): base(configuration, browser)
        {
        }

        public void CarregarPagina()
        {
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            _driver.Navigate().GoToUrl("http://www.google.com.br");
        }

        public ReadOnlyCollection<IWebElement> BuscaGoogle(string conteudo)
        {
            IWebElement webElement = _driver.FindElement(By.Name("q"));
            webElement.SendKeys(conteudo);
            webElement.SendKeys(Keys.Enter);

            IWebElement resultsSeawch = _driver.FindElement(By.Id("search"));
            return resultsSeawch.FindElements(By.XPath(".//a"));

        }


        public void FecharPagina()
        {
            _driver.Quit();
            _driver = null;
        }

    }
}
