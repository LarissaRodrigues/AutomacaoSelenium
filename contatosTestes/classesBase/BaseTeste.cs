using System.IO;
using contatosTestes.classes;
using Microsoft.Extensions.Configuration;
using selenium;
using Xunit;

namespace contatosTestes.classesBase
{
    public abstract class BaseTeste
    {
        public IConfiguration _configuration;

        public string emailPadrao { get; set; }
        public string senhaEmailPadrao { get; set; }

        public BaseTeste()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            _configuration = builder.Build();
            var path = _configuration.GetSection("Selenium:PathDriverChrome");

            emailPadrao = "selenium@mail.com";
            senhaEmailPadrao = "Mudar@123";

        }

        public void Login(Browser browser, string email, string senha)
        {
            RegistrarLogin login = new RegistrarLogin(_configuration, browser);
            login.CarregarPagina();
            var usuarioLogado = login.Login(email, senha);

            Assert.NotEmpty(usuarioLogado);
            var existe = usuarioLogado.Contains(email);
            Assert.True(existe);
        }
    }
}
