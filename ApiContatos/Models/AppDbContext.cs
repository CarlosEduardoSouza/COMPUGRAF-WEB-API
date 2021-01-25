using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ApiContatos.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("ContatoContext") { }
        public DbSet<Pessoa> Pessoas { get; set; }

    }
}