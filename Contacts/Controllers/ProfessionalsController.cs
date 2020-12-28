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
using Contacts.Models.ViewModels;

namespace Contacts.Controllers
{
    public class ProfessionalsController : Controller
    {
        private readonly ContactsContext _context;

        private readonly ProfessionalService _professionalService;

        public ProfessionalsController(ContactsContext context,
            ProfessionalService professionalService)
        {
            _context = context;
            _professionalService = professionalService;
        }


        // GET: Professionals
        //public async Task<IActionResult> Index()
        //{
        //    var list = await _professionalService.FindAllAsync();
        //    //return View(await _context.Professionals.ToListAsync());
        //    return View(list);
        //}

        public async Task<IActionResult> Index(
            string sortOrder,
            string currentFilter,
            string searchString,
            int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["RoleSortParm"] = sortOrder == "role" ? "role_desc" : "role";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var professionals = from s in _context.Professionals
                                select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                professionals = professionals.Where(s => s.Name.ToLower().Contains(searchString.ToLower()) || 
                                                    s.Role.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    professionals = professionals.OrderByDescending(s => s.Name);
                    break;
                case "role_desc":
                    professionals = professionals.OrderByDescending(s => s.Role);
                    break;
                case "role":
                    professionals = professionals.OrderBy(s => s.Role);
                    break;
                default:
                    professionals = professionals.OrderBy(s => s.Name);
                    break;
            }

            int pageSize = 8;
            return View(await PaginatedList<Professional>
                .CreateAsync(professionals.AsNoTracking()
                , pageNumber ?? 1, pageSize));
        }


        // GET: Professionals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professional = await _context.Professionals
                .FirstOrDefaultAsync(m => m.Id == id);
            if (professional == null)
            {
                return NotFound();
            }

            return View(professional);
        }

        // GET: Professionals/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Professional professional)
        {
            await _professionalService.InsertAsync(professional);
            return RedirectToAction(nameof(Index));
        }

        // GET: Professionals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professional = await _context.Professionals.FindAsync(id);
            if (professional == null)
            {
                return NotFound();
            }
            return View(professional);
        }

        // POST: Professionals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address,Cellphone,HomePhone,Role")] Professional professional)
        {
            if (id != professional.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(professional);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfessionalExists(professional.Id))
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
            return View(professional);
        }

        // GET: Professionals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professional = await _context.Professionals
                .FirstOrDefaultAsync(m => m.Id == id);
            if (professional == null)
            {
                return NotFound();
            }

            return View(professional);
        }

        // POST: Professionals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var professional = await _context.Professionals.FindAsync(id);
            _context.Professionals.Remove(professional);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfessionalExists(int id)
        {
            return _context.Professionals.Any(e => e.Id == id);
        }
    }
}
