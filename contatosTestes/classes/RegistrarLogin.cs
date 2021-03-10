using contatosTestes.classesBase;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using selenium;

namespace contatosTestes.classes
{
    public class RegistrarLogin : BaseClass
    {
        public RegistrarLogin(IConfiguration configuration, Browser browser) :
         base(configuration, browser)
        {

        }

        public string RegistrarUsuario(string email, string senha)
        {
            _driver.Esperar(By.Name("RegistrarUsuario"));
            _driver.Clique(By.Name("RegistrarUsuario"));
            _driver.Esperar(By.XPath("/html/body/div/main/div/div/form/h4"));
            _driver.AtribuirValor(By.Id("Input_Email"), email);
            _driver.AtribuirValor(By.Id("Input_Password"), senha);
            _driver.AtribuirValor(By.Id("Input_ConfirmPassword"), senha);
            _driver.Enviar(By.ClassName("btn"));


            _driver.Esperar(By.Id("confirm-link"));
            _driver.Clique(By.Id("confirm-link"));

            _driver.Esperar(By.LinkText("Logar"));
            _driver.Clique(By.LinkText("Logar"));


            _driver.Esperar(By.Id("Input_Email"));
            _driver.AtribuirValor(By.Id("Input_Email"), email);
            _driver.AtribuirValor(By.Id("Input_Password"), senha);
            _driver.Clique(By.Id("Input_RememberMe"));
            _driver.Enviar(By.ClassName("btn"));

            _driver.Esperar(By.Id("UserIdentityEmailId"));

            return _driver.ObterValor(By.Id("UserIdentityEmailId"));

        }

        public string UsuarioJaRegistrado(string email, string senha)
        {
            _driver.Esperar(By.Name("RegistrarUsuario"));
            _driver.Clique(By.Name("RegistrarUsuario"));
            _driver.Esperar(By.Id("Input_Email"));
            _driver.AtribuirValor(By.Id("Input_Email"), email);
            _driver.AtribuirValor(By.Id("Input_Password"), senha);
            _driver.AtribuirValor(By.Id("Input_ConfirmPassword"), senha);
            _driver.Enviar(By.ClassName("btn"));


            _driver.Esperar(By.XPath("html/body/div/main/div/div/form/div[1]/ul/li"));

            return _driver.ObterValor(By.XPath("html/body/div/main/div/div/form/div[1]/ul/li"));


        }

        public string Login(string email, string senha)
        {
            _driver.Esperar(By.Name("btnLogarPrincipalId"));
            _driver.Clique(By.Name("btnLogarPrincipalId"));


            _driver.Esperar(By.Id("Input_Email"));
            _driver.AtribuirValor(By.Id("Input_Email"), email);
            _driver.AtribuirValor(By.Id("Input_Password"), senha);
            _driver.Clique(By.Id("Input_RememberMe"));
            _driver.Enviar(By.ClassName("btn"));

            _driver.Esperar(By.Id("UserIdentityEmailId"));

            return _driver.ObterValor(By.Id("UserIdentityEmailId"));
        }

    }
}
