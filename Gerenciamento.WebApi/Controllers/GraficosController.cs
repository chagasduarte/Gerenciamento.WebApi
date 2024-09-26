using Gerenciamento.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<ActionResult<IEnumerable<Graficos>>> GetGraficos(int ano)
        { 
            List<Graficos> Graficos = new List<Graficos>();
            var Despesas = _context.Despesas.GroupBy(x => x.DataCompra.Year).ToListAsync().Result.Where(x => x.Key == ano);
            var Parcelas = _context.Parcelas.ToListAsync().Result;
            var Entradas = _context.Entradas.ToListAsync().Result;
            var Contas = _context.Contas.ToListAsync().Result;

            foreach(var despesa in Despesas)
            {
                Graficos grafico = new Graficos();
                var meses = despesa.GroupBy(x => x.DataCompra.Month);
                foreach(var mes in meses)
                {
                    Mes m = new Mes();
                    m.Id = mes.Key;
                    decimal saidas = 0;

                    //calcula saidas das compras adicionais
                    foreach (var desp in mes)
                    {
                        if (!desp.IsParcelada)
                        {
                            saidas += desp.ValorTotal;
                        }
                    }
                    m.Saida = saidas;

                    //calcula as parceladas
                    var parcelas = Parcelas.Where(x => x.DataVencimento.Month == mes.Key
                                                    && x.DataVencimento.Year == despesa.Key
                                                    );
                    foreach( var parcela in parcelas)
                    {
                        m.Saida += parcela.Valor;
                    }


                    //calculando as entradas
                    var entradas = Entradas.Where(x => x.DataDebito.Month == mes.Key
                                                    && x.DataDebito.Year == despesa.Key);
                    decimal ent = 0;
                    foreach (var entrada in entradas)
                    {
                        ent += entrada.Valor;
                    }
                    m.Entrada = ent;


                    //calculando a progressão.
                    var contas = Contas.Where(x => x.Mes == mes.Key && x.Ano == despesa.Key);
                    decimal progressao = 0;
                    foreach(var conta in contas)
                    {
                        progressao += conta.Debito;
                    }

                    m.Progressao = progressao;

                    grafico.Meses.Add(m);
                }
                Graficos.Add(grafico);
            }
            return Ok(Graficos);
        }

    }
}
