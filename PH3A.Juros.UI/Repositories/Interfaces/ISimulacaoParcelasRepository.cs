﻿using PH3A.Juros.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PH3A.Juros.UI.Repositories.Interfaces
{
    public interface ISimulacaoParcelasRepository: IRepository<SimulacaoParcela>
    {
        void GravarSimulacaoParcela(SimulacaoParcela obj);
    }
}
