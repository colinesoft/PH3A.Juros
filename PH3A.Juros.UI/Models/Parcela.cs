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
        public string TipoJuros { get; set; }

        public Parcela()
        {

        }
        public void CalculaJuros(decimal? juros, string tipo)
        {
            TimeSpan dif = DateTime.Today - this.DataVencto;
            var atraso = dif.Days > 0 ? dif.Days : 0;
            var atrasoMes = (double)atraso/30;
            double percJuros = (double)juros / 100;

            if(tipo == "Linear" || tipo == null)
                this.Juros = Valor * percJuros * atrasoMes;
            else
                this.Juros = Valor * (Math.Pow(1+percJuros, atrasoMes)-1);
            this.TotalDivida = this.Juros + this.Valor;
            this.TipoJuros = tipo;
        }
    }
}