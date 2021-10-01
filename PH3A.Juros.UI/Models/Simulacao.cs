using System;
using System.Collections.Generic;

namespace PH3A.Juros.UI.Models
{
    public class Simulacao
    {
        public int Id { get; set; }
        public DateTime DataSimulacao { get; set; }
        public double PercentualJuros { get; set; }
        public string TipoJuros { get; set; }

        public List<SimulacaoParcela> SimulacaoParcelas { get; set; }
    }
}