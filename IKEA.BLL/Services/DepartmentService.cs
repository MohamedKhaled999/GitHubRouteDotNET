using IKEA.BLL.Models.Departments;
using IKEA.DAL.Models.Departments;
using IKEA.DAL.Persistence.Repositories.Departments;
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
        IDepartmentRepository _repository;
        public DepartmentService(IDepartmentRepository repository ) 
        {
            _repository = repository;
        }
        public IEnumerable<DepartmentToReturnDTO> GetAllDepartments()
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


            ).ToList();


            Trace.WriteLine("moo");

            


            return departments; 




            
        }

        public DepartmentDetailsToReturnDTO? GetDepartmentById(int id)
        {
            var department = _repository.GetById(id);

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

        public int CreateDepartment(CreatedDepartmentDTO departmentDTO)
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

            return _repository.Add(createdDepartmet);
           
        }
        
        public int UpdatedDepartment(UpdatedDepartmentDTO departmentDTO)
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


            return _repository.Update(departmentToUpdate);  


        }

        public bool DeleteDepartment(int id)
        {
            var department = _repository.GetById(id);
           if(department is not null)
               return _repository.Delete(department)>0;
           return false;
        }

    }
}
