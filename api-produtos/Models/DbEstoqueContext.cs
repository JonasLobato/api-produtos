using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace api_produtos.Models
{
    public class DbEstoqueContext : DbContext
    {
        public DbSet<EstoqueProduto> EstoqueProdutos { get; set; }

        public string DbPath { get; }

        public DbEstoqueContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "EstoqueAPI-Ecommerc.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
    }
    
}