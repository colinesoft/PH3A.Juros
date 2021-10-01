using System;

namespace PH3A.Juros.UI.Models
{
    public class SimulacaoParcela
    {
        public int Id { get; set; }
        public int SimulacaoId { get; set; }
        public int ParcelaId { get; set; }
        public DateTime DataVencto { get; set; }
        public double Valor { get; set; }
        public double TotalJuros { get; set; }
        public double TotalDivida { get; set; }
    }
}