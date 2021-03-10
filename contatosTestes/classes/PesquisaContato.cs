using System.Collections.Generic;
using contatosTestes.classesBase;
using OpenQA.Selenium;
using selenium;

namespace contatosTestes.classes
{
    public class PesquisaContato
    {
        private IWebDriver _driver = null;

        public PesquisaContato()
        {
            _driver = Driver.GetIntance();
        }

        public List<string> PesquisarContatoNome(contatoDto contatoDto)
        {
            _driver.Esperar(By.Id("nomeFiltro"));
            _driver.AtribuirValor(By.Id("nomeFiltro"), contatoDto.Nome);
            _driver.Clique(By.Name("btnFiltrar"));

            return _driver.ObsterValorTabela(By.Id("tabelaId"));

        }
        public string PesquisarContatoNomePosDelete(contatoDto contatoDto)
        {
            _driver.Esperar(By.Id("nomeFiltro"));
            _driver.AtribuirValor(By.Id("nomeFiltro"), contatoDto.Nome);
            _driver.Clique(By.Name("btnFiltrar"));
            _driver.Esperar(By.ClassName("alert"));

            return _driver.ObterValor(By.ClassName("alert"));

        }

    }
}
