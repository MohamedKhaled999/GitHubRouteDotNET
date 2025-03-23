using IKEA.BLL.Models.Departments;
using IKEA.DAL.Models.Departments;
using IKEA.DAL.Persistence.Repositories.Departments;
using IKEA.DAL.Persistence.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        IDepartmentRepository _repository;
        public DepartmentService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
            _repository = unitOfWork.DepartmentRepository;
        }
        public async Task<IEnumerable<DepartmentToReturnDTO>> GetAllDepartmentsAsync()
        {
            //var departments =_repository.GetAll();
            var departments = _repository.GetAllAsQueryable().Select(
                department =>
            new DepartmentToReturnDTO
            {
                //        //Manual Mapping (Auto Mapper)
                Id = department.Id,
                Code = department.Code,
                CreationDate = department.CreationDate,
                Description = department.Description,
                Name = department.Name,

            }


            ).ToListAsync();


            Trace.WriteLine("moo");

            


            return await departments; 




            
        }

        public async Task<DepartmentDetailsToReturnDTO?> GetDepartmentByIdAsync(int id)
        {
            var department = await _repository.GetById(id);

            if (department is not null)
            {
                return new DepartmentDetailsToReturnDTO
                {
                    Id = department.Id,
                    Code = department.Code,
                    CreationDate = department.CreationDate,
                    Description = department.Description,
                    Name = department.Name,
                    CreatedBy = department.CreatedBy,
                    CreatedOn = department.CreatedOn,
                    LastModificationBy = department.LastModificationBy,
                    LastModificationOn = department.LastModificationOn,

                };
            }

          return null  ;
        }

        public async Task<int> CreateDepartmentAsync(CreatedDepartmentDTO departmentDTO)
        {
            var createdDepartmet = new Department
            {
                Description = departmentDTO.Description,
                Name = departmentDTO.Name,
                Code = departmentDTO.Code,
                CreatedBy = 1,
                LastModificationBy= 1,
                CreationDate= departmentDTO.CreationDate,
                LastModificationOn = DateTime.UtcNow,
                
                // by default by using sql in config folder
                //CreatedOn = DateTime.UtcNow,


            };

            _repository.Add(createdDepartmet);
            return await _unitOfWork.CompleteAsync();


        }
        
        public async Task<int> UpdatedDepartmentAsync(UpdatedDepartmentDTO departmentDTO)
        {
           
            var departmentToUpdate = new Department
            {
                Id= departmentDTO.Id,
                Description = departmentDTO.Description,
                Name = departmentDTO.Name,
                Code = departmentDTO.Code,
                CreationDate= departmentDTO.CreationDate,
                LastModificationBy=1,
                LastModificationOn= DateTime.UtcNow,
            
            };


             _repository.Update(departmentToUpdate); 
            return await _unitOfWork.CompleteAsync();



        }

        public async Task<bool> DeleteDepartmentAsync(int id)
        {
            var department = await _repository.GetById(id);
            if (department is not null)
            {
                _repository.Delete(department);
                return await _unitOfWork.CompleteAsync() > 0;
            }
                return false;
        }

    }
}
