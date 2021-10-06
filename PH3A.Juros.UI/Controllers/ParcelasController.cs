using PH3A.Juros.UI.Data;
using PH3A.Juros.UI.Models;
using PH3A.Juros.UI.Repositories;
using PH3A.Juros.UI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PH3A.Juros.UI.Controllers
{
    public class ParcelasController: Controller
    {
        private readonly IParcelaRepository _parcelaRepository;
        private readonly ISimulacaoRepository _simulacaoRepository;

        public ParcelasController(IParcelaRepository parcelaRepository, ISimulacaoRepository simulacaoRepository):base()
        {
            _parcelaRepository = parcelaRepository;
            _simulacaoRepository = simulacaoRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Table(decimal? juros, string tipo)
        {
            juros = juros == null ? 0 : juros;
            //Obtem uma lista das parcelas calculadas de acordo com o tipo
            List<Parcela> parcelas = _parcelaRepository.BuscarPorTipo(tipo, (double)juros).ToList();

            ViewBag.TotalJuros = parcelas.Sum(c => c.Juros);
            ViewBag.TotalDivida = parcelas.Sum(c => c.TotalDivida);


            if (juros!=0)
            {
                int newId = _simulacaoRepository.NovoId();
                Simulacao simulacao = new Simulacao()
                {
                    DataSimulacao = DateTime.Now,
                    PercentualJuros = (double)juros,
                    TipoJuros = tipo,
                    Id = newId,
                    SimulacaoParcelas = new List<SimulacaoParcela>()
                };
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
                    simulacao.SimulacaoParcelas.Add(simulacaoParcela);
                }
                //Grava toda a simulação
                _simulacaoRepository.GravarSimulacao(simulacao);
            }

            return PartialView("_Table", parcelas);
        }

        [HttpGet]
        public ActionResult Save(int? id)
        {
            Parcela parcela = new Parcela();
            if(id != null)
            {
                parcela = _parcelaRepository.Buscar((int)id);
            }
            return View(parcela);
        }

        [HttpPost]
        public ActionResult Save(Parcela parcela)
        {
            if (parcela.Id == 0)
                _parcelaRepository.Incluir(parcela);
            else
                _parcelaRepository.Alterar(parcela);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Parcela parcela = _parcelaRepository.Buscar(id);
            if(parcela != null)
                _parcelaRepository.Excluir(parcela);
            return null;
        }
    }
}