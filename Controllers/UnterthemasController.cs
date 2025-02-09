using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SP.Data;
using SP.Models.Unterrichten;

namespace SP.Controllers
{
    public class UnterthemasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UnterthemasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Unterthemas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Unterthemas.Include(u => u.Themen);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Unterthemas/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unterthema = await _context.Unterthemas
                .Include(u => u.Themen)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (unterthema == null)
            {
                return NotFound();
            }

            return View(unterthema);
        }

        // GET: Unterthemas/Create
        public IActionResult Create()
        {
            ViewData["ThemaName"] = new SelectList(_context.Themens, "ThemaName", "ThemaName");
            ViewData["Id"] = new SelectList(_context.Themens, "Id", "Id");
            return View();
        }

        // POST: Unterthemas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ThemenId,NameUntertheme,Foto,Beschreibung,Beispiele")] Unterthema unterthema)
        {
            if (ModelState.IsValid)
            {
                unterthema.Id = Guid.NewGuid();
                _context.Add(unterthema);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ThemaName"] = new SelectList(_context.Themens, "ThemaName", "ThemaName", unterthema.Themen.ThemaName);
            return View(unterthema);
        }

        // GET: Unterthemas/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unterthema = await _context.Unterthemas.FindAsync(id);
            if (unterthema == null)
            {
                return NotFound();
            }
            ViewData["ThemaName"] = new SelectList(_context.Themens, "Id", "ThemaName", unterthema.NameUntertheme);
            return View(unterthema);
        }

        // POST: Unterthemas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,ThemenId,NameUntertheme,Foto,Beschreibung,Beispiele")] Unterthema unterthema)
        {
            if (id != unterthema.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unterthema);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnterthemaExists(unterthema.Id))
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
            ViewData["ThemenId"] = new SelectList(_context.Themens, "Id", "Id", unterthema.ThemenId);
            return View(unterthema);
        }

        // GET: Unterthemas/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unterthema = await _context.Unterthemas
                .Include(u => u.Themen)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (unterthema == null)
            {
                return NotFound();
            }

            return View(unterthema);
        }

        // POST: Unterthemas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var unterthema = await _context.Unterthemas.FindAsync(id);
            if (unterthema != null)
            {
                _context.Unterthemas.Remove(unterthema);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnterthemaExists(Guid id)
        {
            return _context.Unterthemas.Any(e => e.Id == id);
        }
    }
}
