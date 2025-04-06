using Microsoft.AspNetCore.Mvc;
using MunicipalityManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace MunicipalityManagementSystem.Controllers
{
        public class CitizenController : Controller
        {
            private readonly ApplicationDbContext _context;

            public CitizenController(ApplicationDbContext context)
            {
                _context = context;
            }

            // GET: Citizen
            [Route("~/Citizen")]
             public IActionResult Index()
            {
                return View();
            }

            // GET: Citizen/Create

            
        public IActionResult Create()
        {
            return View();
        }

        // POST: Citizen/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CitizenID,FullName,Address,PhoneNumber,Email,DateOfBirth,RegistrationDate")] Citizen citizen)
        {
            if (ModelState.IsValid)
            {
                _context.Add(citizen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(citizen);
        }

        // GET: Citizen/Edit/5
        public IActionResult Edit()
        {
            return View();
        }
        
        

        // POST: Citizen/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CitizenID,FullName,Address,PhoneNumber,Email,DateOfBirth,RegistrationDate")] Citizen citizen)
        {
            if (id != citizen.CitizenID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(citizen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CitizenExists(citizen.CitizenID))
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
            return View(citizen);
        }

        // GET: Citizen/Delete/5
        public IActionResult Delete()
        {
            return View();
        }

        // POST: Citizen/Delete/5
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
{
    var citizen = await _context.Citizens.FindAsync(id);
    if (citizen != null)
    {
        _context.Citizens.Remove(citizen);
        await _context.SaveChangesAsync();
    }
    return RedirectToAction(nameof(Index));
}

        private bool CitizenExists(int id)
        {
            return _context.Citizens.Any(e => e.CitizenID == id);
        }
    }
}
