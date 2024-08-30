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

        [HttpGet("Mes/{mes}")]
        public async Task<ActionResult<IEnumerable<Parcela>>> GetParcelas(int mes)
        {
            return await _context.Parcelas
                .Where(x => x.MesVencimento == mes)
                .ToListAsync();
        }

        [HttpGet("Mes/{mes}/{idDespesa}")]
        public async Task<ActionResult<IEnumerable<Parcela>>> GetParcelasByMesAndId(int mes, int idDespesa)
        {
            return await _context.Parcelas
                .Where(x => ( x.MesVencimento == mes && x.DespesaId == idDespesa))
                .ToListAsync();
        }

        // GET: api/Parcelas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Parcela>>> GetParcela(int id)
        {
            var parcela = await _context.Parcelas
                .Where(x => x.DespesaId == id)
                .ToListAsync();

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
                if (request.dataCompra.Month + i > 12){
                    request.dataCompra.Year++;
                    i = 0;
                    request.qtdParcelas -= 12;
                }
                var parcela = new Parcela(request.idDespesa, request.valor,
                    request.dataCompra.Day, request.dataCompra.Month + i, request.dataCompra.Year, 0);
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

        private bool ParcelaExists(int id)
        {
            return _context.Parcelas.Any(e => e.Id == id);
        }
    }
}
