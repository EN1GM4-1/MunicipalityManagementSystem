using Microsoft.AspNetCore.Mvc;
using MunicipalityManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace MunicipalityManagementSystem.Controllers
{
    public class ServiceRequestController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServiceRequestController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ServiceRequest
        
        [Route("~/ServiceRequest")]
        public IActionResult Index()
        {
            return View();
        }

        // GET: ServiceRequest/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ServiceRequest/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RequestID,ServiceType,DateRequested,Status,CitizenID")] ServiceRequest serviceRequest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(serviceRequest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(serviceRequest);
        }

        // GET: ServiceRequest/Edit/5
        [Route("~/ServiceRequest/Edit")]
        public IActionResult Edit()
        {
            return View();
        }
        

        // GET: ServiceRequest/Delete/5
        [Route("~/ServiceRequest/Delete")]
        public IActionResult Delete()
        {
            return View();
        }
        

        // POST: ServiceRequest/Delete/5
        [HttpPost, ActionName("Delete")]
[ValidateAntiForgeryToken]
public async Task<IActionResult> DeleteConfirmed(int id)
{
    var serviceRequest = await _context.ServiceRequests.FindAsync(id);
    if (serviceRequest != null)
    {
        _context.ServiceRequests.Remove(serviceRequest);
        await _context.SaveChangesAsync();
    }
    return RedirectToAction(nameof(Index));
}
    }
}
