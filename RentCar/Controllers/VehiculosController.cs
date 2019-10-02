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
    public class VehiculosController : Controller
    {
        private readonly RentCarDbContext _context;

        public VehiculosController(RentCarDbContext context)
        {
            _context = context;
        }

        // GET: Vehiculos
        public async Task<IActionResult> Index()
        {
            var rentCarDbContext = _context.Vehiculos.Include(v => v.Marca).Include(v => v.TipoCombustible).Include(v => v.TipoVehiculo);
            return View(await rentCarDbContext.ToListAsync());
        }

        // GET: Vehiculos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiculo = await _context.Vehiculos
                .Include(v => v.Marca)
                .Include(v => v.TipoCombustible)
                .Include(v => v.TipoVehiculo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            return View(vehiculo);
        }

        // GET: Vehiculos/Create
        public IActionResult Create()
        {
            ViewData["MarcaId"] = new SelectList(_context.Marcas, "Id", "Id");
            ViewData["TipoCombustibleId"] = new SelectList(_context.TiposCombustibles, "Id", "Id");
            ViewData["TipoVehiculoId"] = new SelectList(_context.TiposVehiculos, "Id", "Id");
            return View();
        }

        // POST: Vehiculos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion,Estado,NoChasis,NoMotor,NoPlaca,TipoVehiculoId,TipoCombustibleId,MarcaId")] Vehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MarcaId"] = new SelectList(_context.Marcas, "Id", "Id", vehiculo.MarcaId);
            ViewData["TipoCombustibleId"] = new SelectList(_context.TiposCombustibles, "Id", "Id", vehiculo.TipoCombustibleId);
            ViewData["TipoVehiculoId"] = new SelectList(_context.TiposVehiculos, "Id", "Id", vehiculo.TipoVehiculoId);
            return View(vehiculo);
        }

        // GET: Vehiculos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiculo = await _context.Vehiculos.FindAsync(id);
            if (vehiculo == null)
            {
                return NotFound();
            }
            ViewData["MarcaId"] = new SelectList(_context.Marcas, "Id", "Id", vehiculo.MarcaId);
            ViewData["TipoCombustibleId"] = new SelectList(_context.TiposCombustibles, "Id", "Id", vehiculo.TipoCombustibleId);
            ViewData["TipoVehiculoId"] = new SelectList(_context.TiposVehiculos, "Id", "Id", vehiculo.TipoVehiculoId);
            return View(vehiculo);
        }

        // POST: Vehiculos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion,Estado,NoChasis,NoMotor,NoPlaca,TipoVehiculoId,TipoCombustibleId,MarcaId")] Vehiculo vehiculo)
        {
            if (id != vehiculo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehiculo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehiculoExists(vehiculo.Id))
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
            ViewData["MarcaId"] = new SelectList(_context.Marcas, "Id", "Id", vehiculo.MarcaId);
            ViewData["TipoCombustibleId"] = new SelectList(_context.TiposCombustibles, "Id", "Id", vehiculo.TipoCombustibleId);
            ViewData["TipoVehiculoId"] = new SelectList(_context.TiposVehiculos, "Id", "Id", vehiculo.TipoVehiculoId);
            return View(vehiculo);
        }

        // GET: Vehiculos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiculo = await _context.Vehiculos
                .Include(v => v.Marca)
                .Include(v => v.TipoCombustible)
                .Include(v => v.TipoVehiculo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            return View(vehiculo);
        }

        // POST: Vehiculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehiculo = await _context.Vehiculos.FindAsync(id);
            _context.Vehiculos.Remove(vehiculo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehiculoExists(int id)
        {
            return _context.Vehiculos.Any(e => e.Id == id);
        }
    }
}
