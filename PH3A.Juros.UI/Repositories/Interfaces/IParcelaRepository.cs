using PH3A.Juros.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PH3A.Juros.UI.Repositories.Interfaces
{
    public interface IParcelaRepository: IRepository<Parcela>
    {
        IEnumerable<Parcela> CalculaJurosLinear(double juros);
        IEnumerable<Parcela> CalculaJurosCapitalizado(double juros);
        IEnumerable<Parcela> BuscarPorTipo(string tipo, double juros);
    }
}
