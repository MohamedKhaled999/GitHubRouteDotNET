using IKEA.BLL.Models.Departments;
using IKEA.BLL.Services;
using IKEA.DAL.Models.Departments;
using Microsoft.AspNetCore.Mvc;

namespace IKEA.Controllers
{
    public class DepartmentController : Controller
    {
        IDepartmentService _departmentService;
        ILogger<CreatedDepartmentDTO> _logger;
        IWebHostEnvironment _webHostEnvironment;
        public DepartmentController(IDepartmentService departmentService 
            ,ILogger<CreatedDepartmentDTO> logger
            ,IWebHostEnvironment hostEnvironment) 
        {
            _departmentService = departmentService;
            _logger = logger;
            _webHostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
           var departments = _departmentService.GetAllDepartments();
            return View(departments);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(CreatedDepartmentDTO createdDepartment)
        {
            if (!ModelState.IsValid) // Sever Side Validation
                return View(createdDepartment);
            string message;
            try
            {
                var result = _departmentService.CreateDepartment(createdDepartment);
                if (result > 0)
                {
                  return  RedirectToAction(nameof(Index));
                }
                else
                {
                    message = "Department Is Not Created";
                    ModelState.AddModelError(string.Empty, message);
                    return View(createdDepartment);
                }


            }
            catch (Exception ex)
            {

                _logger.LogError(ex, ex.Message);

                if (_webHostEnvironment.IsDevelopment())
                {
                    message = ex.Message;
                    return View(createdDepartment);
                }
                else
                {
                    message = "Department is not Created";
                    return View("Error",message);
                }
            }

            return View(createdDepartment);
        }
    }
}
