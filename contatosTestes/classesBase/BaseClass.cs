using System;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using selenium;

namespace contatosTestes.classesBase
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
            _driver = Driver.GetNewInstance(configuration, browser);
        }

        public void CarregarPagina()
        {
            _driver.AbrirPaginaNavegador(TimeSpan.FromSeconds(5), _configuration.GetSection("Selenium:UrlAplicacao").Value);
        }

        public void FecharPagina()
        {
            _driver.Quit();
            _driver = null;
        }
    }
}
