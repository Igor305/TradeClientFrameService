using AutoMapper;
using BusinessLogicLayer.Models;
using DataAccessLayer.Entities.Avrora;
using DataAccessLayer.Entities.Avrora37;

namespace BusinessLogicLayer.AutoHelper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ItExecutionPlanShop, ItExecutionPlanShopModel>();
            CreateMap<EmployeeSalary, EmployeeSalaryModel>();
        }
    }
}
