using System;
using Xunit;

namespace contatosTestes
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var nome = Faker.Name.FullName();
            string firstName = Faker.Name.First();
            var email = Faker.Internet.Email();
            var telefone = Faker.Phone.Number();
            var empresa = Faker.Company.Name();
            var endereco = Faker.Address.StreetName();


            Console.WriteLine($"Nome:{nome}");
            Console.WriteLine($"Primeiro Nome:{firstName}");
            Console.WriteLine($"Email:{email}");
            Console.WriteLine($"Telefone:{telefone}");
            Console.WriteLine($"Empresa:{empresa}");
            Console.WriteLine($"Endereço:{endereco}");

        }
    }
}
