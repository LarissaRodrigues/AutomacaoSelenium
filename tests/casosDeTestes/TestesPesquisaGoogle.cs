using System.IO;
using Microsoft.Extensions.Configuration;
using selenium;
using tests;
using tests.classes;
using Xunit;

namespace Testes.casosDeTestes
{
    public class TestesPesquisaGoogle : BaseTeste
    {
        public TestesPesquisaGoogle()
        {

        }

        [Fact]
        public void TestarFireFox()
        {
            ExecutaTesteGoogles(Browser.FireFox);

        }

        [Fact]
        public void TestarChrome()
        {
            ExecutaTesteGoogles(Browser.Chrome);

        }

        private void ExecutaTesteGoogles(Browser browser)
        {
            Google testeGoogle = new Google(_configuration, browser);

            testeGoogle.CarregarPagina();
            var results = testeGoogle.BuscaGoogle("Texto");
            //   foreach (IWebElement result in results)
            //   {
            //       Console.WriteLine(result.Text);
            //   }
            Assert.True(results.Count > 0);
            testeGoogle.FecharPagina();
        }
    }
}
