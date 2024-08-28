using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fhi.Kompetanse.Risk.Domenemodell.Entities;
using Fhi.Kompetanse.Risk.WebApi.Data;

namespace Fhi.Kompetanse.Risk.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RiskSpillController : ControllerBase
    {
        private readonly RiskContext _context;

        public RiskSpillController(RiskContext context)
        {
            _context = context;
        }

        // GET: api/Risks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RiskSpill>>> GetRiskSpill()
        {
            return await _context.RiskSpill.ToListAsync();
        }

        // GET: api/Risks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RiskSpill>> GetRiskSpill(int id)
        {
            var riskSpill = await _context.RiskSpill.FindAsync(id);

            if (riskSpill == null)
            {
                return NotFound();
            }

            return riskSpill;
        }

        // PUT: api/Risks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRisk(int id, RiskSpill riskSpill)
        {
            if (id != riskSpill.RiskSpillId)
            {
                return BadRequest();
            }

            _context.Entry(riskSpill).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RiskSpillExists(id))
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

        // POST: api/Risks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RiskSpill>> PostRisk(RiskSpill riskSpill)
        {
            _context.RiskSpill.Add(riskSpill);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRiskSpill", new { id = riskSpill.RiskSpillId }, riskSpill);
        }

        // DELETE: api/Risks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRiskSpill(int id)
        {
            var riskSpill = await _context.RiskSpill.FindAsync(id);
            if (riskSpill == null)
            {
                return NotFound();
            }

            _context.RiskSpill.Remove(riskSpill);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RiskSpillExists(int id)
        {
            return _context.RiskSpill.Any(e => e.RiskSpillId == id);
        }
    }
}
