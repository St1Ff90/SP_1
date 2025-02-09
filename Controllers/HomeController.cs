using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SP.Data;
using SP.Models;
using System.Diagnostics;

namespace SP.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
           var user = await _userManager.GetUserAsync(User);

          await _userManager.AddToRoleAsync(user, "Admin");


            

            var roles = user != null ? await _userManager.GetRolesAsync(user) : null;


            //var listOfLevels = new List<Level>() { Level.A2, Level.B1 };

            //var students = _context.Students.Where(x => listOfLevels.Contains(x.Level));

            //var realStudents = students.FirstOrDefault();

            return View();
        }

        public async Task<IActionResult> Login()
        {
            var user = await _userManager.GetUserAsync(User);

            var roles = user != null ? await _userManager.GetRolesAsync(user) : null;


            var listOfLevels = new List<Level>() { Level.A2, Level.B1 };

            var students = _context.Students.Where(x => listOfLevels.Contains(x.Level));
            
            var realStudents = students.FirstOrDefault();

            return View("~/Views/Home/Index.cshtml");
        }

        [Authorize(Roles ="Student")]
        public IActionResult Privacy()
        {
            var user =  _userManager.GetUserAsync(User).Result!;

            if(user.Type != UserType.Admin)
            {
                return Forbid();
            }

            return View();
        }

        [HttpGet]
        public IActionResult SaveUser(string role)
        {
            if (role == "Manager")
                return RedirectToAction("Manager");
            else if (role.ToLower() == "Student".ToLower())
                return RedirectToAction("Student");
            else if (role == "Lehrer")
                return RedirectToAction("Lehrer");
            else { return View("Index"); }
        }

        [HttpPost]
        public IActionResult SaveUser()
        {
            return RedirectToAction("Index");
            //TempData["Message"] = $": {role}";
            //if (role == "Manager")
            //    return RedirectToAction("Manager");
            //else if (role.ToLower() == "Student".ToLower())
            //    return RedirectToAction("Student");
            //else if (role == "Lehrer")
            //    return RedirectToAction("Lehrer");
            //else { return View("Index"); }
        }

        //[Authorize(Roles = "Student")]
        public IActionResult Lehrer()
        {
            var user = _userManager.GetUserAsync(User).Result!;

            //if (user.Type != UserType.Admin)
            //{
            //    return Forbid();
            //}

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
