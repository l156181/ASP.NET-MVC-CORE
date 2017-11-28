using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;
using entity_linq_parte_1_crie_queries_poderosas_em_c_.Model;


namespace entity_linq_parte_1_crie_queries_poderosas_em_c_.Model{
    public class BloggingContext : DbContext
    {
        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Artista> Artistas { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Faixa> Faixas { get; set; }
        public virtual DbSet<Funcionario> Funcionarios { get; set; }
        public virtual DbSet<Genero> Generos { get; set; }
        public virtual DbSet<ItemNotaFiscal> ItemNotaFiscals { get; set; }
        public virtual DbSet<NotaFiscal> NotaFiscals { get; set; }
        public virtual DbSet<Playlist> Playlists { get; set; }
        public virtual DbSet<TipoMidia> TipoMidias { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
                optionsBuilder.UseSqlServer("Data Source=blogging.db");
        }          
    }
}