using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Contacts.Data;
using Contacts.Models;
using Contacts.Services;

namespace Contacts.Controllers
{
    public class EstablishmentsController : Controller
    {
        private readonly ContactsContext _context;

        public EstablishmentsController(ContactsContext context)
        {
            _context = context;
        }


        // GET: Establishments
        public async Task<IActionResult> Index(
            string sortOrder,
            string currentFilter,
            string searchString,
            int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            
            ViewData["CurrentFilter"] = searchString;

            var establisments = from s in _context.Establishments
                                select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                establisments = establisments.Where(s => s.Name.Contains(searchString));
            }
            establisments = sortOrder switch
            {
                "name_desc" => establisments.OrderByDescending(s => s.Name),
                _ => establisments.OrderBy(s => s.Name),
            };
            int pageSize = 8;
            return View(await PaginatedList<Establishment>
                .CreateAsync(establisments.AsNoTracking()
                , pageNumber ?? 1, pageSize));
        }


        // GET: Establishments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var establishment = await _context.Establishments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (establishment == null)
            {
                return NotFound();
            }

            return View(establishment);
        }

        // GET: Establishments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Establishments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Address,Phone")] Establishment establishment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(establishment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(establishment);
        }

        // GET: Establishments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var establishment = await _context.Establishments.FindAsync(id);
            if (establishment == null)
            {
                return NotFound();
            }
            return View(establishment);
        }

        // POST: Establishments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address,Phone")] Establishment establishment)
        {
            if (id != establishment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(establishment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstablishmentExists(establishment.Id))
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
            return View(establishment);
        }

        // GET: Establishments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var establishment = await _context.Establishments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (establishment == null)
            {
                return NotFound();
            }

            return View(establishment);
        }

        // POST: Establishments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var establishment = await _context.Establishments.FindAsync(id);
            _context.Establishments.Remove(establishment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstablishmentExists(int id)
        {
            return _context.Establishments.Any(e => e.Id == id);
        }
    }
}
