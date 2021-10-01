using PH3A.Juros.UI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PH3A.Juros.UI.Data
{
    public class PH3AContext: DbContext
    {
        public PH3AContext() : base(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PH3A;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        {
            Database.SetInitializer(new DbInitializer());
        }

        public DbSet<Parcela> Parcelas { get; set; }
        public DbSet<Simulacao> Simulacoes { get; set; }
        public DbSet<SimulacaoParcela> SimulacoesParcelas { get; set; }
    }
}