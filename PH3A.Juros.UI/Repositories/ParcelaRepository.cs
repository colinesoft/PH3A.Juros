using PH3A.Juros.UI.Models;
using PH3A.Juros.UI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PH3A.Juros.UI.Repositories
{
    public class ParcelaRepository : Repository<Parcela>, IParcelaRepository
    {
        public IEnumerable<Parcela> BuscarPorTipo(string tipo, double juros)
        {
            return tipo.ToLower() == "capitalizado"
                ? CalculaJurosCapitalizado(juros)
                : CalculaJurosLinear(juros);
        }

        public IEnumerable<Parcela> CalculaJurosCapitalizado(double percJuros)
        {                     
            foreach (var item in _table)
            {
                TimeSpan dif = DateTime.Today - item.DataVencto;
                var atraso = dif.Days > 0 ? dif.Days : 0;
                var atrasoMes = (double)atraso / 30;
                item.Juros = item.Valor * (Math.Pow(1 + percJuros/100, atrasoMes) - 1);
                item.TotalDivida = item.Juros + item.Valor;
            }
            return _table;
        }

        public IEnumerable<Parcela> CalculaJurosLinear(double percJuros)
        {
            foreach (var item in _table)
            {
                TimeSpan dif = DateTime.Today - item.DataVencto;
                var atraso = dif.Days > 0 ? dif.Days : 0;
                var atrasoMes = (double)atraso / 30;
                item.Juros = item.Valor * (percJuros/100) * atrasoMes;
                item.TotalDivida = item.Juros + item.Valor;
            }
            return _table;
        }

    }
}