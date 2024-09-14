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
    public class DespesasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DespesasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Despesas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Despesa>>> GetDespesas()
        {
            return await _context.Despesas.ToListAsync();
        }
        
        [HttpGet("Ano")]
        public async Task<ActionResult<IEnumerable<Despesa>>> GetDespesasByAno(int ano)
        {
            return await _context.Despesas
                .Where(x => x.DataCompra.Year == ano)
                .ToListAsync();
        }

        [HttpGet("Parceladas")]
        public async Task<ActionResult<IEnumerable<Despesa>>> GetDespesasParceladas(int mes, int ano)
        {   
            return await _context.Despesas
                   .Where(d => _context.Parcelas.Any(p => p.DespesaId == d.Id && p.DataVencimento.Month == mes && p.DataVencimento.Year == ano))
                   .ToListAsync();     
        }

        [HttpGet("Adicionais")]
        public async Task<ActionResult<IEnumerable<Despesa>>> GetDespesasAdicionais(int ano)
        {
            return await _context.Despesas
                .Where(x => !x.IsParcelada && x.DataCompra.Year == ano)
                .ToListAsync();
        }

        // GET: api/Despesas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Despesa>> GetDespesa(int id)
        {
            var despesa = await _context.Despesas.FindAsync(id);

            if (despesa == null)
            {
                return NotFound();
            }

            return despesa;
        }
        [HttpGet("Mes")]
        public async Task<ActionResult<IEnumerable<Despesa>>> GetDespesasPoMes(int mes, int ano)
        {
            return await _context.Despesas
                .Where(x => (x.DataCompra.Month == mes && x.DataCompra.Year == ano) || x.IsParcelada)
                .ToListAsync();
        }

        // PUT: api/Despesas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDespesa(int id, Despesa despesa)
        {
            if (id != despesa.Id)
            {
                return BadRequest();
            }

            _context.Entry(despesa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DespesaExists(id))
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

        // POST: api/Despesas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Despesa>> PostDespesa(Despesa despesa)
        {
            _context.Despesas.Add(despesa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDespesa", new { id = despesa.Id }, despesa);
        }

        // DELETE: api/Despesas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDespesa(int id)
        {
            var despesa = await _context.Despesas.FindAsync(id);
            if (despesa == null)
            {
                return NotFound();
            }

            _context.Despesas.Remove(despesa);
            await _context.SaveChangesAsync();

            if (despesa.IsParcelada)
            {
                var parcelas = _context.Parcelas.Where<Parcela>(x => x.DespesaId == despesa.Id).ToArrayAsync();
                foreach (var parcela in parcelas.Result)
                {
                    _context.Parcelas.Remove(parcela);
                }
            }

            return NoContent();
        }

        private bool DespesaExists(int id)
        {
            return _context.Despesas.Any(e => e.Id == id);
        }
    }
}
