using AutoMapper;
using El_sheikh.MVC.BLL.Models.Departments;
using El_sheikh.MVC.PL.ViewModels.Departments;

namespace El_sheikh.MVC.PL.Mapping
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {

            #region Department 

            CreateMap<DepartmentDetailsDto, DepartmentViewModel>()
                .ForMember(dest => dest.Name, config => config.MapFrom(src => src.Name));
            //.ReverseMap()
            //.ForMember(dest=>);


            CreateMap<DepartmentViewModel, UpdatedDepartmentDto>();

            CreateMap<DepartmentViewModel, CreatedDepartmentDto>();
            #endregion



            #region Employee Module

            #endregion


        }

    }
}
