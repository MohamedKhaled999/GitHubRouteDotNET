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
        ILogger<EmployeeController> _logger;

        
        public EmployeeController(IWebHostEnvironment environment, IEmployeeServices employeeService, ILogger<EmployeeController> logger)
        {
            _environment = environment;
            _employeeService = employeeService;
            _logger = logger;
        }

        // GET: EmployeeController
        public ActionResult Index()
        {
            var employees = _employeeService.GetEmployees();
            return View(employees);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            var employee = _employeeService.GetEmployeeById(id);

            if(employee != null)
             return View(employee);

            return BadRequest();


        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [IgnoreAntiforgeryToken]

        public ActionResult Create(CreatedEmployeeDTO createdEmployee)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(createdEmployee);   
                
                
                var result = _employeeService .CreateEmployee(createdEmployee);

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
            return View(createdEmployee);

        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int? id)
        {
            if(id is null)
               return BadRequest();

            var employee =_employeeService.GetEmployeeById(id.Value);

            if (employee is null)
                return NotFound();

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

        public ActionResult Edit(UpdatedEmployeeDTO employee)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(employee);


                var result = _employeeService.UpdateEmployee(employee);

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
        public ActionResult Delete(int? id)
        {
            if (id is null)
                return BadRequest();

            try
            {

                var isDeleted = _employeeService.DeleteEmployee(id.Value);

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
