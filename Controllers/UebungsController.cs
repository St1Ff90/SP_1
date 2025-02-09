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
    public class UebungsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UebungsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Uebungs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Uebungens.Include(u => u.Unterthema);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Uebungs/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uebung = await _context.Uebungens
                .Include(u => u.Unterthema)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (uebung == null)
            {
                return NotFound();
            }

            return View(uebung);
        }

        // GET: Uebungs/Create
        public IActionResult Create()
        {
            //ViewBag.Bereichs = Enum.GetValues(typeof(Bereich)).Cast<Bereich>().Select(x => new SelectListItem { Value = x.ToString(), Text = x.ToString() }).ToList();

            var Unterthemas = _context.Unterthemas.ToList();

            var list = new SelectList(_context.Unterthemas, "Id", "NameUntertheme");
            ViewData["Unterthema"] = new SelectList(_context.Unterthemas, "Id", "NameUntertheme");

            return View();
        }

        // POST: Uebungs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UnterthemaId,Aufgabe,Frame,Text,Antworten")] Uebung uebung)
        {
            if (ModelState.IsValid)
            {
                uebung.Id = Guid.NewGuid();
                _context.Add(uebung);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UnterthemaId"] = new SelectList(_context.Unterthemas, "Id", "Id", uebung.UnterthemaId);
            return View(uebung);
        }

        // GET: Uebungs/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uebung = await _context.Uebungens.FindAsync(id);
            if (uebung == null)
            {
                return NotFound();
            }
            ViewData["UnterthemaId"] = new SelectList(_context.Unterthemas, "Id", "Id", uebung.UnterthemaId);
            return View(uebung);
        }

        // POST: Uebungs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,UnterthemaId,Aufgabe,Frame,Text,Antworten")] Uebung uebung)
        {
            if (id != uebung.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(uebung);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UebungExists(uebung.Id))
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
            ViewData["UnterthemaId"] = new SelectList(_context.Unterthemas, "Id", "Id", uebung.UnterthemaId);
            return View(uebung);
        }

        // GET: Uebungs/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uebung = await _context.Uebungens
                .Include(u => u.Unterthema)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (uebung == null)
            {
                return NotFound();
            }

            return View(uebung);
        }

        // POST: Uebungs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var uebung = await _context.Uebungens.FindAsync(id);
            if (uebung != null)
            {
                _context.Uebungens.Remove(uebung);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UebungExists(Guid id)
        {
            return _context.Uebungens.Any(e => e.Id == id);
        }
    }
}
