using Microsoft.AspNetCore.Mvc;

namespace MunicipalityManagementSystem.Controllers
{
    public class ReportController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReportController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Report
        [Route("~/Report")]
        public IActionResult Index()
        {
            return View();
        }

         public IActionResult Create()
        {
            return View();
        }

        [Route("~/Report/Delete")]
         public IActionResult Delete()
        {
            return View();
        }

        

        [Route("~/Report/Edit")]
         public IActionResult Edit()
        {
            return View();
        }

        
    }
}
