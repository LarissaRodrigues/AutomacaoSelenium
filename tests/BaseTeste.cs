using System.IO;
using Microsoft.Extensions.Configuration;

namespace tests
{
    public abstract class BaseTeste
    {
        public IConfiguration _configuration;

        public BaseTeste()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            _configuration = builder.Build();
            var path = _configuration.GetSection("Selenium:PathDriverChrome");

        }
    }
}
