using AutoMapper;
using IKEA.BLL.Models.Departments;
using IKEA.Models;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;

namespace IKEA.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            #region Department
            CreateMap<DepartmentDetailsToReturnDTO, DepartmentEditViewModel>();

            CreateMap<DepartmentEditViewModel, UpdatedDepartmentDTO>();
            #endregion        
        }

    }


}