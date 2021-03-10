using System;
using contatosTestes.classesBase;
using OpenQA.Selenium;
using selenium;

namespace contatosTestes.classes
{
    public class ResgitrarContato
    {
        private contatoDto _contato = null;
        private IWebDriver _driver = null;

        public ResgitrarContato()
        {
            _driver = Driver.GetIntance();

            _contato = new contatoDto();

            _contato.Nome = Faker.Name.FullName();

            Random numeroAleatorio = new Random();
            int numeroSorteado = numeroAleatorio.Next(1, 4);
            switch (numeroSorteado)
            {
                case 1: _contato.EstadoCivil = "Solteiro"; break;
                case 2: _contato.EstadoCivil = "Casado"; break;
                case 3: _contato.EstadoCivil = "Viúvo"; break;
                case 4: _contato.EstadoCivil = "Outros"; break;
                default: _contato.EstadoCivil = "Outros"; break;
            }

            _contato.Endereco = Faker.Address.StreetAddress();
            _contato.Cidade = Faker.Address.City();

            string[] siglaEstados = {
                "AC","AL","AP","AM","BA","CE","DF","ES","GO","MA", "MT", "MS","MG","PA", "PB", "PR", "PE", "PI", "RJ", "RN", "RS", "RO", "RR", "SC", "SE", "TO"
            };

            numeroSorteado = numeroAleatorio.Next(0, 26);
            _contato.Estado = siglaEstados[numeroSorteado];
            _contato.Cep = Faker.Address.ZipCode();
            _contato.Telefone = Faker.Phone.Number();
            _contato.Email = Faker.Internet.Email();
        }

        public contatoDto CadastratContato()
        {
            _driver.Esperar(By.LinkText("Contato"));
            _driver.Clique(By.LinkText("Contato"));

            _driver.Esperar(By.Name("btnCriar"));
            _driver.Clique(By.Name("btnCriar"));

            _driver.Esperar(By.Id("nomeId"));

            _driver.AtribuirValor(By.Id("nomeId"), _contato.Nome);
            _driver.Clique(By.Id(_contato.EstadoCivil));
            _driver.AtribuirValor(By.Id("enderecoId"), _contato.Endereco);
            _driver.AtribuirValor(By.Id("cidadeId"), _contato.Cidade);
            _driver.AtribuirSelectByValue(By.Id("estadoId"), _contato.Estado);
            _driver.AtribuirValor(By.Id("cepId"), _contato.Cep);
            _driver.AtribuirValor(By.Id("telefoneId"), _contato.Telefone);
            _driver.AtribuirValor(By.Id("emailId"), _contato.Email);
            _driver.Enviar(By.Name("btnGravar"));

            // _driver.Quit();
            return _contato;
        }

        public contatoDto EditarContato()
        {
            _contato.Nome = Faker.Name.FullName();
            _driver.Esperar(By.LinkText("Editar"));
            _driver.Clique(By.LinkText("Editar"));
            _driver.Esperar(By.Id("nomeId"));
            _driver.AtribuirValor(By.Id("nomeId"), _contato.Nome);
            _driver.Enviar(By.Name("btnGravar"));

            return _contato;

        }

        public void ExcluirContato()
        {
            _driver.Esperar(By.LinkText("Deletar"));
            _driver.Clique(By.LinkText("Deletar"));

            _driver.Esperar(By.ClassName("modal-dialog"));
            _driver.Clique(By.Name("bntConfirmar"));
        }


        public void ExcluirContatoBotaoCancelar()
        {
            _driver.Esperar(By.LinkText("Deletar"));
            _driver.Clique(By.LinkText("Deletar"));

            _driver.Esperar(By.ClassName("modal-dialog"));
            _driver.Clique(By.Name("bntCancelar"));
        }
    }
}
