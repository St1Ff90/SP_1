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
    public class ThemenController : Controller
    {
        private readonly ApplicationDbContext _context;
        private static List<SelectListItem>? _bereichList;
             

        public ThemenController(ApplicationDbContext context)
        {
            _context = context;
            _bereichList = Enum.GetValues(typeof(Bereich)).Cast<Bereich>().Select(x => new SelectListItem { Value = x.ToString(), Text = x.ToString() }).ToList();
        }

        // GET: Themen
        public async Task<IActionResult> Index()
        {
            return View(await _context.Themens.ToListAsync());
        }

        // GET: Themen/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var themen = await _context.Themens
                .FirstOrDefaultAsync(m => m.Id == id);
            if (themen == null)
            {
                return NotFound();
            }

            return View(themen);
        }

        // GET: Themen/Create
        public IActionResult Create()
        {
            ViewBag.Bereichs = _bereichList;
            return View();
        }

        // POST: Themen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Bereich,ThemaName")] Thema themen)
        {
            if (ModelState.IsValid)
            {
               _context.Add(themen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(themen);
        }

        // GET: Themen/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var themen = await _context.Themens.FindAsync(id);
            if (themen == null)
            {
                return NotFound();
            }
            ViewBag.Bereichs = _bereichList;

            return View(themen);
        }

     

        // POST: Themen/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Bereich,ThemaName")] Thema themen)
        {
            if (id != themen.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(themen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThemenExists(themen.Id))
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
            return View(themen);
        }

        // GET: Themen/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var themen = await _context.Themens
                .FirstOrDefaultAsync(m => m.Id == id);
            if (themen == null)
            {
                return NotFound();
            }

            return View(themen);
        }

        // POST: Themen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var themen = await _context.Themens.FindAsync(id);
            if (themen != null)
            {
                _context.Themens.Remove(themen);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThemenExists(Guid id)
        {
            return _context.Themens.Any(e => e.Id == id);
        }
    }
}
