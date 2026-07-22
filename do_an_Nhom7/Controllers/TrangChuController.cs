using do_an_Nhom7.Controllers;
using do_an_Nhom7.Data;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace do_an_Nhom7.Controllers
{
    public class TrangChuController : CoSoController
    {
        private readonly ILogger<TrangChuController> _logger;

        public TrangChuController(EnglishCenterDbContext db, ILogger<TrangChuController> logger) : base(db)
        {
            _logger = logger;
        }

        public IActionResult TrangChu()
        {
            return View(BuildDashboardModel(featuredCourseCount: 3));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Loi()
        {
            return View(model: Activity.Current?.Id ?? HttpContext.TraceIdentifier);
        }
    }
}


