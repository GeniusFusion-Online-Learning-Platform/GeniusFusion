using ClientApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
using System.Text;

namespace ClientApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
 
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Faculty()
        {
            return View();
        }

        public IActionResult AdminDashboard()
        {
            return View();
        }

        public IActionResult CreateStudent()
        {
            return View();
        }

        public IActionResult ShowAllStudents()
        {
            return View();
        }

        public IActionResult ShowStudentById()
        {
            return View();
        }


        public IActionResult DeleteStudent()
        {
            return View();
        }

        public IActionResult StudentDashBoard()
        {
            return View();
        }

        public IActionResult AddFaculty()
        {
            return View();
        }

        public IActionResult ShowFacultyById()
        {
            return View();
        }

        public IActionResult ShowAllFaculties()
        {
            return View();
        }

        public IActionResult DeleteFaculty()
        {
            return View();
        }

        public IActionResult FacultyDashboard()
        {
            return View();

        }

        public IActionResult StudentsInCourse()
        {
            return View();
        }

        public IActionResult CourseInfo()
        {
            return View();
        }


        public IActionResult ShowAllCourses()
        {
            return View();
        }

        public IActionResult DeleteCourse()
        {
            return View();
        }



    }
}
