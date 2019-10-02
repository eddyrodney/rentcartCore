using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentCar.DAL;
using RentCar.Models;

namespace RentCar.Controllers
{
    public class TipoCombustiblesController : Controller
    {
        private readonly RentCarDbContext _context;

        public TipoCombustiblesController(RentCarDbContext context)
        {
            _context = context;
        }

        // GET: TipoCombustibles
        public async Task<IActionResult> Index()
        {
            return View(await _context.TiposCombustibles.ToListAsync());
        }

        // GET: TipoCombustibles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoCombustible = await _context.TiposCombustibles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoCombustible == null)
            {
                return NotFound();
            }

            return View(tipoCombustible);
        }

        // GET: TipoCombustibles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoCombustibles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion,Estado")] TipoCombustible tipoCombustible)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoCombustible);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoCombustible);
        }

        // GET: TipoCombustibles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoCombustible = await _context.TiposCombustibles.FindAsync(id);
            if (tipoCombustible == null)
            {
                return NotFound();
            }
            return View(tipoCombustible);
        }

        // POST: TipoCombustibles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion,Estado")] TipoCombustible tipoCombustible)
        {
            if (id != tipoCombustible.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoCombustible);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoCombustibleExists(tipoCombustible.Id))
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
            return View(tipoCombustible);
        }

        // GET: TipoCombustibles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoCombustible = await _context.TiposCombustibles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoCombustible == null)
            {
                return NotFound();
            }

            return View(tipoCombustible);
        }

        // POST: TipoCombustibles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoCombustible = await _context.TiposCombustibles.FindAsync(id);
            _context.TiposCombustibles.Remove(tipoCombustible);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoCombustibleExists(int id)
        {
            return _context.TiposCombustibles.Any(e => e.Id == id);
        }
    }
}
