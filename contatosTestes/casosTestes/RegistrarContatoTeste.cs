using contatosTestes.classes;
using contatosTestes.classesBase;
using selenium;
using Xunit;

namespace contatosTestes.casosTestes
{
    public class RegistrarContatoTeste : BaseTeste

    {
        private void CadastrarContato(Browser browser)
        {
            //Pesquisa
            Login(browser, emailPadrao, senhaEmailPadrao);
            ResgitrarContato registrar = new ResgitrarContato();
            var contatoDTO = registrar.CadastratContato();
            PesquisaContato pesquisar = new PesquisaContato();
            var lista = pesquisar.PesquisarContatoNome(contatoDTO);

            var nomeCadastrado = contatoDTO.Nome;
            Assert.NotNull(contatoDTO);
            Assert.Equal(lista[0], contatoDTO.Nome);
            Assert.Equal(lista[1], contatoDTO.Email);

            //Edita contato 
            var contatoDtoEditado = registrar.EditarContato();
            lista = pesquisar.PesquisarContatoNome(contatoDtoEditado);

            Assert.NotNull(contatoDTO);
            Assert.Equal(lista[0], contatoDtoEditado.Nome);
            Assert.Equal(lista[1], contatoDtoEditado.Email);

            Assert.NotEqual(nomeCadastrado, contatoDtoEditado.Nome);

            //Excluir
            registrar.ExcluirContatoBotaoCancelar();
            lista = pesquisar.PesquisarContatoNome(contatoDtoEditado);
            Assert.Equal(lista[0], contatoDtoEditado.Nome);
            Assert.Equal(lista[1], contatoDtoEditado.Email);
            Assert.NotEqual(nomeCadastrado, contatoDtoEditado.Nome);

            registrar.ExcluirContato();
            var mensagem = pesquisar.PesquisarContatoNomePosDelete(contatoDtoEditado);

            Assert.NotEmpty(mensagem);
            var existe = mensagem.Contains("Não existem contatos cadastrados...");
            Assert.True(existe);

        }
        [Fact(DisplayName = "Chrome - Registrar Contato")]
        public void TestarChrome()
        {
            CadastrarContato(Browser.Chrome);
        }

        [Fact(Skip = "Teste Firefox")]
        public void TestarFirefox()
        {
            CadastrarContato(Browser.FireFox);
        }
    }
}
