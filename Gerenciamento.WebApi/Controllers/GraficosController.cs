using Gerenciamento.Domain.Enums;
using Gerenciamento.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Gerenciamento.WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class GraficosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GraficosController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<Graficos>> GetGraficos(int ano)
        { 
            Graficos grafico = new Graficos();
            var Despesas = _context.Despesas.Where(x => x.DataCompra.Year == ano).ToListAsync().Result;
            var Parcelas = _context.Parcelas.Where(x => x.DataVencimento.Year == ano).ToListAsync().Result;
            var Entradas = _context.Entradas.Where(x => x.DataDebito.Year == ano).ToListAsync().Result;
            var Contas = _context.Contas.Where(x => x.Ano == ano).ToListAsync().Result;

            for(int i = 1; i <= 12; i++)
            {
                Mes m = new Mes();
                m.Id = i;
                m.Entrada = 0;
                m.Saida = 0;
                m.Progressao = 0;

                var despesas = Despesas.Where(x => x.DataCompra.Month == i && !x.IsParcelada);
                foreach (var desp in despesas)
                {
                    m.Saida += desp.ValorTotal;
                }

                var parcelas = Parcelas.Where(x => x.DataVencimento.Month == i);
                foreach (var parcela in parcelas)
                {
                    m.Saida += parcela.Valor;
                }

                var entradas = Entradas.Where(x => x.DataDebito.Month == i);
                foreach (var entrada in entradas)
                {
                    m.Entrada += entrada.Valor;
                }

                var contas = Contas.Where(x => x.Mes == i);
                foreach (var conta in contas)
                {
                    m.Progressao += conta.Debito;
                }

                m.NomeAbrev = new CultureInfo("pt-BR").DateTimeFormat.GetAbbreviatedMonthName(i);

                grafico.Meses.Add(m);

            }
            foreach (TipoDespesa tipo in Enum.GetValues(typeof(TipoDespesa)))
            {
                TipoDespesaAgrupada tipoDespesaAgrupada = new TipoDespesaAgrupada();
                tipoDespesaAgrupada.TipoDespesa = tipo;

                //despesas adicionais
                var Adicionais = Despesas.Where(x => !x.IsParcelada && x.TipoDespesa == tipo);

                foreach(Despesa despesa in Adicionais)
                {
                    tipoDespesaAgrupada.ValorTotal += despesa.ValorTotal;
                }

                var Parceladas = Despesas.Where(x => x.IsParcelada && x.TipoDespesa == tipo);
                foreach(Despesa despesa in Parceladas)
                {
                    var parcelas = Parcelas.Where(x => x.DespesaId == despesa.Id);
                    foreach(Parcela parcela in parcelas)
                    {
                        tipoDespesaAgrupada.ValorTotal += parcela.Valor;
                    }
                }

                grafico.TipoDespesaAgrupada.Add(tipoDespesaAgrupada);
                
            }
            
            return Ok(grafico);
        }

    }
}
