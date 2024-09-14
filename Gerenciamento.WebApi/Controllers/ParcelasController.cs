using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gerenciamento.Domain.Models;

namespace Gerenciamento.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParcelasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ParcelasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Parcelas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Parcela>>> GetParcelas()
        {
            return await _context.Parcelas.ToListAsync();
        }

        [HttpGet("Mes")]
        public async Task<ActionResult<IEnumerable<Parcela>>> GetParcelasByMes(int mes, int ano)
        {
            return await _context.Parcelas
                .Where(x => x.DataVencimento.Month == mes && x.DataVencimento.Year == ano)         
                .ToListAsync();
        }
        // GET: api/Parcelas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Parcela>> GetParcela(int id)
        {
            var parcela = await _context.Parcelas.FindAsync(id); 

            if (parcela == null)
            {
                return NotFound();
            }

            return parcela;
        }
        [HttpGet("Despesa/{id}")]
        public async Task<ActionResult<List<Parcela>>> GetParcelaByDespesa(int id)
        {
            var parcela = await _context.Parcelas.Where(x => x.DespesaId == id).ToListAsync();

            if (parcela == null)
            {
                return NotFound();
            }

            return parcela;
        }


        [HttpGet("Despesa")]
        public async Task<ActionResult<List<Parcela>>> GetParcela(int id, int mes, int ano)
        {
            var parcela = await _context.Parcelas
                   .Where(x => x.DespesaId == id 
                          && x.DataVencimento.Month == mes
                          && x.DataVencimento.Year == ano).ToListAsync();

            if (parcela == null)
            {
                return NotFound();
            }

            return parcela;
        }
        // PUT: api/Parcelas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParcela(int id, Parcela parcela)
        {
            if (id != parcela.Id)
            {
                return BadRequest();
            }

            _context.Entry(parcela).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParcelaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Parcelas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Parcela>> PostParcelas(ParcelasRequest request)
        {
            int[] listId = new int[request.qtdParcelas];

            for (int i = 0; i < request.qtdParcelas; i++)
            {
                var parcela = new Parcela();
                parcela.DespesaId = request.idDespesa;
                parcela.IsPaga = 0;
                parcela.Valor = request.valor;
                parcela.DataVencimento = request.dataCompra.AddMonths(i);

                _context.Parcelas.Add(parcela);
                await _context.SaveChangesAsync();

                listId[i] = parcela.Id;
            }

            return CreatedAtAction("GetParcelas", listId);
        }

        // DELETE: api/Parcelas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParcela(int id)
        {
            var parcela = await _context.Parcelas.FindAsync(id);
            if (parcela == null)
            {
                return NotFound();
            }

            _context.Parcelas.Remove(parcela);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("Despesa/{id}")]
        public async Task<IActionResult> DeleteParcelaByDespesa(int id)
        {
            var parcelas = await _context.Parcelas
                                         .Where(x => x.DespesaId == id)
                                         .ToArrayAsync();
            foreach(var parcela in parcelas)
            {
                _context.Parcelas.Remove(parcela);
                await _context.SaveChangesAsync();
            }
            

            return NoContent();
        }

        private bool ParcelaExists(int id)
        {
            return _context.Parcelas.Any(e => e.Id == id);
        }
    }
}
