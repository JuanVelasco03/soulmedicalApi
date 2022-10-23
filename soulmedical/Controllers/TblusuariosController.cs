using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using soulmedical.Models.bd;

namespace soulmedical.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblusuariosController : ControllerBase
    {
        private readonly SoulMedicalContext _context;

        public TblusuariosController(SoulMedicalContext context)
        {
            _context = context;
        }

        // GET: api/Tblusuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tblusuario>>> GetTblusuarios()
        {
          if (_context.Tblusuarios == null)
          {
              return NotFound();
          }
            return await _context.Tblusuarios.ToListAsync();
        }

        // GET: api/Tblusuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tblusuario>> GetTblusuario(int id)
        {
          if (_context.Tblusuarios == null)
          {
              return NotFound();
          }
            var tblusuario = await _context.Tblusuarios.FindAsync(id);

            if (tblusuario == null)
            {
                return NotFound();
            }

            return tblusuario;
        }

        [HttpGet("{TraDocumento2}/{Userclave}")]
        public ActionResult<List<Tblusuario>> GetIniciarSesion(int TraDocumento2, string Userclave)
        {
            if (_context.Tblusuarios == null)
            {
                return NotFound();
            }

            var tblusuario = _context.Tblusuarios.Where(usuario => usuario.TraDocumento2.Equals(TraDocumento2) && usuario.Userclave.Equals(Userclave)).ToList();

            if (tblusuario == null)
            {
                return NotFound();
            }

            return tblusuario;
        }

        // PUT: api/Tblusuarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblusuario(int id, Tblusuario tblusuario)
        {
            if (id != tblusuario.Userid)
            {
                return BadRequest();
            }

            _context.Entry(tblusuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblusuarioExists(id))
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

        // POST: api/Tblusuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tblusuario>> PostTblusuario(Tblusuario tblusuario)
        {
          if (_context.Tblusuarios == null)
          {
              return Problem("Entity set 'SoulMedicalContext.Tblusuarios'  is null.");
          }
            _context.Tblusuarios.Add(tblusuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblusuario", new { id = tblusuario.Userid }, tblusuario);
        }

        // DELETE: api/Tblusuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblusuario(int id)
        {
            if (_context.Tblusuarios == null)
            {
                return NotFound();
            }
            var tblusuario = await _context.Tblusuarios.FindAsync(id);
            if (tblusuario == null)
            {
                return NotFound();
            }

            _context.Tblusuarios.Remove(tblusuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblusuarioExists(int id)
        {
            return (_context.Tblusuarios?.Any(e => e.Userid == id)).GetValueOrDefault();
        }
    }
}
