using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuecherDatenbank;
using Buecher;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Programmentwurf_6700970.Data;
using Programmentwurf_6700970.Models;

namespace Programmentwurf_6700970.Controllers
{
    public class BuecherModelsController : Controller
    {
        private readonly Programmentwurf_6700970Context _context;

        public BuecherModelsController(Programmentwurf_6700970Context context)
        {
            _context = context;
        }

        // GET: BuecherModels
        //public async Task<IActionResult> Index()
        //{
        //      return View(await _context.BuecherModel.ToListAsync());
        //}

        // GET: BuecherModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BuecherModel == null)
            {
                return NotFound();
            }

            var buecherModel = await _context.BuecherModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (buecherModel == null)
            {
                return NotFound();
            }

            return View(buecherModel);
        }

        // GET: BuecherModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BuecherModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Author,IsActive")] BuecherModel buecherModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(buecherModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(buecherModel);
        }

        // GET: BuecherModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BuecherModel == null)
            {
                return NotFound();
            }

            var buecherModel = await _context.BuecherModel.FindAsync(id);
            if (buecherModel == null)
            {
                return NotFound();
            }
            return View(buecherModel);
        }

        // POST: BuecherModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Author,IsActive")] BuecherModel buecherModel)
        {
            if (id != buecherModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(buecherModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuecherModelExists(buecherModel.Id))
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
            return View(buecherModel);
        }

        // GET: BuecherModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BuecherModel == null)
            {
                return NotFound();
            }

            var buecherModel = await _context.BuecherModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (buecherModel == null)
            {
                return NotFound();
            }

            return View(buecherModel);
        }

        // POST: BuecherModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BuecherModel == null)
            {
                return Problem("Entity set 'Programmentwurf_6700970Context.BuecherModel'  is null.");
            }
            var buecherModel = await _context.BuecherModel.FindAsync(id);
            if (buecherModel != null)
            {
                _context.BuecherModel.Remove(buecherModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BuecherModelExists(int id)
        {
          return _context.BuecherModel.Any(e => e.Id == id);
        }

        public IActionResult Index()
        {
            string connectionString = this.GetConnectionString();
            var repository = new BuecherRepository(connectionString);
            List<BuecherDTO>? buecher = repository.HoleBuecher();

            var model = new BuecherModel(buecher);

            return View(model);
        }

        private string GetConnectionString()
        {

        }
    }
}
