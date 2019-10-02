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
    public class RentasController : Controller
    {
        private readonly RentCarDbContext _context;

        public RentasController(RentCarDbContext context)
        {
            _context = context;
        }

        // GET: Rentas
        public async Task<IActionResult> Index()
        {
            var rentCarDbContext = _context.Rentas.Include(r => r.Cliente).Include(r => r.Empleado).Include(r => r.Vehiculo);
            return View(await rentCarDbContext.ToListAsync());
        }

        // GET: Rentas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var renta = await _context.Rentas
                .Include(r => r.Cliente)
                .Include(r => r.Empleado)
                .Include(r => r.Vehiculo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (renta == null)
            {
                return NotFound();
            }

            return View(renta);
        }

        // GET: Rentas/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Id");
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Id");
            ViewData["VehiculoId"] = new SelectList(_context.Vehiculos, "Id", "Id");
            return View();
        }

        // POST: Rentas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NoRenta,FechaRenta,FechaDevolucion,MontoXDia,CantidadDia,Comentario,Estado,EmpleadoId,VehiculoId,ClienteId")] Renta renta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(renta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Id", renta.ClienteId);
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Id", renta.EmpleadoId);
            ViewData["VehiculoId"] = new SelectList(_context.Vehiculos, "Id", "Id", renta.VehiculoId);
            return View(renta);
        }

        // GET: Rentas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var renta = await _context.Rentas.FindAsync(id);
            if (renta == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Id", renta.ClienteId);
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Id", renta.EmpleadoId);
            ViewData["VehiculoId"] = new SelectList(_context.Vehiculos, "Id", "Id", renta.VehiculoId);
            return View(renta);
        }

        // POST: Rentas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NoRenta,FechaRenta,FechaDevolucion,MontoXDia,CantidadDia,Comentario,Estado,EmpleadoId,VehiculoId,ClienteId")] Renta renta)
        {
            if (id != renta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(renta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentaExists(renta.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Id", renta.ClienteId);
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Id", renta.EmpleadoId);
            ViewData["VehiculoId"] = new SelectList(_context.Vehiculos, "Id", "Id", renta.VehiculoId);
            return View(renta);
        }

        // GET: Rentas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var renta = await _context.Rentas
                .Include(r => r.Cliente)
                .Include(r => r.Empleado)
                .Include(r => r.Vehiculo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (renta == null)
            {
                return NotFound();
            }

            return View(renta);
        }

        // POST: Rentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var renta = await _context.Rentas.FindAsync(id);
            _context.Rentas.Remove(renta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentaExists(int id)
        {
            return _context.Rentas.Any(e => e.Id == id);
        }
    }
}
