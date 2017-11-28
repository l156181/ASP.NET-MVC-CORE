using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.IO;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace entity_linq_parte_1_crie_queries_poderosas_em_c_
{
    class Program
    {

        static void Main(string[] args)
        {


            Program p = new Program();
            string directoryDataFolder = @"data\";
            string fileName = "AluraTunes.xml";
            string pathXml = Path.Combine(Environment.CurrentDirectory, directoryDataFolder,fileName);
           
            p.LinqToXml(pathXml);         

            
        }

       static void GetConnectionStrings() {
       //         var configuration = new IConfigurationBuilder()
       //         .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
       //        .AddJsonFile("appsettings.json", false)
       //       .Build();
       }

        public void LinqToXml(string URI){
            XElement root = XElement.Load(URI);
            var queryXML = from g in root.Element("Generos").Elements("Genero")
                           join m in root.Element("Musicas").Elements("Musica")
                                on g.Element("GeneroId").Value equals m.Element("GeneroId").Value
                           select new 
                           {
                               MusicaId = m.Element("MusicaId").Value,
                               Musica= m.Element("Nome").Value,
                               Genero= g.Element("Nome").Value        
                            };

            foreach( var musicaEGenero in queryXML){
                Console.WriteLine("{0}\t{1}\t{2}",musicaEGenero.MusicaId ,musicaEGenero.Musica, musicaEGenero.Genero);
            }             

        }

        public void LinqToObject(){
             var generos = new List<Genero>
            {
                new Genero { Id = 1, Nome = "Rock" },
                new Genero { Id = 2, Nome = "Reggae" },
                new Genero { Id = 3, Nome = "Rock Progressivo" },
                new Genero { Id = 4, Nome = "Jazz" },
                new Genero { Id = 5, Nome = "Punk Rock" },
                new Genero { Id = 6, Nome = "Classica" }
            };

            var musicas = new List<Musica>
            {
                new Musica { Id = 1, Nome = "Sweet Child O'Mine", GeneroId = 1 },
                new Musica { Id = 2, Nome = "I Shot The Sheriff", GeneroId = 2 },
                new Musica { Id = 3, Nome = "Danúbio Azul", GeneroId = 6 }
            };

            var queryGenero = from g in generos
                              where g.Nome.Contains("Rock")
                              select g;

            var musicaQuery = from m in musicas
                              join g in generos on m.GeneroId equals g.Id
                              select new {m,g}; 
                        
            foreach (var musica in musicaQuery){
                Console.WriteLine("{0}\t{1}\t{2}", musica.m.Id, musica.m.Nome,musica.g.Nome);
            }
                        
        }
    }

    class Genero{
        public int Id { get; set; }
        public string Nome { get; set; }
    }

     class Musica{
        public int Id { get; set; }
        public string Nome { get; set; }

        public int GeneroId { get; set; }
    }
}
