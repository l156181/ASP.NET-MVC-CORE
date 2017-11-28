using System;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace alura_tunes_entities
{
    class Program
    {
        static void Main(string[] args)
        {    
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
            .AddJsonFile("appsettings.json", false)
            .Build();
        }
    }
}
