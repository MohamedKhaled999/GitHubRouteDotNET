using IKEA.BLL.Models.Departments;
using IKEA.BLL.Services;
using IKEA.DAL.Models.Departments;
using IKEA.Models;
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

        #region Create
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
            string message = "Sorry An Error Occurred During Creating The Department :(";
            try
            {
                var result = _departmentService.CreateDepartment(createdDepartment);
                if (result > 0)
                {
                  return  RedirectToAction(nameof(Index));
                }
                

            }
            catch (Exception ex)
            {

                _logger.LogError(ex, ex.Message);
                message = _webHostEnvironment.IsDevelopment() ? ex.Message : message;


            }
            ModelState.AddModelError (string.Empty, message);
            return View(createdDepartment);
        }
        #endregion

        #region Details
        [HttpGet]
        public IActionResult Details(int? id )
        {
            if (id is null)
                return BadRequest();
            
            DepartmentDetailsToReturnDTO? department =null;
           
            if (id.HasValue)
                department   = _departmentService.GetDepartmentById(id.Value);
                
            if (department is null)
                return NotFound();
            return View(department);

        }
        #endregion

        #region Edit
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (! id.HasValue)
                return BadRequest();//400
            var department=  _departmentService.GetDepartmentById(id.Value);

            if (department is null)
                return NotFound();//404

            var departmentEdit = new DepartmentEditViewModel
            {
                Code = department.Code,
                CreationDate = department.CreationDate,
                Description = department.Description,
                Name = department.Name,
            };

            return View(departmentEdit);
        }

        [HttpPost]
        public IActionResult Edit([FromRoute]int x,
            [FromForm] DepartmentEditViewModel department)
        {
            if (!ModelState.IsValid)
                return View(department);
            var message = "Sorry An Error Occurred During Updating The Department :(";
            try
            {
                var departmentToUpdate = new UpdatedDepartmentDTO()
                {
                    Id = x,
                    Code = department.Code,
                    CreationDate = department.CreationDate,
                    Description = department.Description,
                    Name = department.Name,
                };

                int result = _departmentService.
                UpdatedDepartment(departmentToUpdate);
                
                if (result > 0)
                 return   RedirectToAction(nameof(Index));



            }
            catch (Exception ex)
            {

                _logger.LogError(ex, ex.Message);
                message =_webHostEnvironment.IsDevelopment() ? 
                    ex.Message : message;

            }
            ModelState.AddModelError(string.Empty, message);
            return View(department);


        }


        #endregion

    }
}
