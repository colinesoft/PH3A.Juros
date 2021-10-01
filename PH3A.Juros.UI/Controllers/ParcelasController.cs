using PH3A.Juros.UI.Data;
using PH3A.Juros.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PH3A.Juros.UI.Controllers
{
    public class ParcelasController: Controller
    {
        private readonly PH3AContext _context = new PH3AContext();

        public ActionResult Index(decimal? juros, string tipo)
        {
            var parcelas = CalculaParcelas(juros, tipo);
            return View(parcelas);
        }

        [HttpPost]
        public ActionResult Table(decimal? juros, string tipo, bool gravar)
        {
            var parcelas = CalculaParcelas(juros, tipo);
            ViewBag.TotalJuros = parcelas.Sum(c => c.Juros);
            ViewBag.TotalDivida = parcelas.Sum(c => c.TotalDivida);

            if (gravar)
            {
                int newId = _context.Simulacoes.Max(c => c.Id)+1;
                Simulacao simulacao = new Simulacao()
                {
                    DataSimulacao = DateTime.Now,
                    PercentualJuros = (double)juros,
                    TipoJuros = tipo,
                    Id = newId
                };
                _context.Simulacoes.Add(simulacao);

                foreach (var item in parcelas)
                {
                    SimulacaoParcela simulacaoParcela = new SimulacaoParcela()
                    {
                        DataVencto = item.DataVencto,
                        ParcelaId = item.Id,
                        SimulacaoId = newId,
                        TotalDivida = item.TotalDivida,
                        TotalJuros = item.Juros,
                        Valor = item.Valor
                    };
                    _context.SimulacoesParcelas.Add(simulacaoParcela);
                }
                _context.SaveChanges();
            }

            return PartialView("_Table", parcelas);
        }

        [HttpGet]
        public ActionResult Save(int? id)
        {
            Parcela parcela = new Parcela();
            if(id != null)
            {
                parcela = _context.Parcelas.Find(id);
            }
            return View(parcela);
        }

        [HttpPost]
        public ActionResult Save(Parcela parcela)
        {
            if(parcela.Id == 0) //Insert
            {
                _context.Parcelas.Add(parcela);                
            } else //Update
            {
                _context.Entry(parcela).State = System.Data.Entity.EntityState.Modified;
            }
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var parcela = _context.Parcelas.Find(id);

            if(parcela == null)
            {
                return HttpNotFound();
            }
            _context.Parcelas.Remove(parcela);
            _context.SaveChanges();
            return null;
        }

        private List<Parcela> CalculaParcelas(decimal? juros, string tipo)
        {
            if (juros == null) juros = 0;
            if (tipo == null) tipo = "Linear";
            var parcelas = _context.Parcelas
                .OrderBy(c => c.DataVencto)
                .ToList();

            foreach (var item in parcelas)
                item.CalculaJuros(juros, tipo);
            return parcelas;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose(); 
        }
    }
}