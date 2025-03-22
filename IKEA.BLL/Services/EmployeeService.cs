using IKEA.BLL.Models.Employees;
using IKEA.DAL.Models.Employees;
using IKEA.DAL.Persistence.Repositories.Departments;
using IKEA.DAL.Persistence.Repositories.Employees;
using IKEA.DAL.Persistence.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.Services
{
    public class EmployeeService : IEmployeeServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork )
        {
            _unitOfWork = unitOfWork;
        }
        public int CreateEmployee(CreatedEmployeeDTO createdEmployeeDTO)
        {
            Employee employee = new Employee
            {
                Name = createdEmployeeDTO.Name,
                Gender = createdEmployeeDTO.Gender,
                Email = createdEmployeeDTO.Email,
                EmployeeType = createdEmployeeDTO.EmployeeType,
                HiringDate = createdEmployeeDTO.HiringDate,
                PhoneNumber = createdEmployeeDTO.PhoneNumber,
                Salary = createdEmployeeDTO.Salary,
                Address = createdEmployeeDTO.Address,
                Age = createdEmployeeDTO.Age,
                IsActive = createdEmployeeDTO.IsActive,
                DepartmentId= createdEmployeeDTO.DepartmentId,
                CreatedBy=1,
                CreatedOn=DateTime.UtcNow,
                LastModificationBy=1,
                LastModificationOn=DateTime.UtcNow,
            };
             _unitOfWork.EmployeeRepository.Add(employee);
            return _unitOfWork.Complete();
        }
        public bool DeleteEmployee(int id)
        {
            Employee employee = _unitOfWork.EmployeeRepository.GetById(id);
            if (employee != null)
            {
              
                 _unitOfWork.EmployeeRepository.Delete(employee);
                return _unitOfWork.Complete()>0;

            }
            return false;
        }
        public EmployeeDetailsDTO? GetEmployeeById(int id)
        {
            Employee employee = _unitOfWork.EmployeeRepository.GetById(id);


            return new()
            {
                Id = employee.Id,
                Address = employee.Address,
                Name = employee.Name,
                Gender = employee.Gender,
                Email = employee.Email,
                EmployeeType = employee.EmployeeType,
                Age = employee.Age,
                IsActive = employee.IsActive,
                CreatedBy = employee.CreatedBy,
                PhoneNumber = employee.PhoneNumber,
                Salary = employee.Salary,
                CreatedOn = employee.CreatedOn,
                HiringDate = employee.HiringDate,
                IsDeleted = employee.IsDeleted,
                LastModificationBy = employee.LastModificationBy,
                LastModificationOn = employee.LastModificationOn,
                Department =employee.Department.Name
                
                
            };

        }
        public IEnumerable<EmployeeToReturnDTO> GetEmployees(string? search)
        {
            var employees = _unitOfWork.EmployeeRepository.GetAll().Where(x => x.Name.ToLower().Contains(search?.ToLower()??"")).
                Select(
                    
                    employee => new EmployeeToReturnDTO()
                        {
                            Address = employee.Address,
                            Id = employee.Id,
                            Name = employee.Name,
                            Gender = employee.Gender,
                            Email = employee.Email,
                            EmployeeType = employee.EmployeeType,
                            Age = employee.Age,
                            IsActive = employee.IsActive,
                            PhoneNumber = employee.PhoneNumber,
                            Salary = employee.Salary,
                            HiringDate = employee.HiringDate,
                            Department = employee.Department?.Name,
                            
                        
                    }
               ).ToList();


            return employees;

        }
        public int UpdateEmployee(UpdatedEmployeeDTO updatedEmployeeDTO)
        {
            
            Employee employee = new Employee 
            {
                Id = updatedEmployeeDTO.Id,
                Name = updatedEmployeeDTO.Name,
                Gender = updatedEmployeeDTO.Gender,
                Email = updatedEmployeeDTO.Email,
                EmployeeType = updatedEmployeeDTO.EmployeeType,
                HiringDate = updatedEmployeeDTO.HiringDate,
                PhoneNumber = updatedEmployeeDTO.PhoneNumber,
                Salary = updatedEmployeeDTO.Salary,
                Address = updatedEmployeeDTO.Address,
                Age = updatedEmployeeDTO.Age,
                IsActive = updatedEmployeeDTO.IsActive,
                DepartmentId = updatedEmployeeDTO.DepartmentId,
                LastModificationBy = 1,
                LastModificationOn = DateTime.UtcNow,
            };

           _unitOfWork.EmployeeRepository.Update(employee);
            return _unitOfWork.Complete();
        }
    }
}
