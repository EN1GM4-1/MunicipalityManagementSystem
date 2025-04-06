using Microsoft.AspNetCore.Mvc;
using MunicipalityManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace MunicipalityManagementSystem.Controllers
{
    public class StaffController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StaffController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Route("~/Staff")]
    public IActionResult Index()
    {
        return View();
    }

        // GET: Staff/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Staff/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StaffID,FullName,Position,Email,PhoneNumber,DateHired")] Staff staff)
        {
            if (ModelState.IsValid)
            {
                _context.Add(staff);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(staff);
        }

        // GET: Staff/Edit/5
        [Route("~/Staff/Edit")]
        public IActionResult Edit()
        {
            return View();
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _context.Staff.FindAsync(id);
            if (staff == null)
            {
                return NotFound();
            }
            return View();
        }

        // POST: Staff/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StaffID,FullName,Position,Email,PhoneNumber,DateHired")] Staff staff)
        {
            if (id != staff.StaffID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staff);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffExists(staff.StaffID))
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
            return View();
        }

        // GET: Staff/Delete/5
        [Route("~/Staff/Delete")]
        public IActionResult Delete()
        {
            return View();
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _context.Staff
                .FirstOrDefaultAsync(m => m.StaffID == id);
            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }

        // POST: Staff/Delete/5
// POST: Staff/Delete/5
[HttpPost, ActionName("Delete")]
[ValidateAntiForgeryToken]
[Route("~/Staff/Delete")]
public async Task<IActionResult> DeleteConfirmed(int id)
{
    if (!StaffExists(id))
    {
        return NotFound();
    }
   var staff = await _context.Staff.FindAsync(id);
    if (staff != null)
    {
        _ = _context.Staff.Remove(staff);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    else
    {
        // Handle the case where staff is null
        return View();
    }
}

        private bool StaffExists(int id)
{
    return _context.Staff.Any(e => e.StaffID == id);
}
    }
}
