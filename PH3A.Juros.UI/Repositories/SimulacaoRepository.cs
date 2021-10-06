using PH3A.Juros.UI.Models;
using PH3A.Juros.UI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PH3A.Juros.UI.Repositories
{
    public class SimulacaoRepository : Repository<Simulacao>, ISimulacaoRepository
    {
        public void GravarSimulacao(Simulacao obj)
        {
            Incluir(obj);
        }

        public int NovoId()
        {
            return _table.Max(c => c.Id) + 1;
        }
    }
}