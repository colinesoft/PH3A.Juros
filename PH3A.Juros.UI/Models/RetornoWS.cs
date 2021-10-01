using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PH3A.Juros.UI.Models
{
    public class RetornoWS
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public double TotalJuros { get; set; }
        public double TotalDivida { get; set; }
        public string TipoJuros { get; set; }
        public decimal PercentualJuros { get; set; }
    }
}