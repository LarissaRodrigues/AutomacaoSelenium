using System.IO;
using Microsoft.Extensions.Configuration;
using selenium;
using tests;
using tests.classes;
using Xunit;

namespace Testes.casosDeTestes
{
    public class TestesIMC : BaseTeste
    {
        public TestesIMC()
        {

        }
        [Fact]
        public void TestarFireFox()
        {
            ExecutaTesteIMC(Browser.FireFox, 85, 1.74, 28.08, "Acima do Peso");

        }

        [Fact]
        public void TestarChrome()
        {
            ExecutaTesteIMC(Browser.Chrome, 50, 1.75, 16.33, "Muito abaixo do peso");

        }

        private void ExecutaTesteIMC(Browser browser, double peso, double altura, double valorEsperado, string mensagemEsperada)
        {
            IMC imc = new IMC(_configuration, browser);

            imc.CarregarPagina();
            imc.preencherIMC(peso, altura);
            imc.calcularIMC();
            var resultado = imc.obterIMC();
            var mensagem = imc.obterMensagem();
            //   imc.FecharPagina();

            Assert.True(resultado > 0);
            Assert.Equal(valorEsperado, resultado);

            Assert.NotEmpty(mensagem);
            Assert.Equal(mensagemEsperada, mensagem);
            var contem = mensagem.Contains(mensagemEsperada);
            Assert.True(contem);


        }

    }
}
