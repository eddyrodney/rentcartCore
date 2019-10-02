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
    public class InspeccionesController : Controller
    {
        private readonly RentCarDbContext _context;

        public InspeccionesController(RentCarDbContext context)
        {
            _context = context;
        }

        // GET: Inspecciones
        public async Task<IActionResult> Index()
        {
            return View(await _context.Inspecciones.ToListAsync());
        }

        // GET: Inspecciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inspeccion = await _context.Inspecciones
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inspeccion == null)
            {
                return NotFound();
            }

            return View(inspeccion);
        }

        // GET: Inspecciones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Inspecciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ralladuras,CantidadCombustible,GomaRepuesta,Gato,RoturaCristal,GomaSupDerecha,GomaSupIzquierda,GomaTraseraDerecha,GomaTraseraIzquierda,Fecha,Estado,IdRenta")] Inspeccion inspeccion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inspeccion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inspeccion);
        }

        // GET: Inspecciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inspeccion = await _context.Inspecciones.FindAsync(id);
            if (inspeccion == null)
            {
                return NotFound();
            }
            return View(inspeccion);
        }

        // POST: Inspecciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ralladuras,CantidadCombustible,GomaRepuesta,Gato,RoturaCristal,GomaSupDerecha,GomaSupIzquierda,GomaTraseraDerecha,GomaTraseraIzquierda,Fecha,Estado,IdRenta")] Inspeccion inspeccion)
        {
            if (id != inspeccion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inspeccion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InspeccionExists(inspeccion.Id))
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
            return View(inspeccion);
        }

        // GET: Inspecciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inspeccion = await _context.Inspecciones
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inspeccion == null)
            {
                return NotFound();
            }

            return View(inspeccion);
        }

        // POST: Inspecciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inspeccion = await _context.Inspecciones.FindAsync(id);
            _context.Inspecciones.Remove(inspeccion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InspeccionExists(int id)
        {
            return _context.Inspecciones.Any(e => e.Id == id);
        }
    }
}
