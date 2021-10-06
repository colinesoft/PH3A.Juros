using PH3A.Juros.UI.Models;
using PH3A.Juros.UI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PH3A.Juros.UI.Repositories
{
    public class SimulacaoParcelasRepository : Repository<SimulacaoParcela>, ISimulacaoParcelasRepository
    {
        public void GravarSimulacaoParcela(SimulacaoParcela obj)
        {
            Incluir(obj);
        }
    }
}