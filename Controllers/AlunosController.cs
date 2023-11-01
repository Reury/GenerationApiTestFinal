using GenerationApiTestFinal.Context;
using GenerationApiTestFinal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GenerationTestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly MeuDbContext _context;

        public AlunosController(MeuDbContext context)
        {
            _context = context;
        }
        // GET: api/<AlunosController>
        [HttpGet]
        public async Task<IActionResult> Index()
        {

            return Ok(await _context.Alunos.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                aluno.Id = Guid.NewGuid();
                _context.Add(aluno);
                await _context.SaveChangesAsync();
                return Ok(aluno);
            }
            else
            {
                return BadRequest();
            };

        }

        [HttpPut]
        public async Task<IActionResult> Edit(Guid id, [Bind("Nome,Idade,materias")] Aluno aluno)
        {
            if (id != aluno.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aluno);
                    await _context.SaveChangesAsync();
                    return Ok(aluno);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlunoExists(aluno.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return Ok();
        }
        [HttpDelete]
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (_context.Alunos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Alunos'  is null.");
            }
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno != null)
            {
                _context.Alunos.Remove(aluno);
            }

            await _context.SaveChangesAsync();
            return Ok();
        }


        private bool AlunoExists(Guid id)
        {
            return _context.Alunos.Any(e => e.Id == id);
        }







    }
}
