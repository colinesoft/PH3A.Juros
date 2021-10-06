using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PH3A.Juros.UI.Models
{
    public class Parcela
    {
        public int Id { get; set; }
        public DateTime DataVencto { get; set; }
        public double Valor { get; set; }

        //Calculados
        public double Juros { get; set; }
        public double TotalDivida { get; set; }
    }
}