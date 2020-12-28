using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Contacts.Data;
using Contacts.Models;

namespace Contacts.Controllers
{
    public class ProfessionalEstablishmentsController : Controller
    {
        private readonly ContactsContext _context;

        public ProfessionalEstablishmentsController(ContactsContext context)
        {
            _context = context;
        }

        // GET: ProfessionalEstablishments
        public async Task<IActionResult> Index()
        {
            var contactsContext = _context.ProfessionalEstablishments.Include(p => p.Establishment).Include(p => p.Professional);
            return View(await contactsContext.ToListAsync());
        }

        // GET: ProfessionalEstablishments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professionalEstablishment = await _context.ProfessionalEstablishments
                .Include(p => p.Establishment)
                .Include(p => p.Professional)
                .FirstOrDefaultAsync(m => m.ProfissionalEstablishmenId == id);
            if (professionalEstablishment == null)
            {
                return NotFound();
            }

            return View(professionalEstablishment);
        }

        // GET: ProfessionalEstablishments/Create
        public IActionResult Create()
        {
            ViewData["EstablishmentId"] = new SelectList(_context.Establishments, "Id", "Name");
            ViewData["ProfessionalId"] = new SelectList(_context.Professionals, "Id", "Name");
            return View();
        }

        // POST: ProfessionalEstablishments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProfissionalEstablishmenId,ProfessionalId,EstablishmentId")] ProfessionalEstablishment professionalEstablishment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(professionalEstablishment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EstablishmentId"] = new SelectList(_context.Establishments, "Id", "Name", professionalEstablishment.EstablishmentId);
            ViewData["ProfessionalId"] = new SelectList(_context.Professionals, "Id", "Name", professionalEstablishment.ProfessionalId);
            return View(professionalEstablishment);
        }

        // GET: ProfessionalEstablishments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professionalEstablishment = await _context.ProfessionalEstablishments.FindAsync(id);
            if (professionalEstablishment == null)
            {
                return NotFound();
            }
            ViewData["EstablishmentId"] = new SelectList(_context.Establishments, "Id", "Name", professionalEstablishment.EstablishmentId);
            ViewData["ProfessionalId"] = new SelectList(_context.Professionals, "Id", "Name", professionalEstablishment.ProfessionalId);
            return View(professionalEstablishment);
        }

        // POST: ProfessionalEstablishments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProfissionalEstablishmenId,ProfessionalId,EstablishmentId")] ProfessionalEstablishment professionalEstablishment)
        {
            if (id != professionalEstablishment.ProfissionalEstablishmenId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(professionalEstablishment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfessionalEstablishmentExists(professionalEstablishment.ProfissionalEstablishmenId))
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
            ViewData["EstablishmentId"] = new SelectList(_context.Establishments, "Id", "Name", professionalEstablishment.EstablishmentId);
            ViewData["ProfessionalId"] = new SelectList(_context.Professionals, "Id", "Name", professionalEstablishment.ProfessionalId);
            return View(professionalEstablishment);
        }

        // GET: ProfessionalEstablishments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professionalEstablishment = await _context.ProfessionalEstablishments
                .Include(p => p.Establishment)
                .Include(p => p.Professional)
                .FirstOrDefaultAsync(m => m.ProfissionalEstablishmenId == id);
            if (professionalEstablishment == null)
            {
                return NotFound();
            }

            return View(professionalEstablishment);
        }

        // POST: ProfessionalEstablishments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var professionalEstablishment = await _context.ProfessionalEstablishments.FindAsync(id);
            _context.ProfessionalEstablishments.Remove(professionalEstablishment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfessionalEstablishmentExists(int id)
        {
            return _context.ProfessionalEstablishments.Any(e => e.ProfissionalEstablishmenId == id);
        }
    }
}
