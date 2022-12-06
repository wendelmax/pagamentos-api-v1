using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pagamentos_api_v1.Model;

namespace pagamentos_api_v1.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class PagamentosController : ControllerBase
    {
        private readonly AppDbContext _context;
        public PagamentosController(AppDbContext context)
        {
            _context = context;
        }
        // GET: api/Pagamentos
        [HttpGet]
        [Route("api/[controller]")]
        [ApiKey]
        public async Task<ActionResult<IEnumerable<Pagamento>>> GetPagamentos()
        {
            return await _context.Pagamentos.ToListAsync();
        }
        // GET: api/Pagamentos/5
        [HttpGet("{id}")]
       //[ApiKey]
        public async Task<ActionResult<Pagamento>> GetPagamento(int id)
        {
            var pagamento = await _context.Pagamentos.FindAsync(id);
            if (pagamento == null)
            {
                return NotFound();
            }
            return pagamento;
        }
        // PUT: api/Pagamentos/5
        [HttpPut("{id}")]
       //[ApiKey]
        public async Task<IActionResult> PutPagamento(int id, Pagamento pagamento)
        {
            if (id != pagamento.PagamentoId)
            {
                return BadRequest();
            }
            _context.Entry(pagamento).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PagamentoExists(id))
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
        // POST: api/Pagamentos
        [HttpPost]
       //[ApiKey]
        public async Task<ActionResult<Pagamento>> PostPagamento(Pagamento pagamento)
        {
            _context.Pagamentos.Add(pagamento);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetPagamento", new { id = pagamento.PagamentoId }, pagamento);
        }
        // DELETE: api/Pagamentos/5
        [HttpDelete("{id}")]
       //[ApiKey]
        public async Task<ActionResult<Pagamento>> DeletePagamento(int id)
        {
            var pagamento = await _context.Pagamentos.FindAsync(id);
            if (pagamento == null)
            {
                return NotFound();
            }
            _context.Pagamentos.Remove(pagamento);
            await _context.SaveChangesAsync();
            return pagamento;
        }
        private bool PagamentoExists(int id)
        {
            return _context.Pagamentos.Any(e => e.PagamentoId == id);
        }
    }
}