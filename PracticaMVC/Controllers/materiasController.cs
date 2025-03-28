using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PracticaMVC.Models;

namespace PracticaMVC.Controllers
{
    public class materiasController : Controller
    {
        private readonly notasDBContext _context;

        public materiasController(notasDBContext context)
        {
            _context = context;
        }

        // GET: materias
        public async Task<IActionResult> Index()
        {
            return View(await _context.materias.ToListAsync());
        }

        // GET: materias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materias = await _context.materias
                .FirstOrDefaultAsync(m => m.id == id);
            if (materias == null)
            {
                return NotFound();
            }

            return View(materias);
        }

        // GET: materias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: materias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,materia,unidades_valorativas,estado")] materias materias)
        {
            if (ModelState.IsValid)
            {
                _context.Add(materias);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(materias);
        }

        // GET: materias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materias = await _context.materias.FindAsync(id);
            if (materias == null)
            {
                return NotFound();
            }
            return View(materias);
        }

        // POST: materias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,materia,unidades_valorativas,estado")] materias materias)
        {
            if (id != materias.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(materias);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!materiasExists(materias.id))
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
            return View(materias);
        }

        // GET: materias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materias = await _context.materias
                .FirstOrDefaultAsync(m => m.id == id);
            if (materias == null)
            {
                return NotFound();
            }

            return View(materias);
        }

        // POST: materias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var materias = await _context.materias.FindAsync(id);
            if (materias != null)
            {
                _context.materias.Remove(materias);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool materiasExists(int id)
        {
            return _context.materias.Any(e => e.id == id);
        }
    }
}
