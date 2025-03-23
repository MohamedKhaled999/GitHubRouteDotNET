using IKEA.BLL.Common.Services;
using IKEA.BLL.Models.Employees;
using IKEA.DAL.Models.Employees;
using IKEA.DAL.Persistence.Repositories.Departments;
using IKEA.DAL.Persistence.Repositories.Employees;
using IKEA.DAL.Persistence.UnitOfWork;
using Microsoft.EntityFrameworkCore;
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
        private readonly IAttachService _attachService;

        public EmployeeService(IUnitOfWork unitOfWork ,
            IAttachService attachService
            )
        {
            
            _unitOfWork = unitOfWork;
            _attachService = attachService;

        }
        public async Task<int> CreateEmployeeAsync(CreatedEmployeeDTO createdEmployeeDTO)
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

            if (createdEmployeeDTO.Image is not null)
            {
                employee.Image = _attachService.
                        UploadFile(createdEmployeeDTO.Image, "images");
            }


            _unitOfWork.EmployeeRepository.Add(employee);
            return await _unitOfWork.CompleteAsync();
        }
        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            Employee employee =  await _unitOfWork.EmployeeRepository.GetById(id);
            if (employee != null)
            {
              
                 _unitOfWork.EmployeeRepository.Delete(employee);
                return await _unitOfWork.CompleteAsync()>0;

            }
            return false;
        }
        public async Task<EmployeeDetailsDTO?> GetEmployeeByIdAsync(int id)
        {
            Employee employee = await _unitOfWork.EmployeeRepository.GetById(id);


            return
             new EmployeeDetailsDTO()
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
                Department =employee.Department?.Name,
                Image = employee.Image
                
            };

        }
        public async Task<IEnumerable<EmployeeToReturnDTO>> GetEmployeesAsync(string? search)
        {
            if (search == null) search = string.Empty;
            var employees =  _unitOfWork.EmployeeRepository.GetAllAsQueryable()
                .Where(x => x.Name.ToLower().Contains(search.ToLower())).
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
                            Department = employee.Department==null ? null: employee.Department.Name,
                            
                        
                    }
               ).ToListAsync();

            return await employees;

        }
        public async Task<int> UpdateEmployeeAsync(UpdatedEmployeeDTO updatedEmployeeDTO)
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
            return await _unitOfWork.CompleteAsync();
        }
    }
}
