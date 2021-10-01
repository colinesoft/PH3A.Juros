using PH3A.Juros.UI.Data;
using System.Collections.Generic;
using System.Web.Http;
using System.Data.Entity;
using System.Linq;
using PH3A.Juros.UI.Models;

namespace PH3A.Juros.WS.Controllers
{
    public class SimulacoesController : ApiController
    {
        private readonly PH3AContext _context = new PH3AContext();
        
        public List<Simulacao> Get()
        {
            var simulacoes = _context.Simulacoes.AsNoTracking()
                .Include(c => c.SimulacaoParcelas)
                .OrderByDescending(a => a.Id)
                .Take(10)
                .ToList();
            return simulacoes;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}
