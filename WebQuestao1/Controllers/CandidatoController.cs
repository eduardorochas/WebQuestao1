using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebQuestao1.Data;
using WebQuestao1.Models;

namespace WebQuestao1.Controllers
{
    public class CandidatoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CandidatoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Candidato
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Candidato
                    .Include(c => c.Cargo);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Candidato/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidato = await _context.Candidato
                .Include(c => c.Cargo)
                .FirstOrDefaultAsync(m => m.CandidatoID == id);
            if (candidato == null)
            {
                return NotFound();
            }

            return View(candidato);
        }

        // GET: Candidato/Create
        public IActionResult Create()
        {
            ViewData["CargoID"] = new SelectList(_context.Cargo, "CargoID", "Nome");
            ViewData["Idiomas"] = new MultiSelectList(_context.LinguaEstrangeira, "LinguaEstrangeiraID", "Nome");
            var candidato = new Candidato();
            candidato.Horarios = new List<HorarioTrabalho>();

            for (int i=0;i<5;i++)
            {
                var horario = new HorarioTrabalho();
                horario.DiaSemana = i;
                candidato.Horarios.Add(horario);
            }
            
            return View(candidato);
        }

        // POST: Candidato/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("CandidatoID,Nome,CPF,Email,Telefone,Habilitacao,Categoria,Estado,Cidade,CEP,Logradouro,Numero,Complemento,CargoID,SalarioProposto, Idiomas")] Candidato candidato)
        public async Task<IActionResult> Create(IFormCollection form)
        {
            var candidato = new Candidato();



            candidato.Nome = form["Nome"];
            candidato.CPF = form["CPF"];
            candidato.Email = form["Email"];
            candidato.Telefone = form["Telefone"];
            candidato.Habilitacao = form["Habilitacao"].Count>1 ? true : false;
            candidato.Categoria = form["Categoria"];
            candidato.Estado = form["Estado"];
            candidato.Cidade = form["Cidade"];
            candidato.CEP = form["CEP"];
            candidato.Logradouro = form["Logradouro"];
            candidato.Numero = form["Numero"];
            candidato.Complemento = form["Complemento"];
            candidato.CargoID = int.Parse(form["CargoID"]);
            candidato.SalarioProposto = decimal.Parse(form["SalarioProposto"]);
            var idiomas = form["Idiomas"].ToString();

            if (ModelState.IsValid)
            {
                
                _context.Add(candidato);
                foreach (var i in idiomas.Split(',')) 
                {
                    var idioma = new CandidatoIdioma { Candidato = candidato, LinguaEstrangeiraID = int.Parse(i) };
                    _context.Add(idioma);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            ViewData["CargoID"] = new SelectList(_context.Cargo, "CargoID", "Nome", candidato.CargoID);

            var query = _context.CandidatoIdioma.Select(ci => ci.LinguaEstrangeiraID);
            ViewData["Idiomas"] = new MultiSelectList(_context.LinguaEstrangeira, "LinguaEstrangeiraID", "LinguaEstrangeira.Nome", query);

            return View(candidato);
        }

        // GET: Candidato/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidato = await _context.Candidato.FindAsync(id);
            if (candidato == null)
            {
                return NotFound();
            }
            ViewData["CargoID"] = new SelectList(_context.Cargo, "CargoID", "Nome", candidato.CargoID);
            var query = _context.CandidatoIdioma.Select(ci => ci.LinguaEstrangeiraID);
            ViewData["Idiomas"] = new MultiSelectList(_context.LinguaEstrangeira, "LinguaEstrangeiraID", "LinguaEstrangeira.Nome", query);
            return View(candidato);
        }

        // POST: Candidato/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CandidatoID,Nome,CPF,Email,Telefone,Habilitacao,Categoria,Estado,Cidade,CEP,Logradouro,Numero,Complemento,CargoID,SalarioProposto, IdiomasIds")] Candidato candidato)
        {
            if (id != candidato.CandidatoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(candidato);
                    _context.RemoveRange(_context.CandidatoIdioma.Where(c => c.CandidatoID == candidato.CandidatoID));
                    foreach (var i in candidato.IdiomasIds)
                    {
                        var idioma = new CandidatoIdioma { Candidato = candidato, LinguaEstrangeiraID = i };
                        _context.Add(idioma);
                    }

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CandidatoExists(candidato.CandidatoID))
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
            ViewData["CargoID"] = new SelectList(_context.Cargo, "CargoID", "CargoID", candidato.CargoID);
            var query = _context.CandidatoIdioma.Select(ci => ci.LinguaEstrangeiraID);
            ViewData["Idiomas"] = new MultiSelectList(_context.LinguaEstrangeira, "LinguaEstrangeiraID", "LinguaEstrangeira.Nome", query);
            return View(candidato);
        }

        // GET: Candidato/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidato = await _context.Candidato
                .Include(c => c.Cargo)
                .FirstOrDefaultAsync(m => m.CandidatoID == id);
            if (candidato == null)
            {
                return NotFound();
            }

            return View(candidato);
        }

        // POST: Candidato/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var candidato = await _context.Candidato.FindAsync(id);
            _context.RemoveRange(_context.CandidatoIdioma.Where(c => c.CandidatoID == candidato.CandidatoID));
            _context.Candidato.Remove(candidato);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CandidatoExists(int id)
        {
            return _context.Candidato.Any(e => e.CandidatoID == id);
        }
    }
}
