using System;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using selenium;
using Selenium;

namespace tests.classes
{
    public class IMC : BaseClass
    {
        public IMC(IConfiguration configuration, Browser browser) : base(configuration, browser) { }

        public void CarregarPagina()
        {
            _driver.AbrirPaginaNavegador(TimeSpan.FromSeconds(5), _configuration.GetSection("Selenium:UrlAplicacao").Value);
        }

        public void FecharPagina()
        {
            _driver.Quit();
            _driver = null;
        }

        public void preencherIMC(double peso, double altura)
        {
            _driver.AtribuirValor(By.Id("id_Peso"), peso.ToString());
            _driver.AtribuirValor(By.Name("Altura"), altura.ToString());

        }

        public void calcularIMC()
        {
            _driver.Enviar(By.Id("id_btnCalcular"));
            _driver.Esperar(By.Id("ResultImc"), TimeSpan.FromSeconds(10));

        }

        public double obterIMC()
        {
            return Convert.ToDouble(_driver.ObterValor(By.Id("ResultImc")));
        }

        public string obterMensagem()
        {
            return _driver.ObterValor(By.ClassName("alert"));
        }


    }
}
