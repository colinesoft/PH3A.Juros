using PH3A.Juros.UI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace PH3A.Juros.UI.Data
{
    internal class DbInitializer : CreateDatabaseIfNotExists<PH3AContext>
    {
        //Reescreve método de alimentar BD ao criar
        protected override void Seed(PH3AContext context)
        {
            //Iniciais - PARCELAS
            var parcelas = new List<Parcela>()
            {
                new Parcela() { DataVencto = Convert.ToDateTime("05/09/2021") , Valor = 755.0},
                new Parcela() { DataVencto = Convert.ToDateTime("09/09/2021") , Valor = 265.44},
                new Parcela() { DataVencto = Convert.ToDateTime("15/10/2021") , Valor = 689.20},
                new Parcela() { DataVencto = Convert.ToDateTime("19/10/2021") , Valor = 105.15},
                new Parcela() { DataVencto = Convert.ToDateTime("25/10/2021") , Valor = 935.60 }
            };
            context.Parcelas.AddRange(parcelas);

            //Iniciais - SIMULACOES
            var simulacoes = new List<Simulacao>()
            {
                new Simulacao() { DataSimulacao = Convert.ToDateTime("30/09/2021"), PercentualJuros = 10, TipoJuros = "sample"},
            };
            context.Simulacoes.AddRange(simulacoes);

            //Iniciais - SIMULACOES
            var simulacoesParcelas = new List<SimulacaoParcela>();
            foreach (var item in parcelas)
            {
                simulacoesParcelas.Add(new SimulacaoParcela()
                {
                    DataVencto = item.DataVencto,
                    ParcelaId = item.Id,
                    SimulacaoId = item.Id,
                    TotalDivida = item.TotalDivida,
                    TotalJuros = item.Juros,
                    Valor = item.Valor
                });
            }
            context.SimulacoesParcelas.AddRange(simulacoesParcelas);
            context.SaveChanges();
        }
    }
}