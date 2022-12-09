using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication.Services.Interfaces;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICatalogService _catalogService;

        public HomeController(ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }

        public async Task<IActionResult> Index()
        {
            var courses = await _catalogService.GetAllCourseAsync();
            return View(courses);
        }

        public async Task<IActionResult> Detail(string id)
        {
            var course = await _catalogService.GetByCourseId(id);
            return View(course);
        }
    }
}