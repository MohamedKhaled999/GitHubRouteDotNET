using IKEA.BLL.Models.Employees;
using IKEA.BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IKEA.Controllers
{
    public class EmployeeController : Controller
    {
        IWebHostEnvironment _environment;
        IEmployeeServices _employeeService;
        IDepartmentService _departmentService;
        ILogger<EmployeeController> _logger;

        
        public EmployeeController(IWebHostEnvironment environment, IDepartmentService departmentService,
            IEmployeeServices employeeService, ILogger<EmployeeController> logger)
        {
            _environment = environment;
            _employeeService = employeeService;
            _departmentService =departmentService ;
            _logger = logger;
        }

    
        public async Task<ActionResult> Index(string search)
        {
            var employees = await _employeeService.GetEmployeesAsync(search);
            return View(employees);
        }

        // GET: EmployeeController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);

            if(employee != null)
             return View(employee);

            return BadRequest();


        }

        // GET: EmployeeController/Create
        public async Task<ActionResult> Create()
        {
            var departments=await _departmentService.GetAllDepartmentsAsync();
            ViewBag.Departments = departments;
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [IgnoreAntiforgeryToken]

        public async Task<ActionResult> Create(CreatedEmployeeDTO createdEmployee)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(createdEmployee);   
                
                
                var result = await _employeeService .CreateEmployeeAsync(createdEmployee);

                if (result>0)
                    return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError("Create Error", "Employee has not created !!");
                    return View(createdEmployee);
                }
                


            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                if (_environment.IsDevelopment())
                    ModelState.AddModelError("", ex.Message);
                else
                    ModelState.AddModelError("", "Error While Creating An Employee!!");
            }

            var departments = await _departmentService.GetAllDepartmentsAsync();
            ViewBag.Departments = departments;
            return View(createdEmployee);

        }

        // GET: EmployeeController/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if(id is null)
               return BadRequest();

            var employee =await _employeeService.GetEmployeeByIdAsync(id.Value);

            if (employee is null)
                return NotFound();

            ViewBag.Departments =await _departmentService.GetAllDepartmentsAsync();

            return View(

                        new UpdatedEmployeeDTO
                        {
                            Address = employee.Address,
                            Age = employee.Age,
                            Email = employee.Email,
                            EmployeeType = employee.EmployeeType,
                            Gender = employee.Gender,   
                            HiringDate = employee.HiringDate,   
                            Id = employee.Id,
                            IsActive = employee.IsActive,
                            Name = employee.Name,
                            PhoneNumber = employee.PhoneNumber, 
                            Salary = employee.Salary   
                            
                        }
                );
        }

        // POST: EmployeeController/Edit/5
        
        [HttpPost]
        [IgnoreAntiforgeryToken]

        public async Task<ActionResult> Edit(UpdatedEmployeeDTO employee)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(employee);


                var result = await _employeeService.UpdateEmployeeAsync(employee);

                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError("Update Error", "Employee has not updated !!");
                    return View(employee);
                }



            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                if (_environment.IsDevelopment())
                    ModelState.AddModelError("", ex.Message);
                else
                    ModelState.AddModelError("", "Error While Updating An Employee!!");

            }
            return View(employee);


        }

        // GET: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id is null)
                return BadRequest();

            try
            {

                var isDeleted =await _employeeService.DeleteEmployeeAsync(id.Value);

                if (!isDeleted)
                    return BadRequest();

            }
            catch (Exception ex)
            {

                _logger.LogError(ex, ex.Message);
                if (_environment.IsDevelopment())
                    ModelState.AddModelError("", ex.Message);
                else
                    ModelState.AddModelError("", "Error While Deleting An Employee!!");

            }

             return RedirectToAction(nameof(Index));
        }
    }
}
